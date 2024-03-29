
namespace Test.Api.DTO;

public class ResultService
{
    public bool IsSuccess { get; set; }
    public int CurrentPageIndex { get; set; }
    public int PageCount { get; set; }
    public string? ErrorMessage { get; set; }
    public ResultService(bool isSuccess) => IsSuccess = isSuccess;
    public ResultService(string? errorMessage) => ErrorMessage = errorMessage;

    public ResultService(bool isSuccess, string? errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}

public class ResultService<T> : ResultService
{
    public T? Data { get; set; }
    public ResultService(bool isSuccess) : base(isSuccess) { }
    public ResultService(string? errorMessage) : base(errorMessage) { }
    public ResultService(bool isSuccess, string? errorMessage) : base(isSuccess, errorMessage) { }
}