using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Helpers
{
    public static class HtmlHelper 
    {
       public static string GetIframeSrc(string url)
       {
            
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(url);
            var iframeNode = htmlDocument.DocumentNode.SelectSingleNode("//iframe");
            if (iframeNode != null)
            {
                var srcAttributeValue = iframeNode.GetAttributeValue("src", "");
                return srcAttributeValue;
            }
            return null;
        }
    }
}
