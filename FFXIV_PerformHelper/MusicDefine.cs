using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_PerformHelper
{
    public class MusicDefine
    {
        public enum Code
        {
            C = 0,
            CSharp,
            D,
            EFlat,
            E,
            F,
            FSharp,
            G,
            GSharp,
            A,
            BFlat,
            B,
            Count,

            REST = 99,
        }

        public static string[] CodeStr =
        {
            "C",
            "C＃",
            "D",
            "E♭",
            "E",
            "F",
            "F＃",
            "G",
            "G＃",
            "A",
            "B♭",
            "B"
        };

        public enum Octave
        {
            Down,
            Default,
            Up,
            DoubleUp,
        }

        public static string[] OctaveStr =
        {
            "↓",
            "  ",
            "↑",
            "↑↑",
        };

        public static int[] OctaveInt =
        {
            -1,
            0,
            1,
            2,
        };

        private static readonly StringBuilder stringBuilder = new StringBuilder();

        public static string GetStringCode(Code code, Octave octave)
        {
            stringBuilder.Remove(0, stringBuilder.Length);

            if (octave != Octave.Default)
            {
                string mark = OctaveStr[(int)octave];
                stringBuilder.Append(mark);
            }

            int codeIdx = (int)code;
            string str = CodeStr[codeIdx];
            stringBuilder.Append(str);

            return stringBuilder.ToString();
        }
    }
}
