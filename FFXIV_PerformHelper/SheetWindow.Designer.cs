using System.Drawing;
using System.Drawing.Drawing2D;

namespace FFXIV_PerformHelper
{
    partial class SheetWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private const int moveRectHeight = 20;
        private const int timeRectHeight = 5;
        private const int penWitdh = 1;

        private SolidBrush moveRectBrush = new SolidBrush(Color.Black);
        private Pen moveRectPen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), penWitdh)
        {
            LineJoin = LineJoin.Bevel,
        };
        private SolidBrush timeRectBrush = new SolidBrush(Color.White);

        private SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
        private Pen backgroundPen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), penWitdh)
        {
            LineJoin = LineJoin.Bevel,
        };

        private StringFormat centerStringFormat = new StringFormat()
        {
            LineAlignment = StringAlignment.Far,
            Alignment = StringAlignment.Center,
        };
        private StringFormat nearStringFormat = new StringFormat()
        {
            LineAlignment = StringAlignment.Far,
            Alignment = StringAlignment.Near,
        };
        private StringFormat farStringFormat = new StringFormat()
        {
            LineAlignment = StringAlignment.Far,
            Alignment = StringAlignment.Far,
        };

        private Pen textPen = new Pen(Color.FromArgb(0x46, 0x86, 0xa9), penWitdh)
        {
            LineJoin = LineJoin.Round,
        };

        private SolidBrush barBrush = new SolidBrush(Color.FromArgb(0x8, 0x2c, 0x52));
        private Pen barPen = new Pen(Color.FromArgb(0x7b, 0xcf, 0xf7), penWitdh)
        {
            LineJoin = LineJoin.Bevel,
        };
        private Pen barTextPen = new Pen(Color.FromArgb(0x46, 0x86, 0xa9), penWitdh)
        {
            LineJoin = LineJoin.Round,
        };

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            moveRectBrush.Dispose();
            moveRectPen.Dispose();
            timeRectBrush.Dispose();
            backgroundBrush.Dispose();
            backgroundPen.Dispose();
            centerStringFormat.Dispose();
            nearStringFormat.Dispose();
            farStringFormat.Dispose();
            textPen.Dispose();
            barBrush.Dispose();
            barPen.Dispose();
            barTextPen.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SheetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(645, 445);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SheetWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SheetWindow";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Green;
            this.LocationChanged += new System.EventHandler(this.SheetWindow_LocationChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}