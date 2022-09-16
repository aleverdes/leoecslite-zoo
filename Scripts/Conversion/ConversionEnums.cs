namespace AffenCode
{
    public enum CollectMode
    {
        OnlyThisGameObject,
        IncludeChildren
    }
    
    public enum ConvertMode
    {
        ConvertAndInject,
        ConvertAndDestroy
    }
    
    public enum ConvertTime
    {
        Start,
        EndOfFrame
    }
}