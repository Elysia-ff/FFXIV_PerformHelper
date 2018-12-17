using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIV_PerformHelper
{
    public partial class SheetWindow : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private int moveRectHeight = 20;
        private int penWitdh = 1;
        private int width = 40;
        private int[] barX = new int[(int)MusicDefine.Code.Count]
        {
            0,
            30,
            60,
            92,
            122,
            185,
            216,
            247,
            278,
            309,
            340,
            371
        };

        private FFXIV_PerformHelper player;
        private List<SheetData.Note> notes;

        public SheetWindow(FFXIV_PerformHelper _player)
        {
            player = _player;
            InitializeComponent();

            MouseDown += SheetWindow_MouseDown;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            ResizeWindow();
        }

        private void ResizeWindow()
        {
            Size size = Size;
            size.Width = barX[barX.Length - 1] + width + penWitdh;
            Size = size;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Visible)
            {
                Graphics g = e.Graphics;

                for (int i = 0; i < (int)MusicDefine.Code.Count; i++)
                {
                    DrawBackground(g, i);
                    DrawText(g, i);
                }

                if (player.IsPlaying)
                {
                    notes = player.GetNotes();
                    for (int i = 0; i < notes.Count; i++)
                    {
                        if (notes[i].code == MusicDefine.Code.REST)
                            continue;

                        int startPixel = GetPixel(notes[i].startTime);
                        if (startPixel < 0)
                            continue;
                        if (startPixel > Height)
                            startPixel = Height;

                        int endPixel = GetPixel(notes[i].endTime);
                        if (endPixel > Height)
                            continue;
                        if (endPixel < 0)
                            endPixel = 0;

                        if (startPixel == 0 && endPixel == 0)
                            continue;
                        if (startPixel == Height && endPixel == Height)
                        {
                            if (i >= notes.Count - 1)
                            {
                                player.Stop();
                                return;
                            }
                            continue;
                        }

                        int idx = (int)notes[i].code;
                        DrawBar(g, idx, startPixel, endPixel, notes[i].str);
                    }
                }

                DrawMoveRect(g);
            }
        }

        private void DrawMoveRect(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width - penWitdh, moveRectHeight + penWitdh);
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, rect.X, rect.Y, rect.Width, rect.Height);

            Pen framePen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), penWitdh)
            {
                LineJoin = LineJoin.Bevel
            };
            g.DrawRectangle(framePen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void DrawBackground(Graphics g, int idx)
        {
            Rectangle rect = new Rectangle(barX[idx], 0, width, Height - penWitdh);
            SolidBrush b = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            g.FillRectangle(b, rect.X, rect.Y, rect.Width, rect.Height);

            Pen framePen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), penWitdh)
            {
                LineJoin = LineJoin.Bevel
            };
            g.DrawRectangle(framePen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void DrawText(Graphics g, int idx)
        {
            Rectangle rect = new Rectangle(barX[idx], 0, width, Height - penWitdh);
            rect.Inflate(0, 0);

            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Far,
                Alignment = StringAlignment.Center
            };

            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Font f = Font;
            GraphicsPath path = new GraphicsPath();
            string value = MusicDefine.CodeStr[idx];
            path.AddString(value, f.FontFamily, (int)f.Style, f.Height, rect, sf);

            Pen p = new Pen(Color.FromArgb(0x46, 0x86, 0xa9), penWitdh)
            {
                LineJoin = LineJoin.Round
            };
            g.DrawPath(p, path);
            g.FillPath(Brushes.White, path);
            g.SmoothingMode = SmoothingMode.Default;

            p.Dispose();
            path.Dispose();
        }

        private void DrawBar(Graphics g, int idx, int startPixel, int endPixel, string code)
        {
            int h = startPixel - endPixel;
            Rectangle rect = new Rectangle(barX[idx], endPixel, width, h);
            SolidBrush b = new SolidBrush(Color.FromArgb(0x8, 0x2c, 0x52));
            g.FillRectangle(b, rect.X, rect.Y, rect.Width, rect.Height);

            Pen framePen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), penWitdh)
            {
                LineJoin = LineJoin.Bevel
            };
            g.DrawRectangle(framePen, rect.X, rect.Y, rect.Width, rect.Height);

            rect.Inflate(0, 0);

            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Far,
                Alignment = StringAlignment.Center
            };

            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Font f = Font;
            GraphicsPath path = new GraphicsPath();
            path.AddString(code, f.FontFamily, (int)f.Style, f.Height, rect, sf);

            Pen p = new Pen(Color.FromArgb(0x46, 0x86, 0xa9), penWitdh)
            {
                LineJoin = LineJoin.Round
            };
            g.DrawPath(p, path);
            g.FillPath(Brushes.White, path);
            g.SmoothingMode = SmoothingMode.Default;
        }

        private int GetPixel(double time)
        {
            double timeLeft = time - player.ElapsedTime;
            double pixel = Height - (timeLeft * player.Speed);

            return (int)pixel;
        }

        private void SheetWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                Debug.Write(string.Format("{0} {1}", this.Top, this.Left));
            }
        }
    }
}
