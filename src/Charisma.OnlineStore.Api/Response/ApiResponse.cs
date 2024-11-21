namespace Charisma.OnlineStore.Api.Response
{
    public class ApiResponse
    {
        public object? Data { get; set; }
        public int StatusCode { get; set; }
        public List<Message>? Messages { get; set; }


        public static ApiResponse Ok<T>(T data) => new() { Data = data, StatusCode = StatusCodes.Status200OK, Messages = [] };
        public static ApiResponse Ok() => new() { Data = null, StatusCode = StatusCodes.Status200OK, Messages = [] };
        public static ApiResponse Error(int statusCodes, List<Message> messages)
        {
            return new ApiResponse
            {
                Data = null,
                StatusCode = statusCodes,
                Messages = messages
            };
        }
    }
}
