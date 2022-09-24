namespace SubtitleRed.Shared.Extensions;

public static class ObjectExtensions
{
    public static TObject Do<TObject>(this object @object, Func<TObject, TObject> func) where TObject : class
    {
        var value = (TObject)@object;
        return func.Invoke(value);
    } 
    
    public static TObject Do<TObject>(this object @object, Action<TObject> func) where TObject : class
    {
        var value = (TObject)@object;
        func.Invoke(value);
        return value;
    } 
    
    public static TCast To<TObject, TCast>(this object @object, Func<TObject, TCast> func) where TCast : class
    {
        var value = (TObject)@object;
        return func.Invoke(value);
    } 
}