namespace AleVerDes.LeoEcsLiteZoo
{
    public interface IEcsModule
    {
        IEcsFeatures AddFeatures(IEcsFeatures features);
    }
    
    public interface IEcsCallback
    {
        public interface IInit
        {
            void Initialize();
        }
            
        public interface IUpdate
        {
            void Update();
        }
            
        public interface IFixedUpdate
        {
            void FixedUpdate();
        }
            
        public interface ILateUpdate
        {
            void LateUpdate();
        }
    }
}