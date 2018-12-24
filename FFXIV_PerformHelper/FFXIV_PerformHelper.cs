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

        public FFXIV_PerformHelper()
        {
            Setting.Initialize();
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
                Location = Properties.Settings.Default.Location
            };
            sheetWindow.Show();
            loadedXML = new XmlDocument();
            sheetManager = new SheetManager();

            InitializeComponent();
            InitializeItems();
            InitializeSettings();
            SetEnable();

            TimeManager.OnUpdate += TimeManager_OnUpdate;
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

        private void InitializeSettings()
        {
            SetLocationText(sheetWindow.Location);
            noteSpeedTextBox.Text = Properties.Settings.Default.NoteSpeed.ToString();
            startDelayTextBox.Text = Properties.Settings.Default.StartDelay.ToString();

            cTextBox.Text = Setting.barX[0].ToString();
            cSharpTextBox.Text = Setting.barX[1].ToString();
            dTextBox.Text = Setting.barX[2].ToString();
            eFlatTextBox.Text = Setting.barX[3].ToString();
            eTextBox.Text = Setting.barX[4].ToString();
            fTextBox.Text = Setting.barX[5].ToString();
            fSharpTextBox.Text = Setting.barX[6].ToString();
            gTextBox.Text = Setting.barX[7].ToString();
            gSharpTextBox.Text = Setting.barX[8].ToString();
            aTextBox.Text = Setting.barX[9].ToString();
            bFlatTextBox.Text = Setting.barX[10].ToString();
            bTextBox.Text = Setting.barX[11].ToString();
            highCTextBox.Text = Setting.barX[12].ToString();
            widthTextBox.Text = Setting.width.ToString();
            heightTextBox.Text = Setting.height.ToString();
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
            {
                Stop();
                return;
            }

            IsPlaying = true;
            SetEnable();
            ElapsedTime = 0d;
            TimeManager.Reset();
        }

        public void Stop()
        {
            IsPlaying = false;
            SetEnable();
        }

        private void TimeManager_OnUpdate()
        {
            sheetWindow.Refresh();

            if (IsPlaying)
            {
                double t = GetTimeRatio();
                int value = MathExtension.Lerp(0, 100, t);
                progressBar.Value = value;

                ElapsedTime += TimeManager.DeltaTime;
            }
            else
            {
                progressBar.Value = 0;
            }
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
                sheetData.Apply();
                modifiedSheetData = new SheetData(sheetData);

                DrawInfo();
                SetEnable();
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

                SetEnable();
                return;
            }

            Note note = modifiedSheetData.notes[idx];

            strText.Text = note.str;
            codeComboBox.SelectedItem = (note.code == MusicDefine.Code.REST) ? note.code.ToString() : MusicDefine.CodeStr[(int)note.code];
            octaveComboBox.SelectedItem = MusicDefine.OctaveStr[(int)note.octave];
            durationText.Text = note.duration.ToString();

            SetEnable();
        }

        private void SetEnable()
        {
            browseBtn.Enabled = !IsPlaying;
            playBtn.Text = IsPlaying ? "STOP" : "PLAY";
            noteSpeedTextBox.Enabled = !IsPlaying;
            startDelayTextBox.Enabled = !IsPlaying;
            resetSettingBtn.Enabled = !IsPlaying;

            bool showMainInfo = sheetData != null && !IsPlaying;
            nameText.Enabled = showMainInfo;
            bpmText.Enabled = showMainInfo;
            codeList.Enabled = showMainInfo;
            addBtn.Enabled = showMainInfo;
            insertBtn.Enabled = showMainInfo;
            removeBtn.Enabled = showMainInfo;
            saveBtn.Enabled = showMainInfo;

            bool showCodeInfo = codeList.SelectedIndex >= 0 && codeList.SelectedIndex < codeList.Items.Count && !IsPlaying;
            codeComboBox.Enabled = showCodeInfo;
            octaveComboBox.Enabled = showCodeInfo;
            durationText.Enabled = showCodeInfo;
            applyBtn.Enabled = showCodeInfo;
            resetBtn.Enabled = showCodeInfo;
        }

        private void BPMText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string value = bpmText.Text;

            if (!int.TryParse(value, out int v))
                e.Cancel = true;
        }

        private void CodeComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string value = codeComboBox.Text;

            if (!codeComboBox.Items.Contains(value))
                e.Cancel = true;
        }

        private void OctaveComboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string value = octaveComboBox.Text;

            if (!octaveComboBox.Items.Contains(value))
                e.Cancel = true;
        }

        private void DurationText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string value = durationText.Text;

            if (!double.TryParse(value, out double v))
                e.Cancel = true;
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

        public void SetLocationText(Point point)
        {
            if (locationXTextBox == null || locationYTextBox == null)
                return;

            locationXTextBox.Text = point.X.ToString();
            locationYTextBox.Text = point.Y.ToString();
        }

        private void LocationXTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = locationXTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Point point = sheetWindow.Location;
                point.X = v;
                sheetWindow.Location = point;
            }
        }

        private void LocationYTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = locationYTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Point point = sheetWindow.Location;
                point.Y = v;
                sheetWindow.Location = point;
            }
        }

        private void NoteSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = noteSpeedTextBox.Text;

            if (double.TryParse(value, out double v))
            {
                Properties.Settings.Default.NoteSpeed = v;
            }
        }

        private void StartDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = startDelayTextBox.Text;

            if (double.TryParse(value, out double v))
            {
                Properties.Settings.Default.StartDelay = v;

                if (sheetData != null)
                    sheetData.Apply();
            }
        }

        private void SaveSettingBtn_Click(object sender, EventArgs e)
        {
            Setting.Save();

            sheetWindow.Location = Properties.Settings.Default.Location;
            noteSpeedTextBox.Text = Properties.Settings.Default.NoteSpeed.ToString();
            startDelayTextBox.Text = Properties.Settings.Default.StartDelay.ToString();
        }

        private void ResetSettingBtn_Click(object sender, EventArgs e)
        {
            Setting.Reset();

            sheetWindow.Location = Properties.Settings.Default.Location;
            noteSpeedTextBox.Text = Properties.Settings.Default.NoteSpeed.ToString();
            startDelayTextBox.Text = Properties.Settings.Default.StartDelay.ToString();
            InitializeSettings();
            sheetWindow.ResizeWindow();
        }

        private void CTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = cTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[0] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void CSharpTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = cSharpTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[1] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void DTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = dTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[2] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void EFlatTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = eFlatTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[3] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void ETextBox_TextChanged(object sender, EventArgs e)
        {
            string value = eTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[4] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void FTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = fTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[5] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void FSharpTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = fSharpTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[6] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void GTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = gTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[7] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void GSharpTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = gSharpTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[8] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void ATextBox_TextChanged(object sender, EventArgs e)
        {
            string value = aTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[9] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void BFlatTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = bFlatTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[10] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void BTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = bTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[11] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void HighCTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = highCTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.barX[12] = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void WidthText_TextChanged(object sender, EventArgs e)
        {
            string value = widthTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.width = v;
                sheetWindow.ResizeWindow();
            }
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = heightTextBox.Text;

            if (int.TryParse(value, out int v))
            {
                Setting.height = v;
                sheetWindow.ResizeWindow();
            }
        }
    }
}
