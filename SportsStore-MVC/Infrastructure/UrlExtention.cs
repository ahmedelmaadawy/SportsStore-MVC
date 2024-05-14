namespace SportsStore_MVC.Infrastructure
{
    public static class UrlExtention
    {
        public static string PathAndQuery (this HttpRequest request) =>
            request.QueryString.HasValue?$"{request.Path}{request.QueryString}"
            :request.Path.ToString ();
    }
}
