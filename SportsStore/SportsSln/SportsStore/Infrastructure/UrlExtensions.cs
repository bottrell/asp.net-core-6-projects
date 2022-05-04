namespace SportsStore.Infrastructure {

    public static class UrlExtensions {

        //This extension method generates a URL that the browser will return to after the cart has been updated
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" 
            : request.Path.ToString();

    }

}