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
            Default,
            Up,
            Down,
            DoubleUp,
        }

        public static string[] OctaveStr =
        {
            "  ",
            "↑",
            "↓",
            "↑↑",
        };

        public static int[] OctaveInt =
        {
            0,
            1,
            -1,
            2,
        };
    }
}
