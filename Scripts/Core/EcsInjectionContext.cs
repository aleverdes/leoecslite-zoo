using System.Linq;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AffenCode
{
    public abstract class EcsInjectionContext : MonoBehaviour
    {
        private readonly EcsInjector _ecsInjector = new EcsInjector();

        protected virtual void FillFields()
        {
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (field.GetValue(this) != null)
                {
                    continue;
                }
                
                if (typeof(ScriptableObject).IsAssignableFrom(field.FieldType))
                {
                    var scriptableObject = default(ScriptableObject);
#if UNITY_EDITOR
                    var assetGuid = AssetDatabase.FindAssets("t:" + field.FieldType.Name).FirstOrDefault();
                    if (!string.IsNullOrEmpty(assetGuid))
                    {
                        scriptableObject = AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(assetGuid));
                    }
#endif
                    field.SetValue(this, scriptableObject);
                }
                else if (typeof(Component).IsAssignableFrom(field.FieldType))
                {
                    field.SetValue(this, FindObjectOfType(field.FieldType));
                }
            }
        }

        public virtual void InitInjector()
        {
            FillFields();
                
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(this);
                if (fieldValue != null)
                {
                    _ecsInjector.AddInjectionObject(fieldValue);
                }
            }
        }

        public EcsInjector GetInjector() => _ecsInjector;
    }
}