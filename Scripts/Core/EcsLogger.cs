using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace AffenCode
{
    public interface IEcsLogger
    {
        void Info<T>(string message);
        void Info(string context, string message);
        void Info(string message);
        
        void Warning<T>(string message);
        void Warning(string context, string message);
        void Warning(string message);
        
        void Error<T>(string message);
        void Error(string context, string message);
        void Error(string message);
    }
    
    public class EcsLogger : IEcsLogger
    {
        private readonly Stopwatch _stopwatch;
        private readonly float _applicationTimeOnCreateLogger;
        
        public EcsLogger()
        {
            _stopwatch = Stopwatch.StartNew();
            _applicationTimeOnCreateLogger = Time.time;
        }
        
        public void Info<T>(string message)
        {
            Debug.Log($"[{GetCurrentTime()}] I: {typeof(T)}\n{message}");
        }

        public void Info(string context, string message)
        {
            Debug.Log($"[{GetCurrentTime()}] I: {context}\n{message}");
        }

        public void Info(string message)
        {
            Debug.Log($"[{GetCurrentTime()}] I: {message}");
        }
        
        public void Warning<T>(string message)
        {
            Debug.LogWarning($"[{GetCurrentTime()}] W: {typeof(T)}\n{message}");
        }

        public void Warning(string context, string message)
        {
            Debug.LogWarning($"[{GetCurrentTime()}] W: {context}\n{message}");
        }

        public void Warning(string message)
        {
            Debug.LogWarning($"[{GetCurrentTime()}] W: {message}");
        }

        public void Error<T>(string message)
        {
            Debug.LogError($"[{GetCurrentTime()}] E: {typeof(T)}\n{message}");
        }

        public void Error(string context, string message)
        {
            Debug.LogError($"[{GetCurrentTime()}] E: {context}\n{message}");
        }

        public void Error(string message)
        {
            Debug.LogError($"[{GetCurrentTime()}] E: {message}");
        }

        private TimeSpan GetCurrentTime() => _stopwatch.Elapsed.Add(TimeSpan.FromSeconds(_applicationTimeOnCreateLogger));
    }
}