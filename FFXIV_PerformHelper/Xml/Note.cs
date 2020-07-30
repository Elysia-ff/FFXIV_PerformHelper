using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public class Note
    {
        public enum Type
        {
            Note,
            Forward,
            Backup
        }

        public Type type;
        public bool isChord;
        public bool isRest;
        public bool isGrace;
        public Pitch pitch;
        public int duration;
        public int staff;

        public Note(Type noteType, XmlNode node)
        {
            type = noteType;

            XmlNode durationNode = node.SelectSingleNode("duration");
            duration = durationNode != null ? int.Parse(durationNode.InnerText) : 0;

            if (type == Type.Note)
            {
                isChord = node.SelectSingleNode("chord") != null;
                isRest = node.SelectSingleNode("rest") != null;
                isGrace = node.SelectSingleNode("grace") != null;

                XmlNode pitchNode = node.SelectSingleNode("pitch");
                if (pitchNode != null)
                {
                    pitch = new Pitch(pitchNode);
                }
                
                XmlNode staffNode = node.SelectSingleNode("staff");
                staff = staffNode != null ? int.Parse(staffNode.InnerText) : 1;
            }
        }
    }
}
