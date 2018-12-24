using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_PerformHelper
{
    // 4/4 means that there are 4 beats per measure and a quarter note gets one count.
    // top=how many beats/measure.
    // bottom=what kind of note gets one count.
    public class SheetData
    {
        public string name;
        public int bpm;
        public List<Note> notes;
        public double endTime;

        public SheetData()
        {
            notes = new List<Note>();
        }

        public SheetData(SheetData source)
        {
            name = source.name;
            bpm = source.bpm;
            notes = new List<Note>();
            for (int i = 0; i < source.notes.Count; i++)
            {
                Note note = new Note(source.notes[i]);
                notes.Add(note);
            }
            endTime = source.endTime;
        }

        public static SheetData GetDefault()
        {
            SheetData sheetData = new SheetData();
            sheetData.name = "NewSheet";
            sheetData.bpm = 120;
            sheetData.notes = new List<Note>();
            sheetData.notes.Add(Note.GetDefault());

            return sheetData;
        }

        public void Apply()
        {
            double startTime = Setting.startDelay;
            double t = 0;
            double bps = bpm / 60d;
            double beatTime = 1d / bps;

            for (int i = 0; i < notes.Count; i++)
            {
                notes[i].startTime = t;
                if (i == 0)
                    notes[i].startTime += startTime;
                notes[i].endTime = notes[i].startTime + (beatTime * notes[i].duration);
                t = notes[i].endTime;
            }

            endTime = notes[notes.Count - 1].endTime;
        }
    }
}
