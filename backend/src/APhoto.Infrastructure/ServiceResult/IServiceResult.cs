namespace APhoto.Infrastructure.ServiceResult
{
    public interface IServiceResult<T> : IServiceResult
        where T : class
    {
        T? Value { get; set; }
    }

    public interface IServiceResult
    {
        string? Reason { get; set; }

        bool IsSuccess { get; set; }

        bool IsFailure { get; set; }
    }
}
