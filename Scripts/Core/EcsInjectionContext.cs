using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using AleVerDes;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace AffenCode
{
    public abstract class EcsInjectionContext : MonoBehaviour
    {
        private readonly EcsInjector _ecsInjector = new EcsInjector();

        protected virtual void ResetField()
        {
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (typeof(ScriptableObject).IsAssignableFrom(field.FieldType))
                {
                    var o = default(ScriptableObject);
#if UNITY_EDITOR
                    var assetGuid = AssetDatabase.FindAssets("t:" + field.FieldType.Name).FirstOrDefault();
                    if (!string.IsNullOrEmpty(assetGuid))
                    {
                        o = AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(assetGuid));
                    }
#endif
                    field.SetValue(this, o);
                }
                else if (typeof(Component).IsAssignableFrom(field.FieldType))
                {
                    field.SetValue(this, FindObjectOfType(field.FieldType));
                }
            }
        }

        public virtual void Setup(EcsInjector ecsInjector)
        {
            ResetField();
                
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(this);
                if (fieldValue != null)
                {
                    ecsInjector.AddInjectionObject(fieldValue);
                }
            }
        }

        public EcsInjector GetInjector() => _ecsInjector;
    }
}