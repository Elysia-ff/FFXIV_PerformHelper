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

        public const char Sharp = '＃';
        public const char Flat = '♭';
        public const char Up = '↑';
        public const char Down = '↓';

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

        public static Code[] SharpOrder =
        {
            Code.F,
            Code.C,
            Code.G,
            Code.D,
            Code.A,
            Code.E,
            Code.B
        };

        public static Code[] FlatOrder =
        {
            Code.B,
            Code.E,
            Code.A,
            Code.D,
            Code.G,
            Code.C,
            Code.F
        };

        public static HashSet<Code> GetGlobalSharp(int count)
        {
            HashSet<Code> hash = new HashSet<Code>();
            for (int i = 0; i < count; i++)
            {
                hash.Add(SharpOrder[i]);
            }

            return hash;
        }

        public static HashSet<Code> GetGlobalFlat(int count)
        {
            HashSet<Code> hash = new HashSet<Code>();
            for (int i = 0; i < count; i++)
            {
                hash.Add(FlatOrder[i]);
            }

            return hash;
        }
    }
}
