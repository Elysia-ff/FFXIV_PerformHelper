using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_PerformHelper
{
    public static class Setting
    {
        public static int width;
        public static int height;
        public static int[] barX = new int[(int)MusicDefine.Code.Count + 1];

        public static void Initialize()
        {
            width = Properties.Settings.Default.BarWidth;
            height = Properties.Settings.Default.BarHeight;
            barX[0] = Properties.Settings.Default.BarX0;
            barX[1] = Properties.Settings.Default.BarX1;
            barX[2] = Properties.Settings.Default.BarX2;
            barX[3] = Properties.Settings.Default.BarX3;
            barX[4] = Properties.Settings.Default.BarX4;
            barX[5] = Properties.Settings.Default.BarX5;
            barX[6] = Properties.Settings.Default.BarX6;
            barX[7] = Properties.Settings.Default.BarX7;
            barX[8] = Properties.Settings.Default.BarX8;
            barX[9] = Properties.Settings.Default.BarX9;
            barX[10] = Properties.Settings.Default.BarX10;
            barX[11] = Properties.Settings.Default.BarX11;
            barX[12] = Properties.Settings.Default.BarX12;
        }

        public static void Save()
        {
            Properties.Settings.Default.BarWidth = width;
            Properties.Settings.Default.BarHeight = height;
            Properties.Settings.Default.BarX0 = barX[0];
            Properties.Settings.Default.BarX1 = barX[1];
            Properties.Settings.Default.BarX2 = barX[2];
            Properties.Settings.Default.BarX3 = barX[3];
            Properties.Settings.Default.BarX4 = barX[4];
            Properties.Settings.Default.BarX5 = barX[5];
            Properties.Settings.Default.BarX6 = barX[6];
            Properties.Settings.Default.BarX7 = barX[7];
            Properties.Settings.Default.BarX8 = barX[8];
            Properties.Settings.Default.BarX9 = barX[9];
            Properties.Settings.Default.BarX10 = barX[10];
            Properties.Settings.Default.BarX11 = barX[11];
            Properties.Settings.Default.BarX12 = barX[12];

            Properties.Settings.Default.Save();
        }

        public static void Reset()
        {
            Properties.Settings.Default.Reset();

            Initialize();
        }
    }
}
