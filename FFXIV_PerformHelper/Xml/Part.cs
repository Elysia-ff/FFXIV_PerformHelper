using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public class Part
    {
        public string id;
        public string name;
        public List<Measure> measures = new List<Measure>();

        public int StaffCount
        {
            get
            {
                for (int i = 0; i < measures.Count; ++i)
                {
                    if (measures[i].attributes != null)
                    {
                        return measures[i].attributes.staves;
                    }
                }

                return 0;
            }
        }

        public Part(XmlNode data, XmlNode part)
        {
            id = data.GetAttribute("id");
            XmlNode nameNode = data.SelectSingleNode("part-name");
            name = nameNode != null ? nameNode.InnerText : string.Empty;

            XmlNodeList measureList = part.SelectNodes("measure");
            for (int i = 0; i < measureList.Count; ++i)
            {
                measures.Add(new Measure(measureList[i]));
            }
        }

        public int GetBPM()
        {
            for (int i = 0; i < measures.Count; ++i)
            {
                if (measures[i].bpm > 0)
                    return measures[i].bpm;
            }

            return 0;
        }
    }
}
