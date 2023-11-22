using System.Linq;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AleVerDes.LeoEcsLiteZoo
{
    public abstract class EcsInjectionContext : MonoBehaviour
    {
        protected readonly IEcsInjector Injector = new EcsInjector();

        protected virtual void Reset()
        {
            var privateSerializedUnityFields = GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => typeof(Object).IsAssignableFrom(x.FieldType))
                .Where(x => x.GetCustomAttributes(typeof(SerializeField)).Any())
                ;
            
            var publicUnityFields = GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => typeof(Object).IsAssignableFrom(x.FieldType))
                ;

            var fields = privateSerializedUnityFields.Concat(publicUnityFields).ToArray();
            
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
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(this);
                if (fieldValue == null) 
                    continue;
                
                var attribute = field.GetCustomAttributes(typeof(InjectAsAttribute)).FirstOrDefault();
                if (attribute is InjectAsAttribute injectAs)
                    Injector.AddInjectionObject(fieldValue, injectAs.Types.ToArray());
                else
                    Injector.AddInjectionObject(fieldValue);
            }
        }

        public IEcsInjector GetInjector() => Injector;
    }
}