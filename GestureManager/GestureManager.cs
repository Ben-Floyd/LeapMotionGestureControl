using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeapMotionGestureManager
{
    public partial class GestureManager : Form
    {
        private static int _hsSen = Properties.Settings.Default.HandSwipeSensitivity;

        public static bool PowerPointActive
        {
            get { return Properties.Settings.Default.PowerPointActive; }
        }

        public static bool HandSwipeActive
        {
            get { return Properties.Settings.Default.HandSwipeActive; }
        }

        public static bool ZoomActive
        {
            get { return Properties.Settings.Default.ZoomActive; }
        }

        public static bool LazerActive
        {
            get { return Properties.Settings.Default.LazerActive; }
        }

        public static bool OfficeLensActive
        {
            get { return Properties.Settings.Default.OfficeLensActive; }
        }

        public static int HandSwipeSensitivity
        {
            set { Properties.Settings.Default.HandSwipeSensitivity = value; }
        }

        public static int ZoomSensitivity
        {
            get { return Properties.Settings.Default.ZoomSensitivity; }
        }

        public GestureManager()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (LensBox.Checked)
            {
                Properties.Settings.Default.OfficeLensActive = true;
            }
            else
            {
                Properties.Settings.Default.OfficeLensActive = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            HandSwipeText.Text = HandSwipeSlider.Value.ToString() + "%";
            Properties.Settings.Default.HandSwipeSensitivity = HandSwipeSlider.Value;
        }

        private void HandSwipeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HandSwipeBox.Checked)
            {
                Properties.Settings.Default.HandSwipeActive = true;
                HandSwipeLabel.Enabled = true;
                HandSwipeSlider.Enabled = true;
                HandSwipeText.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.HandSwipeActive = false;
                HandSwipeLabel.Enabled = false;
                HandSwipeSlider.Enabled = false;
                HandSwipeText.Enabled = false;
            }
        }

        private void ZoomBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZoomBox.Checked)
            {
                Properties.Settings.Default.ZoomActive = true;
                ZoomSlider.Enabled = true;
                ZoomLabel.Enabled = true;
                ZoomText.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.ZoomActive = false;
                ZoomSlider.Enabled = false;
                ZoomLabel.Enabled = false;
                ZoomText.Enabled = false;
            }
        }

        private void LaserBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LaserBox.Checked)
            {
                Properties.Settings.Default.LazerActive = true;
            }
            else
            {
                Properties.Settings.Default.LazerActive = false;
            }
        }

        private void GestureManager_Load(object sender, EventArgs e)
        {
            HandSwipeSlider.Value = Properties.Settings.Default.HandSwipeSensitivity;
            HandSwipeText.Text = Properties.Settings.Default.HandSwipeSensitivity.ToString() + "%";
            if (!Properties.Settings.Default.HandSwipeActive)
            {
                HandSwipeBox.Checked = false;
                HandSwipeLabel.Enabled = false;
                HandSwipeSlider.Enabled = false;
                HandSwipeText.Enabled = false;
            }

            ZoomSlider.Value = Properties.Settings.Default.ZoomSensitivity;
            ZoomText.Text = Properties.Settings.Default.ZoomSensitivity.ToString() + "%";
            if (!Properties.Settings.Default.ZoomActive)
            {
                ZoomBox.Checked = false;
                ZoomLabel.Enabled = false;
                ZoomSlider.Enabled = false;
                ZoomText.Enabled = false;
            }

            LaserBox.Checked = Properties.Settings.Default.LazerActive;

            LensBox.Checked = Properties.Settings.Default.OfficeLensActive;

            if (!PowerPointActive)
            {
                LeapBox.Checked = false;
                HandSwipeBox.Enabled = false;
                HandSwipeText.Enabled = false;
                HandSwipeSlider.Enabled = false;
                HandSwipeLabel.Enabled = false;

                ZoomBox.Enabled = false;
                ZoomText.Enabled = false;
                ZoomSlider.Enabled = false;
                ZoomLabel.Enabled = false;

                LaserBox.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ZoomText.Text = ZoomSlider.Value.ToString() + "%";
            Properties.Settings.Default.ZoomSensitivity = ZoomSlider.Value;
        }

        private void HandSwipeSensitivity_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(HandSwipeText.Text, out value))
            {
                HandSwipeSlider.Value = value;
                Properties.Settings.Default.HandSwipeSensitivity = value;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (LeapBox.Checked)
            {
                HandSwipeBox.Enabled = true;
                HandSwipeText.Enabled = true;
                HandSwipeSlider.Enabled = true;
                HandSwipeLabel.Enabled = true;

                ZoomBox.Enabled = true;
                ZoomText.Enabled = true;
                ZoomSlider.Enabled = true;
                ZoomLabel.Enabled = true;

                LaserBox.Enabled = true;

                Properties.Settings.Default.PowerPointActive = true;
            }
            else
            {
                HandSwipeBox.Enabled = false;
                HandSwipeText.Enabled = false;
                HandSwipeSlider.Enabled = false;
                HandSwipeLabel.Enabled = false;

                ZoomBox.Enabled = false;
                ZoomText.Enabled = false;
                ZoomSlider.Enabled = false;
                ZoomLabel.Enabled = false;

                LaserBox.Enabled = false;

                Properties.Settings.Default.PowerPointActive = false;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _hsSen = Properties.Settings.Default.HandSwipeSensitivity;
            System.Diagnostics.Debug.WriteLine(_hsSen.ToString());
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZoomText_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(ZoomText.Text, out value))
            {
                ZoomSlider.Value = value;
                Properties.Settings.Default.ZoomSensitivity = value;
            }
        }
    }
}
