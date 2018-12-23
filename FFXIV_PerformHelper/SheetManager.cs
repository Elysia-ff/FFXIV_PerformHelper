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

            //try
            {
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
            }
            //catch
            //{
            //    throw new Exception("Read XML Failed");
            //}

            return data;
        }

        public XmlDocument Write(SheetData sheet)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode root = CreateElement(doc, XmlDefine.Root);
            doc.AppendChild(root);
            {
                XmlNode attribute = CreateElement(doc, XmlDefine.Attribute);
                {
                    XmlNode musicName = CreateElement(doc, XmlDefine.MusicName, sheet.name);
                    attribute.AppendChild(musicName);

                    XmlNode bpm = CreateElement(doc, XmlDefine.BPM, sheet.bpm.ToString());
                    attribute.AppendChild(bpm);
                }
                root.AppendChild(attribute);

                XmlNode data = CreateElement(doc, XmlDefine.Data);
                {
                    for (int i = 0; i < sheet.notes.Count; i++)
                    {
                        XmlNode note = CreateElement(doc, XmlDefine.Note);
                        {
                            XmlNode pitch = CreateElement(doc, XmlDefine.Pitch);
                            {
                                int codeIdx = (int)sheet.notes[i].code;
                                XmlNode code = CreateElement(doc, XmlDefine.Code, codeIdx.ToString());
                                pitch.AppendChild(code);

                                int octaveIdx = (int)sheet.notes[i].octave;
                                XmlNode octave = CreateElement(doc, XmlDefine.Octave, MusicDefine.OctaveInt[octaveIdx].ToString());
                                pitch.AppendChild(octave);
                            }
                            note.AppendChild(pitch);

                            XmlNode duration = CreateElement(doc, XmlDefine.Duration, sheet.notes[i].duration.ToString());
                            note.AppendChild(duration);
                        }
                        data.AppendChild(note);
                    }
                }
                root.AppendChild(data);
            }

            return doc;
        }

        public XmlDocument GetDefault()
        {
            SheetData sheetData = SheetData.GetDefault();

            return Write(sheetData);
        }

        private XmlNode CreateElement(XmlDocument doc, string name)
        {
            XmlNode node = doc.CreateElement(name);

            return node;
        }

        private XmlNode CreateElement(XmlDocument doc, string name, string value)
        {
            XmlNode node = doc.CreateElement(name);
            node.InnerText = value;

            return node;
        }
    }
}
