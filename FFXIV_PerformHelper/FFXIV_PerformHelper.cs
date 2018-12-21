using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FFXIV_PerformHelper
{
    public partial class FFXIV_PerformHelper : Form
    {
        public TimeManager TimeManager { get; private set; }
        private OpenFileDialog fileDialog;

        private SheetWindow sheetWindow;

        private XmlDocument loadedXML;
        private SheetManager sheetManager;

        private SheetData sheetData;
        public List<SheetData.Note> GetNotes() { return sheetData.notes; }
        public SheetData.Note GetNote(int idx) { return sheetData.notes[idx]; }
        public double GetTimeRatio() { if (sheetData == null) return 0; return ElapsedTime / sheetData.endTime; }

        public bool IsPlaying { get; private set; }
        public double ElapsedTime { get; private set; }
        public double Speed = 100d;

        private double startTime = 10d;

        public FFXIV_PerformHelper()
        {
            TimeManager = new TimeManager();
            fileDialog = new OpenFileDialog();
            sheetWindow = new SheetWindow(this)
            {
                Top = 398,
                Left = 759
            };
            sheetWindow.Show();
            loadedXML = new XmlDocument();
            sheetManager = new SheetManager();

            InitializeComponent();
            InitializeItems();

            TimeManager.OnUpdate += TimeManager_OnUpdate;
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

            double t = GetTimeRatio();
            int value = MathExtension.Lerp(0, 100, t);
            progressBar.Value = value;

            if (IsPlaying)
                ElapsedTime += TimeManager.DeltaTime;
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //try
            //{
                directoryText.Text = fileDialog.FileName;
                loadedXML.Load(fileDialog.FileName);
                sheetData = sheetManager.Read(loadedXML);
                sheetData.Apply(startTime);

                DrawInfo();
            //}
            //catch
            //{
            //}
        }

        private void DrawInfo()
        {
            nameText.Text = sheetData.name;
            bpmText.Text = sheetData.bpm.ToString();

            List<SheetData.Note> notes = GetNotes();
            for (int i = 0; i < notes.Count; i++)
            {
                codeList.Items.Add(notes[i].str);
            }
        }
    }
}
