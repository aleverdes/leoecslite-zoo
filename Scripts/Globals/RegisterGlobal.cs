using System;
using UnityEngine;

namespace AffenCode
{
    public sealed class RegisterGlobal : MonoBehaviour
    {
        public MonoBehaviour Target;

        private void Awake()
        {
            Globals.Add(Target);
        }
    }
}