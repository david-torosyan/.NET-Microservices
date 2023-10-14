namespace Mango.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase {  get; set; }
        public enum ApiType
        {
            GET = 0,
            POST = 1, 
            PUT = 2,
            DELETE = 3,
        }
    }
}
