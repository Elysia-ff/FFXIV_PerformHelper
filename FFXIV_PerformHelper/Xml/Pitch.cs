using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public struct Pitch
    {
        public string step;
        public int alter;
        public int octave;

        public Pitch(XmlNode node)
        {
            step = node.SelectSingleNode("step").InnerText;
            XmlNode alterNode = node.SelectSingleNode("alter");
            alter = alterNode != null ? int.Parse(alterNode.InnerText) : 0;
            octave = int.Parse(node.SelectSingleNode("octave").InnerText);
        }
    }
}
