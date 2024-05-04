namespace APhoto.Infrastructure.ServiceResult
{
    public class ServiceResult<T> : IServiceResult<T>
        where T : class
    {
        protected ServiceResult()
        {
        }

        public T? Value { get; set; }
        public string? Reason { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsFailure { get; set; }

        public static IServiceResult<T> Fail(string reason)
        {
            return new ServiceResult<T>
            {
                Value = null,
                Reason = reason,
                IsFailure = true,
                IsSuccess = false
            };
        }

        public static IServiceResult<T> Success(T value)
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
