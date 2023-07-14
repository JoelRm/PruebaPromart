
namespace PruebaPromart.DTO.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public ICollection<string> ListErrors { get; set; }
        public BaseResponse()
        {
            ListErrors = new List<string>();
        }
    }
    public class BaseResponseEntity<TClass> : BaseResponse
    {
        public TClass? ResponseResult { get; set; }
    }
}
