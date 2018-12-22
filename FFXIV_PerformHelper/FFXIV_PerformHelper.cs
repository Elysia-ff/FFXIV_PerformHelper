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
        public double GetTimeRatio() { if (sheetData == null) return 0; return ElapsedTime / sheetData.endTime; }

        private SheetData modifiedSheetData;
        private bool isModified;

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

            Stop();
        }

        private void InitializeItems()
        {
            codeComboBox.Items.AddRange(new object[]
            {
                MusicDefine.CodeStr[(int)MusicDefine.Code.C],
                MusicDefine.CodeStr[(int)MusicDefine.Code.CSharp],
                MusicDefine.CodeStr[(int)MusicDefine.Code.D],
                MusicDefine.CodeStr[(int)MusicDefine.Code.EFlat],
                MusicDefine.CodeStr[(int)MusicDefine.Code.E],
                MusicDefine.CodeStr[(int)MusicDefine.Code.F],
                MusicDefine.CodeStr[(int)MusicDefine.Code.FSharp],
                MusicDefine.CodeStr[(int)MusicDefine.Code.G],
                MusicDefine.CodeStr[(int)MusicDefine.Code.GSharp],
                MusicDefine.CodeStr[(int)MusicDefine.Code.A],
                MusicDefine.CodeStr[(int)MusicDefine.Code.BFlat],
                MusicDefine.CodeStr[(int)MusicDefine.Code.B],
                MusicDefine.Code.REST.ToString(),
            });

            octaveComboBox.Items.AddRange(MusicDefine.OctaveStr);
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if (sheetData == null)
                return;

            Play();
        }

        public void Play()
        {
            if (IsPlaying)
                return;

            IsPlaying = true;
            ElapsedTime = 0d;
            SetEditMode(false);

            TimeManager.Reset();
        }

        public void Stop()
        {
            IsPlaying = false;
            SetEditMode(true);
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
                modifiedSheetData = new SheetData(sheetData);

                DrawInfo();
            //}
            //catch
            //{
            //}
        }

        private void DrawInfo()
        {
            nameText.Text = modifiedSheetData.name;
            bpmText.Text = modifiedSheetData.bpm.ToString();

            codeList.Items.Clear();
            List<SheetData.Note> notes = modifiedSheetData.notes;
            for (int i = 0; i < notes.Count; i++)
            {
                codeList.Items.Add(notes[i].str);
            }
        }

        private void CodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = codeList.SelectedIndex;
            SetNoteInfo(idx);
        }

        private void SetNoteInfo(int idx)
        {
            if (idx < 0 || idx >= modifiedSheetData.notes.Count)
            {
                strText.ResetText();
                codeComboBox.ResetText();
                octaveComboBox.ResetText();
                durationText.ResetText();
                return;
            }

            SheetData.Note note = modifiedSheetData.notes[idx];

            strText.Text = note.str;
            codeComboBox.SelectedItem = (note.code == MusicDefine.Code.REST) ? note.code.ToString() : MusicDefine.CodeStr[(int)note.code];
            octaveComboBox.SelectedItem = MusicDefine.OctaveStr[(int)note.octave];
            durationText.Text = note.duration.ToString();
        }

        private void SetEditMode(bool enabled)
        {
            codeComboBox.Enabled = enabled;
            octaveComboBox.Enabled = enabled;
            durationText.Enabled = enabled;

            addBtn.Enabled = enabled;
            insertBtn.Enabled = enabled;
            removeBtn.Enabled = enabled;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SheetData.Note note = SheetData.Note.GetDefault();
            modifiedSheetData.notes.Add(note);
            isModified = true;

            DrawInfo();
            codeList.SelectedIndex = modifiedSheetData.notes.Count - 1;
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (codeList.SelectedIndex < 0)
                return;

            int idx = codeList.SelectedIndex;
            SheetData.Note note = SheetData.Note.GetDefault();
            modifiedSheetData.notes.Insert(idx, note);
            isModified = true;

            DrawInfo();
            codeList.SelectedIndex = idx;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (codeList.SelectedIndex < 0)
                return;

            int idx = codeList.SelectedIndex;
            modifiedSheetData.notes.RemoveAt(idx);
            isModified = true;

            DrawInfo();
            int selectedIdx = Math.Min(codeList.Items.Count - 1, idx);
            codeList.SelectedIndex = selectedIdx;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!isModified)
                return;

            isModified = false;
        }
    }
}
