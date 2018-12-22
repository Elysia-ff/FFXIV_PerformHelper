using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_PerformHelper
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
}
