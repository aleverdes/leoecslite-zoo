using UnityEngine;

namespace AffenCode
{
    public sealed class RegisterGlobal : MonoBehaviour
    {
        public Component Target;

        private void Awake()
        {
            Globals.Add(Target);
        }

        private void OnDestroy()
        {
            Globals.Remove(Target);
        }

        private void Reset()
        {
            Target = gameObject.GetComponent<MonoBehaviour>();
        }
    }
}