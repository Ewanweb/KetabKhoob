namespace Common.AspNetCore
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class ApiResult<TData>
    {
        public bool IsSuccess { get; set; }
        public TData Data { get; set; }
        public MetaData MetaData { get; set; }
    }

    public class MetaData
    {
        public string Message { get; set; }
        public ApiStatusCode StatusCode { get; set; }
    }

    public enum ApiStatusCode
    {
        Success = 1,
        NotFound = 2,
        BadRequest = 3,
        LogicError = 4,
        Unauthorized = 5,
        ServerError = 6,
    }
}
