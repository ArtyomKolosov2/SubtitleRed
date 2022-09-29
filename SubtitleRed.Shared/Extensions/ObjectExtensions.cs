namespace SubtitleRed.Shared.Extensions;

public static class ObjectExtensions
{
    public static TObject Do<TObject>(this TObject value, Action<TObject> action)
    {
        action.Invoke(value);
        return value;
    }

    public static TResult To<TObject, TResult>(this TObject value, Func<TObject, TResult> map) => map.Invoke(value);

    public static TCast To<TCast>(this object value) => (TCast)value;

    public static TObject Do<TObject, TState>(this TObject value, TState state, Action<TObject, TState> action)
    {
        action.Invoke(value, state);
        return value;
    }
}