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

        private SheetWindow sheetWindow;

        private XmlDocument loadedXML;
        private SheetManager sheetManager;

        private SheetData sheetData;
        public string GetMusicName() { return sheetData.name; }
        public string GetBPM() { return sheetData.bpm.ToString(); }
        public List<Note> GetNotes() { return sheetData.notes; }
        public double GetTimeRatio() { if (sheetData == null) return 0; return ElapsedTime / sheetData.endTime; }

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
            sheetWindow = new SheetWindow(this)
            {
                Location = Setting.location
            };
            sheetWindow.Show();
            loadedXML = new XmlDocument();
            sheetManager = new SheetManager();

            InitializeComponent();
            InitializeSettings();
            SetEnable();

            TimeManager.OnUpdate += TimeManager_OnUpdate;
        }

        private void InitializeSettings()
        {
            SetLocationText();
            noteSpeedTextBox.Text = Setting.noteSpeed.ToString();
            startDelayTextBox.Text = Setting.startDelay.ToString();

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

            try
            {
                directoryText.Text = openDialog.FileName;
                loadedXML.Load(openDialog.FileName);
                sheetData = sheetManager.Read(loadedXML);
                sheetData.Apply();

                DrawInfo();
                SetEnable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawInfo()
        {
            nameText.Text = GetMusicName();
            bpmText.Text = GetBPM();

            codeList.Items.Clear();
            List<Note> notes = sheetData.notes;
            for (int i = 0; i < notes.Count; i++)
            {
                codeList.Items.Add(notes[i].str);
            }
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
        }

        public void SetLocationText()
        {
            if (locationXTextBox == null || locationYTextBox == null)
                return;

            locationXTextBox.Text = Setting.location.X.ToString();
            locationYTextBox.Text = Setting.location.Y.ToString();
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
                Setting.noteSpeed = v;
            }
        }

        private void StartDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            string value = startDelayTextBox.Text;

            if (double.TryParse(value, out double v))
            {
                Setting.startDelay = v;

                if (sheetData != null)
                    sheetData.Apply();
            }
        }

        private void SaveSettingBtn_Click(object sender, EventArgs e)
        {
            Setting.Save();

            sheetWindow.Location = Setting.location;
            noteSpeedTextBox.Text = Setting.noteSpeed.ToString();
            startDelayTextBox.Text = Setting.startDelay.ToString();
        }

        private void ResetSettingBtn_Click(object sender, EventArgs e)
        {
            Setting.Reset();

            sheetWindow.Location = Setting.location;
            noteSpeedTextBox.Text = Setting.noteSpeed.ToString();
            startDelayTextBox.Text = Setting.startDelay.ToString();
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
