using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper
{
    public class SheetReader
    {
        private XmlDocument doc;

        public SheetReader()
        {
            doc = new XmlDocument();
        }

        public void Initialize(string path)
        {
            try
            {
                doc.Load(path);
            }
            catch
            {
                throw new Exception(path + "is not valid");
            }
        }

        public SheetData Read()
        {
            SheetData data = new SheetData();

            //try
            {
                XmlNodeList root = doc.GetElementsByTagName(XmlDefine.Root);
                foreach (XmlNode xn in root)
                {
                    string name = xn[XmlDefine.MusicName].InnerText;
                    data.name = name;
                }

                XmlNodeList attributes = doc.GetElementsByTagName(XmlDefine.Attribute);
                foreach (XmlNode xn in attributes)
                {
                    int bpm = int.Parse(xn[XmlDefine.BPM].InnerText);
                    data.bpm = bpm;
                }

                XmlNodeList notes = doc.GetElementsByTagName(XmlDefine.Note);
                foreach (XmlNode xn in notes)
                {
                    int step = int.Parse(xn[XmlDefine.Pitch][XmlDefine.Code].InnerText);
                    int octave = int.Parse(xn[XmlDefine.Pitch][XmlDefine.Octave].InnerText);
                    double duration = double.Parse(xn[XmlDefine.Duration].InnerText);

                    SheetData.Note note = new SheetData.Note(step, octave, duration);
                    data.notes.Add(note);
                }
            }
            //catch
            //{
            //    throw new Exception("Read XML Failed");
            //}

            return data;
        }
    }
}
