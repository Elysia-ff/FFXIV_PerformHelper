using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public static class XmlExtension
    {
        public static string GetAttribute(this XmlNode node, string name)
        {
            XmlAttributeCollection collection = node.Attributes;
            XmlNode attributeNode = collection.GetNamedItem(name);

            return attributeNode != null ? attributeNode.Value : string.Empty;
        }
    }
}
