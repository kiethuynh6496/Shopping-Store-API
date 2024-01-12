using Shopping_Store_API.Commons;

namespace Shopping_Store_API.Entities
{
    public class ApiError : Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorName { get; set; }
        public string ErrorMessage { get; set; }

        public ApiError(int errorCode)
        {
            ErrorCode = errorCode;
            ErrorName = Enum.GetName(typeof(ErrorCodes), errorCode);
        }
    }
}
