namespace Mango.Web.Utility
{
    public class SendType
    {
        public static string? CouponAPIBase { get; set; }
        public enum ApiType
        {
            Get,
            Post, 
            Put,
            Delete
        }
    }
}
