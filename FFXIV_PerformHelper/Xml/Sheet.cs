using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FFXIV_PerformHelper.Xml
{
    public class Sheet
    {
        public string version;
        public string title;
        public List<Part> parts = new List<Part>();

        public int PartCount { get { return parts.Count; } }

        public Sheet(XmlDocument xml)
        {
            XmlNode sheetNode = xml.SelectSingleNode("//score-partwise");
            version = sheetNode.GetAttribute("version");
            title = GetSheetName(sheetNode);

            XmlNodeList partDataList = sheetNode.SelectNodes("part-list/score-part");
            for (int i = 0; i < partDataList.Count; ++i)
            {
                string id = partDataList[i].GetAttribute("id");
                parts.Add(new Part(partDataList[i], sheetNode.SelectSingleNode($"part[@id='{id}']")));
            }
        }

        private static string GetSheetName(XmlNode node)
        {
            XmlNode titleNode = node.SelectSingleNode("work/work-title");
            if (titleNode != null)
                return titleNode.InnerText;

            titleNode = node.SelectSingleNode("movement-title");
            if (titleNode != null)
                return titleNode.InnerText;

            return string.Empty;
        }

        public Part GetPart(string id)
        {
            for (int i = 0; i < parts.Count; ++i)
            {
                if (parts[i].id.Equals(id))
                    return parts[i];
            }

            return null;
        }

        public List<FFXIVNote> GetFFXIVNotes()
        {
            if (parts.Count <= 0)
                return null;

            int bpm = parts[0].measures[0].bpm;
            string partId = parts[0].id;
            return GetFFXIVNotes(bpm, partId, 0);
        }

        public List<FFXIVNote> GetFFXIVNotes(int bpm, string partId, float startTime)
        {
            List<FFXIVNote> result = new List<FFXIVNote>();
            Part part = GetPart(partId);
            float divisionTime = 0f;
            
            for (int i = 0; i < part.measures.Count; ++i)
            {
                Measure measure = part.measures[i];
                if (measure.attributes != null)
                {
                    int divisions = measure.attributes.divisions;
                    if (divisions > 0)
                        divisionTime = 60f / bpm / divisions;
                }

                for (int k = 0; k < measure.notes.Count; ++k)
                {
                    Note note = measure.notes[k];
                    if (note.type == Note.Type.Note)
                    {
                        FFXIVNote ffxivNote = new FFXIVNote();
                        if (!note.isRest)
                            ffxivNote.pitch = note.pitch;

                        if (note.isChord)
                            startTime = result[result.Count - 1].startTime;

                        ffxivNote.startTime = startTime;
                        ffxivNote.endTime = startTime + (note.duration * divisionTime);
                        startTime = ffxivNote.endTime;

                        result.Add(ffxivNote);
                    }
                    else if (note.type == Note.Type.Forward)
                    {
                        startTime += (note.duration * divisionTime);
                    }
                    else if (note.type == Note.Type.Backup)
                    {
                        startTime -= (note.duration * divisionTime);
                    }
                }
            }

            return result;
        }
    }
}
