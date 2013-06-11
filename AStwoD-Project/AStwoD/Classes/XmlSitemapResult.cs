using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace AStwoD.Classes
{
    public class XmlSitemapResult:ActionResult
    {
        private IEnumerable<ISiteMapItem> _items;
 
        public XmlSitemapResult(IEnumerable<ISiteMapItem> items )
        {
            _items = items;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            string encoding = context.HttpContext.Response.ContentEncoding.WebName;
            XDocument sitemap = new XDocument(new XDeclaration("1.0",encoding,"yes"),new XElement("urlset",XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9"), from item in _items select CreateItemElement(item)));
            context.HttpContext.Response.ContentType = "application/rss+xml";
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(sitemap.Declaration+sitemap.ToString());
        }

        private XElement CreateItemElement(ISiteMapItem item )
        {
            XElement itemXML = new XElement("url",new XElement("loc",item.Url.ToLower()));
            if(item.LastModified.HasValue)
            {
                itemXML.Add(new XElement("lastmod",item.LastModified.Value.ToString("dd-MM-yyyy")));
            }
            if(item.ChangeFrequency.HasValue)
            {
                itemXML.Add(new XElement("changefreq",item.ChangeFrequency.Value.ToString().ToLower()));
            }
            if(item.Priority.HasValue)
            {
                itemXML.Add(new XElement("priority",item.Priority.Value.ToString(CultureInfo.InvariantCulture)));
            }
            return itemXML;

            return itemXML;
        }
    }
}