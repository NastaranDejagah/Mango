using Mango.Web.Utility;
namespace Mango.Web.Models
{
    public class RequestDto
    {
        public SendType.ApiType ApiType { get; set; } = SendType.ApiType.Get;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
