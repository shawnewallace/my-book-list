using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

/// <summary>
/// The result of LookupItem API by ISBN to lookup books.
/// </summary>
[Serializable]
public class AmazonSearchBookResult
{
    public XDocument RawData { get; set; }

    [NonSerialized]
    protected Lazy<XmlNamespaceManager> _NameSpaceManager;

    public XmlNamespaceManager NameSpaceManager { get { return this._NameSpaceManager.Value; } }

    public XElement XPathSelectElement(string expression, string defaultValue = "")
    {
        return this.RawData.XPathSelectElement(expression, this.NameSpaceManager) ?? new XElement("default", defaultValue);
    }

    public string Title { get {
        return this.XPathSelectElement("//ns:Items/ns:Item/ns:ItemAttributes/ns:Title").Value;
    } }

    public string Manufacturer { get {
            return this.XPathSelectElement("//ns:Items/ns:Item/ns:ItemAttributes/ns:Manufacturer").Value;
    } }

    public string ASIN { get {
        return this.XPathSelectElement("//ns:Items/ns:Item/ns:ASIN").Value;
    } }

    public string DetailPageURL { get {
        return this.XPathSelectElement("//ns:Items/ns:Item/ns:DetailPageURL").Value;
    } }

    public string SmallImageURL { get {
        return this.XPathSelectElement("//ns:Items/ns:Item/ns:SmallImage/ns:URL").Value;
    } }

    public string MediumImageURL { get {
        return this.XPathSelectElement("//ns:Items/ns:Item/ns:MediumImage/ns:URL").Value;
    } }

    public string LargeImageURL { get {
        return this.XPathSelectElement("//ns:Items/ns:Item/ns:LargeImage/ns:URL").Value;
    } }

    public AmazonSearchBookResult(XDocument lookupResult)
	{
        this.RawData = lookupResult;
        this._NameSpaceManager = new Lazy<XmlNamespaceManager>(() => {
            var nameTable = RawData.Root.CreateReader().NameTable;
            var nsmgr = new XmlNamespaceManager(nameTable);
            nsmgr.AddNamespace("ns", this.RawData.Root.Name.NamespaceName);
            return nsmgr;
        });
	}
}