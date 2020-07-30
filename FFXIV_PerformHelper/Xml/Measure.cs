using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public class Measure
    {
        public string num;
        public Attributes attributes;
        public int bpm;
        public List<Note> notes = new List<Note>();

        public Measure(XmlNode node)
        {
            num = node.GetAttribute("number");

            XmlNode attributesNode = node.SelectSingleNode("attributes");
            if (attributesNode != null)
            {
                attributes = new Attributes(attributesNode);
            }

            XmlNode soundNode = node.SelectSingleNode("sound");
            if (soundNode != null)
            {
                if (int.TryParse(soundNode.GetAttribute("tempo"), out int tempo))
                    bpm = tempo;
            }

            for (int i = 0; i < node.ChildNodes.Count; ++i)
            {
                XmlNode childNode = node.ChildNodes[i];

                if (childNode.Name.Equals("note"))
                {
                    notes.Add(new Note(Note.Type.Note, childNode));
                }
                else if (childNode.Name.Equals("forward"))
                {
                    notes.Add(new Note(Note.Type.Forward, childNode));
                }
                else if (childNode.Name.Equals("backup"))
                {
                    notes.Add(new Note(Note.Type.Backup, childNode));
                }
            }
        }
    }
}
