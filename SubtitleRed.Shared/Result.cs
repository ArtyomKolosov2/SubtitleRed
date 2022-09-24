namespace SubtitleRed.Shared
{
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

        public static Result<TSuccess, TError> Success(TSuccess successPayload)
        {
            return new Result<TSuccess, TError>(successPayload);
        }

        public static Result<TSuccess, TError> Failure(TError failurePayload)
        {
            return new Result<TSuccess, TError>(failurePayload);
        }
    }
}
