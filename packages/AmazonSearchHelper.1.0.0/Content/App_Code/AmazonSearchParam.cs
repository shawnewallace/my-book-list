using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// AmazonSearchParam is the parameters of AWS E-Commerce Service.
/// </summary>
public class AmazonSearchParam
{
    public string Service { get; set; }
    public string AWSAccessKeyId { get; set; }
    public string Operation { get; set; }
    public string ItemId { get; set; }
    public string IdType { get; set; }
    public string SearchIndex { get; set; }
    public string ResponseGroup { get; set; }
    public string Version { get; set; }
    public string Timestamp { get; set; }

    public AmazonSearchParam()
    {
        InitializeProperty();
    }

    public AmazonSearchParam(string accessKeyId, string isbnToLookup)
    {
        InitializeProperty();

        this.AWSAccessKeyId = accessKeyId;
        this.ItemId = isbnToLookup;
    }

    private void InitializeProperty()
    {
        this.Service = "AWSECommerceService";
        this.Operation = "ItemLookup";
        this.IdType = "ISBN";
        this.SearchIndex = "Books";
        this.ResponseGroup = "Images,Small";
        this.Version = "2009-03-31";
        this.Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

    private string CustomUrlEncode(string text)
    {
        return Regex.Replace(HttpUtility.UrlEncode(text), "%[0-9a-z]{2}", m => m.Value.ToUpper());
    }

    public string ToQueryString()
    {
        var props = from prop in this.GetType().GetProperties()
                    orderby prop.Name
                    let rawVal = prop.GetValue(this, null) as string
                    let encodedVal = CustomUrlEncode(rawVal)
                    select string.Format("{0}={1}", prop.Name, encodedVal);

        return string.Join("&", props);
    }

    public string GetSignature(string secretAccessKey, string host = "ecs.amazonaws.jp", string path = "/onca/xml")
    {
        var queryStr = this.ToQueryString();
        var strToSign = string.Format("GET\n{0}\n{1}\n{2}", host, path, queryStr);
        var toSign = Encoding.UTF8.GetBytes(strToSign);

        var signer = new HMACSHA256(Encoding.UTF8.GetBytes(secretAccessKey));
        var sigBytes = signer.ComputeHash(toSign);
        var signature = CustomUrlEncode(Convert.ToBase64String(sigBytes));

        return signature;
    }
}