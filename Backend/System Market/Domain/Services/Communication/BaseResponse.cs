namespace Super_Market.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool sucess, string message)
        {
            Success = sucess;
            Message = message;
        }
    }
}