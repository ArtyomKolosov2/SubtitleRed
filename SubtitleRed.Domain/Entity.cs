namespace SubtitleRed.Domain;

public abstract record Entity<T>
{
    public T Id { get; protected set; }
}