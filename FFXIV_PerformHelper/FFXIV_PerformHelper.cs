using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private OpenFileDialog openDialog;
        private SaveFileDialog saveDialog;

        private SheetWindow sheetWindow;

        private XmlDocument loadedXML;
        private SheetManager sheetManager;

        private SheetData sheetData;
        public string GetMusicName() { return sheetData.name; }
        public string GetBPM() { return sheetData.bpm.ToString(); }
        public List<Note> GetNotes() { return sheetData.notes; }
        public double GetTimeRatio() { if (sheetData == null) return 0; return ElapsedTime / sheetData.endTime; }

        private SheetData modifiedSheetData;

        public bool IsLoaded { get { return sheetData != null; } }
        public bool IsPlaying { get; private set; }
        public double ElapsedTime { get; private set; }
        public double Speed = 100d;

        private double startTime = 10d;

        public FFXIV_PerformHelper()
        {
            TimeManager = new TimeManager();
            openDialog = new OpenFileDialog()
            {
                Filter = "XML|*.xml",
            };
            saveDialog = new SaveFileDialog()
            {
                Filter = "XML|*.xml",
            };
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
            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //try
            //{
                directoryText.Text = openDialog.FileName;
                loadedXML.Load(openDialog.FileName);
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
            List<Note> notes = modifiedSheetData.notes;
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

            Note note = modifiedSheetData.notes[idx];

            strText.Text = note.str;
            codeComboBox.SelectedItem = (note.code == MusicDefine.Code.REST) ? note.code.ToString() : MusicDefine.CodeStr[(int)note.code];
            octaveComboBox.SelectedItem = MusicDefine.OctaveStr[(int)note.octave];
            durationText.Text = note.duration.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (modifiedSheetData == null)
                return;

            Note note = Note.GetDefault();
            modifiedSheetData.notes.Add(note);

            DrawInfo();
            codeList.SelectedIndex = modifiedSheetData.notes.Count - 1;
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (codeList.SelectedIndex < 0)
                return;

            int idx = codeList.SelectedIndex;
            Note note = Note.GetDefault();
            modifiedSheetData.notes.Insert(idx, note);

            DrawInfo();
            codeList.SelectedIndex = idx;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (codeList.SelectedIndex < 0)
                return;

            int idx = codeList.SelectedIndex;
            modifiedSheetData.notes.RemoveAt(idx);

            DrawInfo();
            int selectedIdx = Math.Min(codeList.Items.Count - 1, idx);
            codeList.SelectedIndex = selectedIdx;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (modifiedSheetData == null)
                return;

            modifiedSheetData.name = nameText.Text;
            modifiedSheetData.bpm = int.Parse(bpmText.Text);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = saveDialog.OpenFile())
                {
                    XmlDocument newDoc = sheetManager.Write(modifiedSheetData);
                    newDoc.Save(stream);
                    stream.Close();
                }
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            if (codeList.SelectedIndex < 0)
                return;

            MusicDefine.Code code = (MusicDefine.Code)codeComboBox.SelectedIndex;
            if (code >= MusicDefine.Code.Count)
                code = MusicDefine.Code.REST;
            MusicDefine.Octave octave = (MusicDefine.Octave)octaveComboBox.SelectedIndex;
            double duration = double.Parse(durationText.Text);
            Note note = new Note(code, octave, duration);

            int idx = codeList.SelectedIndex;
            modifiedSheetData.notes[idx] = note;

            DrawInfo();
            codeList.SelectedIndex = idx;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (codeList.SelectedIndex < 0)
                return;

            int idx = codeList.SelectedIndex;
            SetNoteInfo(idx);
        }

        private void NewFileBtn_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = saveDialog.OpenFile())
                {
                    XmlDocument newDoc = sheetManager.GetDefault();
                    newDoc.Save(stream);
                    stream.Close();
                }
            }
        }
    }
}
