using System;
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
    }
}