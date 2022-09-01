using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ImageProcessor;
using System.Threading;

namespace EffectRemote
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private bool draging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private bool coordinatesChanged = false;
        private int dgr = 0;

        int pitchProofStartPositionX;
        int pitchProofStartPositionY;
        int pitchProofEndPositionY;
        int menuPositionY;
        int pitchProofExitButtonPositionX ;
        int pitchProofExitButtonPositionY;

        int autoPitchStartPositionX;
        int autoPitchEndPositionX;
        int autoPitchStartPositionY;
        int autoPitchExitButtonPositionX;
        int autoPitchExitButtonPositionY;

        Dictionary<int, string> chords = new Dictionary<int, string>()
        {
            {1, "C"},
            {2, "C#"},
            {3, "D"},
            {4, "D#"},
            {5, "E"},
            {6, "F"},
            {7, "F#"},
            {8, "G"},
            {9, "G#"},
            {10, "A"},
            {11, "A#"},
            {12, "B"}
        };
        int chordCounter = 1;
        int mode = 0;

        string selectedChord;
        string SelectedMajorMinor;

        public Form1()
        {
           InitializeComponent();
           this.MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (mode == 0)
                {
                    ChangeChordUp();
                    RotateCircle(true);
                }
                else
                {
                    majorMinorLbl.Text = majorMinorLbl.Equals("MAJOR") ? "MINOR" : "MAJOR";
                }
            }
            else
            {
                if (mode == 0)
                {
                    ChangeChordDown();
                    RotateCircle(false);
                }
                else
                {
                    majorMinorLbl.Text = majorMinorLbl.Equals("MINOR") ? "MAJOR" : "MINOR";
                }
            }
        }

        OutputDevice outputDevice;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadCSVFile();
            chordLbl.Parent = circlePctr;
            chordLbl.BackColor = Color.Transparent;
            this.TopMost = true;
            chordLbl.Location = new Point(1, 1);
            RefreshOutputDevicesList();
        }

        private void RefreshOutputDevicesList()
        {
            List<OutputDevice> outputDevices = new List<OutputDevice>();

            outputDevices = OutputDevice.GetAll().ToList();
            foreach (OutputDevice outputDevice in outputDevices)
            {
                outputDevicesList.Items.Add(outputDevice.Name);
            }
        }

        private void selectDeviceBtn_Click(object sender, EventArgs e)
        {
            SelectDevice();
        }

        private void SelectDevice()
        {
            try
            {
                outputDevice = OutputDevice.GetByName(outputDevicesList.Text);
                MessageBox.Show($"Selected device: { outputDevice.Name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device not selected!");
            }
        }

        private void OpenPitchProof()
        {
            var cMajorTriad = Melanchall.DryWetMidi.MusicTheory.Chord.GetByTriad(NoteName.C, ChordQuality.Major);

            var pattern = new PatternBuilder()
                .Chord(cMajorTriad)
                .Build();

            var midiFile = pattern.ToFile(TempoMap.Default);

            Playback playback = midiFile.GetPlayback(outputDevice);
            playback.Start();
        }

        private void TriggerHarmonyEffect()
        {
            var cMajorTriad = Melanchall.DryWetMidi.MusicTheory.Chord.GetByTriad(NoteName.E, ChordQuality.Major);

            var pattern = new PatternBuilder()
                .Chord(cMajorTriad)
                .Build();

            var midiFile = pattern.ToFile(TempoMap.Default);

            Playback playback = midiFile.GetPlayback(outputDevice);
            playback.Start();
        }

        private void OpenAutoPitch()
        {
            var dMajorTriad = Melanchall.DryWetMidi.MusicTheory.Chord.GetByTriad(NoteName.D, ChordQuality.Major);

            var pattern = new PatternBuilder()
                .Chord(dMajorTriad)
                .Build();

            var midiFile = pattern.ToFile(TempoMap.Default);

            Playback playback = midiFile.GetPlayback(outputDevice);
            playback.Start();
        }

        private void PitchProofSetKey()
        {
            int walk = (pitchProofStartPositionY - pitchProofEndPositionY) / 11;
            
            
            PointConverter pc = new PointConverter();
            Point pt = new Point();
            pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(menuPositionY).ToString()}");

            Cursor.Position = pt;
            MouseClick();

            System.Threading.Thread.Sleep(50);
            switch (selectedChord, SelectedMajorMinor)
            {
                case ("C", "MAJOR") or ("A", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY).ToString()}");
                    break;
                case ("C#", "MAJOR") or ("A#", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 1).ToString()}");
                    break;
                case ("D", "MAJOR") or ("B", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 2).ToString()}");
                    break;
                case ("D#", "MAJOR") or ("C", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 3).ToString()}");
                    break;
                case ("E", "MAJOR") or ("C#", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 4).ToString()}");
                    break;
                case ("F", "MAJOR") or ("D", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 5).ToString()}");
                    break;
                case ("F#", "MAJOR") or ("D#", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 6).ToString()}");
                    break;
                case ("G", "MAJOR") or ("E", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 7).ToString()}");
                    break;
                case ("G#", "MAJOR") or ("F", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 8).ToString()}");
                    break;
                case ("A", "MAJOR") or ("F#", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 9).ToString()}");
                    break;
                case ("A#", "MAJOR") or ("G", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofStartPositionY - walk * 10).ToString()}");
                    break;
                case ("B", "MAJOR") or ("G#", "MINOR"):
                    pt = (Point)pc.ConvertFromString($"{pitchProofStartPositionX.ToString()}, {(pitchProofEndPositionY).ToString()}");
                    break;
            }

            Cursor.Position = pt;
            MouseClick();
            pt = (Point)pc.ConvertFromString($"{pitchProofExitButtonPositionX}, {pitchProofExitButtonPositionY}");
            Cursor.Position = pt;
            MouseClick();
        }

        private void AutoPitchSetKey()
        {
            int walk = (autoPitchEndPositionX - autoPitchStartPositionX)/11;
            
            PointConverter pc = new PointConverter();
            Point pt = new Point();

            switch (selectedChord)
            {
                case ("C"):
                    pt = (Point)pc.ConvertFromString($"{autoPitchStartPositionX.ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("C#"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("D"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*2).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("D#"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*3).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("E"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*4).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("F"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*5).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("F#"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*6).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("G"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*7).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("G#"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*8).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("A"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*9).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("A#"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX+walk*10).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                case ("B"):
                    pt = (Point)pc.ConvertFromString($"{(autoPitchEndPositionX).ToString()}, {(autoPitchStartPositionY).ToString()}");
                    break;
                
            }
            Cursor.Position = pt;
            MouseClick();

            if (SelectedMajorMinor == "MAJOR")
            {
                pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX + walk * 4).ToString()}, {(autoPitchStartPositionY + 50).ToString()}");
                Cursor.Position = pt;
            }
            else
            {
                pt = (Point)pc.ConvertFromString($"{(autoPitchStartPositionX + walk * 7).ToString()}, {(autoPitchStartPositionY + 50).ToString()}");
                Cursor.Position = pt;
            }
            MouseClick();

            pt = (Point)pc.ConvertFromString($"{autoPitchExitButtonPositionX.ToString()}, {autoPitchExitButtonPositionY.ToString()}");
            Cursor.Position = pt;
            System.Threading.Thread.Sleep(50);
            MouseClick();

        }

        private void generateChordBtn_Click(object sender, EventArgs e)
        {
            TriggerHarmonyEffect();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCoordinatesLbl.Text = "x: " + MousePosition.X + " y: " + MousePosition.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            savedCoordinatesLbl.Text = mouseCoordinatesLbl.Text;
        }

        private void MouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void ChangeChordUp()
        {
            chordCounter++;
            if (chordCounter > 12)
                chordCounter = 1;
            chordLbl.Text = chords.GetValueOrDefault(chordCounter);
        }

        private void ChangeChordDown()
        {
            chordCounter--;
            if (chordCounter < 1)
                chordCounter = 12;
            chordLbl.Text = chords.GetValueOrDefault(chordCounter);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ClickEvent(sender, e);
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickEvent(sender, e);
        }

        private void DefultCursurPosition()
        {
            var point = majorMinorLbl.PointToScreen(chordLbl.Location);
            Cursor.Position = point;
        }

        private void calibratePitchProofBtn_Click(object sender, EventArgs e)
        {
            CalibratePitchProof();
        }

        private void CalibratePitchProof()
        {
            int exitButtonLocationX = 0;
            int exitButtonLocationY = 0;

            MessageBox.Show("After message is confirmed, click exit (x) button on PitchProof plugin.");

            while (this == ActiveForm)
            {
                exitButtonLocationX = CursorPosition.GetCursorPosition().X;
                exitButtonLocationY = CursorPosition.GetCursorPosition().Y;
                pitchProofExitButtonPositionX = exitButtonLocationX;
                pitchProofExitButtonPositionY = exitButtonLocationY;
            }

            menuPositionY = exitButtonLocationY + 275;
            pitchProofEndPositionY = exitButtonLocationY + 609;
            pitchProofStartPositionY = exitButtonLocationY + 306;
            pitchProofStartPositionX = exitButtonLocationX - 120;

            coordinatesChanged = true;
            MessageBox.Show("Calibration successful!");
        }

        private void AutoPitchCalibrateBtn_Click(object sender, EventArgs e)
        {
            CalibrateAutoPitch();
        }

        private void CalibrateAutoPitch()
        {
            int exitButtonLocationX = 0;
            int exitButtonLocationY = 0;

            MessageBox.Show("After message is confirmed, click exit (x) button on AutoPitch plugin.");

            while (this == ActiveForm)
            {
                exitButtonLocationX = CursorPosition.GetCursorPosition().X;
                exitButtonLocationY = CursorPosition.GetCursorPosition().Y;
                autoPitchExitButtonPositionX = exitButtonLocationX;
                autoPitchExitButtonPositionY = exitButtonLocationY;
            }

            autoPitchStartPositionY = autoPitchExitButtonPositionY + 382;
            autoPitchEndPositionX = autoPitchExitButtonPositionX - 393;
            autoPitchStartPositionX = autoPitchExitButtonPositionX - 1051;
            
            coordinatesChanged = true;
            MessageBox.Show("Calibration successful!");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

            if (coordinatesChanged)
            {
                var result = MessageBox.Show("Do you want to save changes?","Save changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    WriteCSVFIle();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.Close();
        }

        private void minimiseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dragPnl_MouseDown(object sender, MouseEventArgs e)
        {
            draging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void dragPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (draging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void dragPnl_MouseUp(object sender, MouseEventArgs e)
        {
            draging = false;
        }

        private void exitBtn_MouseMove(object sender, MouseEventArgs e)
        {
            exitBtn.BackColor = Color.FromArgb(226, 106, 82);

        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Transparent;

        }

        private void minimiseButton_MouseEnter(object sender, EventArgs e)
        {
            minimiseButton.BackColor = Color.FromArgb(79, 145, 141);
        }

        private void minimiseButton_MouseLeave(object sender, EventArgs e)
        {
            minimiseButton.BackColor = Color.Transparent;
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                if (mode == 0)
                {
                    chordLbl.ForeColor = Color.FromArgb(79, 145, 141);
                    majorMinorLbl.ForeColor = Color.FromArgb(226, 106, 82);
                    mode = 1;
                    selectedChord = chordLbl.Text;
                }
                else
                {
                    chordLbl.ForeColor = Color.FromArgb(226, 106, 82);
                    majorMinorLbl.ForeColor = Color.FromArgb(79, 145, 141);
                    mode = 0;
                    SelectedMajorMinor = majorMinorLbl.Text;
                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                try
                {
                    TriggerHarmonyEffect();
                }
                catch
                {
                    MessageBox.Show("Output device probably not selected!");
                }
            }
        }

        private void DoubleClickEvent(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                try
                {
                    OpenPitchProof();
                    System.Threading.Thread.Sleep(200);
                    PitchProofSetKey();
                    System.Threading.Thread.Sleep(200);
                    OpenAutoPitch();
                    System.Threading.Thread.Sleep(200);
                    AutoPitchSetKey();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Output device probably not selected!");
                }
            }
            System.Threading.Thread.Sleep(100);
            DefultCursurPosition();
        }

        private void chordLbl_Click(object sender, EventArgs e)
        {
            ClickEvent(sender, e);
        }

        private void chordLbl_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickEvent(sender, e);
        }

        private void majorMinorLbl_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickEvent(sender, e);
        }

        private void majorMinorLbl_Click(object sender, EventArgs e)
        {
            ClickEvent(sender, e);
        }

        private void outputDevicesList_DoubleClick(object sender, EventArgs e)
        {
            SelectDevice();
        }

        private void selectDeviceBtn_MouseEnter(object sender, EventArgs e)
        {
            selectDeviceBtn.FlatAppearance.BorderSize = 3;
        }

        private void calibratePitchProofBtn_MouseEnter(object sender, EventArgs e)
        {
            calibratePitchProofBtn.FlatAppearance.BorderSize = 3;
        }

        private void calibrateAutoPitchBtn_MouseEnter(object sender, EventArgs e)
        {
            calibrateAutoPitchBtn.FlatAppearance.BorderSize = 3;
        }

        private void selectDeviceBtn_MouseLeave(object sender, EventArgs e)
        {
            selectDeviceBtn.FlatAppearance.BorderSize = 0;
        }

        private void calibratePitchProofBtn_MouseLeave(object sender, EventArgs e)
        {
            calibratePitchProofBtn.FlatAppearance.BorderSize = 0;
        }

        private void calibrateAutoPitchBtn_MouseLeave(object sender, EventArgs e)
        {
            calibrateAutoPitchBtn.FlatAppearance.BorderSize = 0;
        }

        private void WriteCSVFIle()
        {
            try
                {
                File.WriteAllText(@"../../../Resources/coordinates.csv", $"{pitchProofStartPositionX},{pitchProofStartPositionY},{pitchProofEndPositionY},{menuPositionY},{pitchProofExitButtonPositionX},{pitchProofExitButtonPositionY}\n" +
                $"{autoPitchStartPositionX},{autoPitchEndPositionX},{autoPitchStartPositionY},{autoPitchExitButtonPositionX},{autoPitchExitButtonPositionY}");
                }
            catch (Exception e)
            { 
                MessageBox.Show("Can not write to file!");
            }
        }

        private void ReadCSVFile()
        {
            try
            {
                var file = File.ReadAllLines(@"../../../Resources/coordinates.csv");
                string[] pitchProofValuesString = file[0].Split(',');
                string[] autoPitchValuesString = file[1].Split(',');
                int[] pitchProofValues = Array.ConvertAll(pitchProofValuesString, s => int.Parse(s));
                int[] autoPitchValues = Array.ConvertAll(autoPitchValuesString, s => int.Parse(s));

                pitchProofStartPositionX = pitchProofValues[0];
                pitchProofStartPositionY = pitchProofValues[1];
                pitchProofEndPositionY = pitchProofValues[2];
                menuPositionY = pitchProofValues[3];
                pitchProofExitButtonPositionX = pitchProofValues[4];
                pitchProofExitButtonPositionY = pitchProofValues[5];

                autoPitchStartPositionX = autoPitchValues[0];
                autoPitchEndPositionX = autoPitchValues[1];
                autoPitchStartPositionY = autoPitchValues[2];
                autoPitchExitButtonPositionX = autoPitchValues[3];
                autoPitchExitButtonPositionY = autoPitchValues[4];
            }
            catch (Exception e)
            {
                MessageBox.Show("Can not read data from file!");
            }
        }

        private void RotateCircle(bool direction)
        {
            if (dgr == 360)
                dgr = 0;

            if (direction)
                dgr += 30;
            else
            {
                dgr = dgr == 0 ? 345 : dgr - 30;
            }

            new Thread(() =>
            {
                //Thread.CurrentThread.IsBackground = true;
                ImageFactory imageFactory = new ImageFactory();
                imageFactory.Load(@"../../../Resources/Circle_PNG.png");
                imageFactory.Rotate(dgr);
                circlePctr.Image = imageFactory.Image;
            }).Start();
        }
    }
}
