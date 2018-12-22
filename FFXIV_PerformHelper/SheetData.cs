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
        public class Note
        {
            public readonly MusicDefine.Code code;
            public readonly MusicDefine.Octave octave;
            public readonly double duration;
            public readonly string str;

            public double startTime;
            public double endTime;

            public Note(int _step, int _octave, double _duration)
            {
                int codeIdx = _step;

                #region Code
                code = (MusicDefine.Code)codeIdx;
                #endregion

                #region Octave
                if (_octave == 0)
                {
                    octave = MusicDefine.Octave.Default;
                }
                else
                {
                    if (_octave > 1)
                        octave = MusicDefine.Octave.DoubleUp;
                    else if (_octave > 0)
                        octave = MusicDefine.Octave.Up;
                    else
                        octave = MusicDefine.Octave.Down;
                }
                #endregion

                duration = _duration;
                str = (codeIdx < MusicDefine.CodeStr.Length) ? MakeStr(MusicDefine.CodeStr[codeIdx]) : string.Empty;
            }

            public Note(MusicDefine.Code _code, MusicDefine.Octave _octave, double _duration)
            {
                code = _code;
                octave = _octave;
                duration = _duration;

                int codeIdx = (int)code;
                str = (codeIdx < MusicDefine.CodeStr.Length) ? MakeStr(MusicDefine.CodeStr[codeIdx]) : string.Empty;
            }

            public Note(Note source)
            {
                code = source.code;
                octave = source.octave;
                duration = source.duration;
                str = source.str;

                startTime = source.startTime;
                endTime = source.endTime;
            }

            public static Note GetDefault()
            {
                int code = (int)MusicDefine.Code.C;
                int octave = MusicDefine.OctaveInt[(int)MusicDefine.Octave.Default];
                double duration = 1d;

                Note note = new Note(code, octave, duration);

                return note;
            }

            private string MakeStr(string step)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (octave != MusicDefine.Octave.Default)
                {
                    string mark = MusicDefine.OctaveStr[(int)octave];
                    stringBuilder.Append(mark);
                }

                stringBuilder.Append(step);

                return stringBuilder.ToString();
            }
        }

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

        public void Apply(double startTime)
        {
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
