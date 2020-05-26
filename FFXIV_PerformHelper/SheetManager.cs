using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper
{
    public class SheetManager
    {
        public SheetData Read(XmlDocument doc)
        {
            SheetData data = new SheetData();

            XmlNodeList attributes = doc.GetElementsByTagName(XmlDefine.Attribute);
            foreach (XmlNode xn in attributes)
            {
                string name = xn[XmlDefine.MusicName].InnerText;
                int bpm = int.Parse(xn[XmlDefine.BPM].InnerText);

                data.name = name;
                data.bpm = bpm;
            }

            XmlNodeList notes = doc.GetElementsByTagName(XmlDefine.Note);
            foreach (XmlNode xn in notes)
            {
                int step = int.Parse(xn[XmlDefine.Pitch][XmlDefine.Code].InnerText);
                int octave = int.Parse(xn[XmlDefine.Pitch][XmlDefine.Octave].InnerText);
                double duration = double.Parse(xn[XmlDefine.Duration].InnerText);

                Note note = new Note(step, octave, duration);
                data.notes.Add(note);
            }

            return data;
        }
    }
}
