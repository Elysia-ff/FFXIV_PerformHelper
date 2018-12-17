using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIV_PerformHelper
{
    public partial class FFXIV_PerformHelper : Form
    {
        private static object lockObject = new object();

        public TimeManager TimeManager { get; private set; }
        private OpenFileDialog fileDialog;
        private SheetWindow sheetWindow;
        private SheetReader xmlReader;
        private SheetData sheetData;
        public List<SheetData.Note> GetNotes() { return sheetData.notes; }

        public bool IsPlaying { get; private set; }
        public double ElapsedTime { get; private set; }
        public double Speed = 100d;

        private double startTime = 10d;

        public FFXIV_PerformHelper()
        {
            TimeManager = new TimeManager();
            sheetWindow = new SheetWindow(this)
            {
                Top = 398,
                Left = 759
            };
            sheetWindow.Show();

            InitializeComponent();

            Shown += FFXIV_PerformHelper_Shown;
            TimeManager.OnUpdate += TimeManager_OnUpdate;
        }

        private void FFXIV_PerformHelper_Shown(object sender, EventArgs e)
        {
            //try
            {
                fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                xmlReader = new SheetReader();
                xmlReader.Initialize(fileDialog.FileName);
                sheetData = xmlReader.Read();
                sheetData.Apply(startTime);

                Play();
            }
            //catch (Exception error)
            //{
            //    label1.Text = error.ToString();
            //}
        }

        public void Play()
        {
            if (IsPlaying)
                return;

            IsPlaying = true;
            ElapsedTime = 0d;

            TimeManager.Reset();
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        private void TimeManager_OnUpdate()
        {
            sheetWindow.Refresh();

            if (IsPlaying)
                ElapsedTime += TimeManager.DeltaTime;
        }
    }
}
