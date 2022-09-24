namespace SubtitleRed.Shared;

public class Result<TSuccess, TError> where TError : Error
{
    public TSuccess? Data { get; private set; }

    public TError? Error { get; private set; }

    public bool IsSuccess => Data is not null;

    public bool IsFailure => Error is not null && Data is null;

    private Result(TSuccess successPayload)
    {
        Data = successPayload;
    }

    private Result(TError failurePayload)
    {
        Error = failurePayload;
    }

    public static Result<TSuccess, TError> Success(TSuccess successPayload) => 
        new(successPayload);

    public static Result<TSuccess, TError> Failure(TError failurePayload) => 
        new(failurePayload);

    public static implicit operator TSuccess(Result<TSuccess, TError> param) => 
        (param.IsSuccess ? param.Data : throw new InvalidOperationException("Invalid state of result. Cast isn't possible."))!;
}