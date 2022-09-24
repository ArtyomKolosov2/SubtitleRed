namespace SubtitleRed.Shared;

public class Error
{
    public Exception? Exception { get; set; }

    public string? Message { get; set; }

    public static Error WithMessage(string message) => new Error
    {
        Message = message
    };
}