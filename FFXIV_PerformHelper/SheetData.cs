using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            public readonly string step;
            public readonly int alter;
            public readonly int octave;
            public readonly double duration;
            public readonly string str;

            public double startTime;
            public double endTime;

            public Note(int _step, int _alter, int _octave, double _duration)
            {
                int codeIdx = _step;
                if (_alter != 0)
                {
                    int count = Math.Abs(_alter);
                    int mark = (_alter > 0) ? count : -count;

                    codeIdx += mark;
                }

                code = (MusicDefine.Code)codeIdx;
                step = (codeIdx >= MusicDefine.CodeStr.Length) ? step = code.ToString() : MusicDefine.CodeStr[codeIdx];
                alter = _alter;
                octave = _octave;
                duration = _duration;
                str = MakeStr();
            }

            private string MakeStr()
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (octave != 0)
                {
                    char mark = (octave > 0) ? MusicDefine.Up : MusicDefine.Down;
                    int count = Math.Abs(octave);

                    for (int i = 0; i < count; i++)
                        stringBuilder.Append(mark);
                }

                stringBuilder.Append(step);

                return stringBuilder.ToString();
            }
        }

        public string name;
        public int bpm;
        public List<Note> notes;

        public int Count { get { return notes.Count; } }
        public Note this[int i] { get { return notes[i]; } }

        public SheetData()
        {
            notes = new List<Note>();
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

                Debug.WriteLine(string.Format("start : {0}\t\tend : {1}", notes[i].startTime, notes[i].endTime));
            }
        }
    }
}
