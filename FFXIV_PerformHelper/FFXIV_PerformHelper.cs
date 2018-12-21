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
        public TimeManager TimeManager { get; private set; }
        private OpenFileDialog fileDialog;
        private SheetWindow sheetWindow;
        private SheetReader xmlReader;
        private SheetData sheetData;
        public List<SheetData.Note> GetNotes() { return sheetData.notes; }
        public SheetData.Note GetNote(int idx) { return sheetData.notes[idx]; }

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

            if (IsPlaying)
                ElapsedTime += TimeManager.DeltaTime;
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                directoryText.Text = fileDialog.FileName;
                xmlReader = new SheetReader();
                xmlReader.Initialize(fileDialog.FileName);
                sheetData = xmlReader.Read();
                sheetData.Apply(startTime);

                DrawInfo();
            }
            catch
            {
            }
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
