namespace APhoto.Infrastructure.Utility
{
    public class ServiceResult<T> : ServiceResult, IServiceResult<T>
        where T : class
    {
        protected ServiceResult()
            : base()
        {
        }

        public T? Value { get; set; }

        public static new IServiceResult<T> Fail(string reason)
        {
            return new ServiceResult<T>
            {
                Value = null,
                Reason = reason,
                IsFailure = true,
                IsSuccess = false
            };
        }

        public static new IServiceResult<T> Success(T value)
        {
            return new ServiceResult<T>
            {
                Value = value,
                Reason = null,
                IsFailure = false,
                IsSuccess = true
            };
        }
    }

    public class ServiceResult : IServiceResult
    {
        protected ServiceResult()
        {
        }

        public string? Reason { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsFailure { get; set; }

        public static IServiceResult Fail(string reason)
        {
            return new ServiceResult
            {
                Reason = reason,
                IsFailure = true,
                IsSuccess = false
            };
        }

        public static IServiceResult Success()
        {
            return new ServiceResult
            {
                Reason = null,
                IsFailure = false,
                IsSuccess = true
            };
        }
    }
}
