namespace SubtitleRed.Shared;

public class Error
{
    public Exception? Exception { get; init; }

    public string? Message { get; init; }

    public static Error WithMessage(string message) => new Error
    {
        Message = message
    };

    public static Error WithException(Exception exception) => new Error
    {
        Exception = exception
    };
}