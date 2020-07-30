using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public class Attributes
    {
        public int staves;
        public int divisions;

        public Attributes(XmlNode node)
        {
            XmlNode stavesNode = node.SelectSingleNode("staves");
            staves = stavesNode != null ? int.Parse(stavesNode.InnerText) : 1;
            XmlNode divisionNode = node.SelectSingleNode("divisions");
            divisions = divisionNode != null ? int.Parse(divisionNode.InnerText) : -1;
        }
    }
}
