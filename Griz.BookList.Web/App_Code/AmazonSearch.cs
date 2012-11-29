using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Xml.Linq;

/// <summary>
/// AmazonSearch allows you to lookup books by ISBN pwoered by Amazon Web Services E-Commerce Service.
/// </summary>
public static class AmazonSearch
{
    /// <summary>
    /// Gets or sets the access key id of your AWS account.(Please set this property at initializing application, _AppStart.cshtml.)
    /// </summary>
    public static string AccessKeyId { get; set; }

    /// <summary>
    /// Gets or sets the secret access key of your AWS account.(Please set this property at initializing application, _AppStart.cshtml.)
    /// </summary>
    public static string SecretAccessKey { get; set; }

    /// <summary>
    /// Gets or sets the host of AWS E-Commerece Service to item lookup.(Default, "ecs.amazonaws.jp")
    /// </summary>
    public static string Host { get; set; }

    /// <summary>
    /// Gets or sets the url of AWS E-Commerece Service to item lookup.(Default, "/onca/xml")
    /// </summary>
    public static string Path { get; set; }

    /// <summary>
    /// Initializes the <see cref="AmazonSearch"/> class.
    /// </summary>
    static AmazonSearch()
    {
        Host = "ecs.amazonaws.jp";
        Path = "/onca/xml";
    }

    /// <summary>
    /// Lookups the book by ISBN.
    /// </summary>
    /// <param name="isbnToLookup">The ISBN to lookup.</param>
    public static AmazonSearchBookResult LookupBook(string isbnToLookup)
    {
        // Find from cache at first.
        var cacheKey = "5ce243f60066497792b56a77476a8f70/" + isbnToLookup;
        var context = HttpContext.Current;
        var cache = context != null ? context.Cache : default(Cache);
        if (cache != null)
        {
            var cachedResult = cache[cacheKey] as AmazonSearchBookResult;
            if (cachedResult != null) return cachedResult;
        }

        // Build serach parameters.
        var searchParam = new AmazonSearchParam(AccessKeyId, isbnToLookup);
        var queryStr = searchParam.ToQueryString();
        var signature = searchParam.GetSignature(SecretAccessKey, Host, Path);
        var uri = string.Format("http://{0}{1}?{2}&Signature={3}",
            Host, Path, queryStr, signature);

        // Call AWS.
        var lookupResult = new AmazonSearchBookResult(XDocument.Load(uri));

        // Insert into cache, and return.
        if (cache != null) cache.Insert(cacheKey, lookupResult);
        return lookupResult;
    }

    private static string ToAtribHtml(object attributes)
    {
        attributes = attributes ?? new object();
        var q = from prop in attributes.GetType().GetProperties()
                select string.Format(@" {0}=""{1}""", prop.Name, prop.GetValue(attributes, null));
        return string.Join("", q);
    }

    private static IHtmlString GetBookImageHtml(string isbn, object attributes, Func<AmazonSearchBookResult, string> getImageURL)
    {
        var book = LookupBook(isbn);
        return new HtmlString(string.Format(@"<img src=""{0}"" alt=""{1}""{2}/>", getImageURL(book), book.Title, ToAtribHtml(attributes)));
    }

    private static IHtmlString GetBookImageWithLinkHtml(string isbn, object attributes, Func<AmazonSearchBookResult, string> getImageURL)
    {
        var book = LookupBook(isbn);
        return new HtmlString(string.Format(@"<a href=""{0}""{3}><img src=""{1}"" alt=""{2}""/></a>",book.DetailPageURL, getImageURL(book), book.Title, ToAtribHtml(attributes)));
    }

    public static IHtmlString GetSmallBookImageHtml(string isbn, object attributes = null)
    {
        return GetBookImageHtml(isbn, attributes, book => book.SmallImageURL);
    }

    public static IHtmlString GetMediumBookImageHtml(string isbn, object attributes = null)
    {
        return GetBookImageHtml(isbn, attributes, book => book.MediumImageURL);
    }

    public static IHtmlString GetLargeBookImageHtml(string isbn, object attributes = null)
    {
        return GetBookImageHtml(isbn, attributes, book => book.LargeImageURL);
    }

    public static IHtmlString GetSmallBookImageWithLinkHtml(string isbn, object attributes = null)
    {
        return GetBookImageWithLinkHtml(isbn, attributes, book => book.SmallImageURL);
    }

    public static IHtmlString GetMediumBookImageWithLinkHtml(string isbn, object attributes = null)
    {
        return GetBookImageWithLinkHtml(isbn, attributes, book => book.MediumImageURL);
    }
    
    public static IHtmlString GetLargeBookImageWithLinkHtml(string isbn, object attributes = null)
    {
        return GetBookImageWithLinkHtml(isbn, attributes, book => book.LargeImageURL);
    }
}