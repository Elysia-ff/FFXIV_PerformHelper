﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                        int endPixel = GetPixel(notes[i].endTime);

                        if (!ValidatePixel(ref startPixel, ref endPixel))
                            continue;

                        if (i >= notes.Count - 1)
                        {
                            if (IsEndOfSheet(startPixel, endPixel))
                            {
                                player.Stop();
                                return;
                            }
                        }

                        int idx = (int)notes[i].code;
                        DrawBar(g, idx, startPixel, endPixel, notes[i].str);
                    }
                }

                DrawMoveRect(g);
            }
        }

        private bool ValidatePixel(ref int startPixel, ref int endPixel)
        {
            if (startPixel < 0)
                return false;
            if (startPixel > Height)
                startPixel = Height;

            if (endPixel > Height)
                return false;
            if (endPixel < 0)
                endPixel = 0;

            return true;
        }

        private bool IsEndOfSheet(int startPixel, int endPixel)
        {
            return startPixel == Height && endPixel == Height;
        }

        private void DrawMoveRect(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width - penWitdh, moveRectHeight + penWitdh);
            g.FillRectangle(moveRectBrush, rect.X, rect.Y, rect.Width, rect.Height);
            g.DrawRectangle(moveRectPen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void DrawBackground(Graphics g, int idx)
        {
            Rectangle rect = new Rectangle(barX[idx], 0, width, Height - penWitdh);
            g.FillRectangle(backgroundBrush, rect.X, rect.Y, rect.Width, rect.Height);
            g.DrawRectangle(backgroundPen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void DrawText(Graphics g, int idx)
        {
            Rectangle rect = new Rectangle(barX[idx], 0, width, Height - penWitdh);
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Font f = Font;
            using (GraphicsPath path = new GraphicsPath())
            {
                string value = MusicDefine.CodeStr[idx];
                path.AddString(value, f.FontFamily, (int)f.Style, f.Height, rect, stringFormat);

                g.DrawPath(textPen, path);
                g.FillPath(Brushes.White, path);

                g.TextRenderingHint = TextRenderingHint.SystemDefault;
                g.SmoothingMode = SmoothingMode.Default;
            }
        }

        private void DrawBar(Graphics g, int idx, int startPixel, int endPixel, string code)
        {
            int h = startPixel - endPixel;
            Rectangle rect = new Rectangle(barX[idx], endPixel, width, h - penWitdh);
            g.FillRectangle(barBrush, rect.X, rect.Y, rect.Width, rect.Height);
            g.DrawRectangle(barPen, rect.X, rect.Y, rect.Width, rect.Height);
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Font f = Font;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddString(code, f.FontFamily, (int)f.Style, f.Height, rect, stringFormat);
                g.DrawPath(barTextPen, path);
                g.FillPath(Brushes.White, path);

                g.TextRenderingHint = TextRenderingHint.SystemDefault;
                g.SmoothingMode = SmoothingMode.Default;
            }
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
            }
        }
    }
}
