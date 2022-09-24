namespace SubtitleRed.Shared.Extensions;

public static class ResultExtensions
{
    public static Result<TBindSuccess, TError> Bind<TInitialSuccess, TBindSuccess, TError>(
        this Result<TInitialSuccess, TError> result,
        Func<TInitialSuccess, Result<TBindSuccess, TError>> func) where TError : Error =>
        result.IsSuccess ? func.Invoke(result) : Result<TBindSuccess, TError>.Failure(result.Error!);

    public static Result<TSuccess, TError> OnError<TSuccess, TError>(this Result<TSuccess, TError> result,
        Action<Result<TSuccess, TError>> action) where TError : Error
    {
        if (result.IsFailure)
            action.Invoke(result);

        return result;
    }

    public static Result<TSuccess, TError> OnSuccess<TSuccess, TError>(this Result<TSuccess, TError> result,
        Action<Result<TSuccess, TError>> action) where TError : Error
    {
        if (result.IsSuccess)
            action.Invoke(result);

        return result;
    }

    public static Result<TSuccess, TError> Do<TSuccess, TError>(this Result<TSuccess, TError> result,
        Action<Result<TSuccess, TError>> action) where TError : Error
    {
        action.Invoke(result);
        return result;
    }
    
    public static Result<TCast, TError> Wrap<TSuccess, TCast, TError>(this Result<TSuccess, TError> result)
        where TError : Error
        where TCast : TSuccess =>
        result.IsSuccess ? Result<TCast, TError>.Success((TCast)result.Data!) : Result<TCast, TError>.Failure(result.Error!);

    public static TTarget To<TSuccess, TTarget, TError>(this Result<TSuccess, TError> result,
        Func<Result<TSuccess, TError>, TTarget> action) where TError : Error =>
        action.Invoke(result);
}