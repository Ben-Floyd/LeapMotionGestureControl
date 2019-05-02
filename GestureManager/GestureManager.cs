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
        private bool _ppActive = Properties.Settings.Default.PowerPointActive,
            _hsActive = Properties.Settings.Default.HandSwipeActive,
            _zActive = Properties.Settings.Default.ZoomActive,
            _lActive = Properties.Settings.Default.LaserActive,
            _olActive = Properties.Settings.Default.OfficeLensActive;
        private int _hsSensitivity = Properties.Settings.Default.HandSwipeSensitivity,
            _zSensitvity = Properties.Settings.Default.ZoomSensitivity;
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
                _olActive = true;
            }
            else
            {
                _olActive = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            HandSwipeSensitivity.Text = HandSwipeSlider.Value.ToString() + "%";
            _hsSensitivity = HandSwipeSlider.Value;
        }

        private void HandSwipeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HandSwipeBox.Checked)
            {
                _hsActive = true;
            }
            else
            {
                _hsActive = false;
            }
        }

        private void ZoomBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ZoomBox.Checked)
            {
                _zActive = true;
            }
            else
            {
                _zActive = false;
            }
        }

        private void LaserBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LaserBox.Checked)
            {
                _lActive = true;
            }
            else
            {
                _lActive = false;
            }
        }

        private void GestureManager_Load(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ZoomSensitivity.Text = ZoomSlider.Value.ToString() + "%";
            _zSensitvity = ZoomSlider.Value;
        }

        private void HandSwipeSensitivity_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (int.TryParse(HandSwipeSensitivity.Text, out value))
            {
                HandSwipeSlider.Value = value;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                HandSwipeBox.Enabled = true;
                HandSwipeSensitivity.Enabled = true;
                HandSwipeSlider.Enabled = true;
                HandSwipeLabel.Enabled = true;

                ZoomBox.Enabled = true;
                ZoomSensitivity.Enabled = true;
                ZoomSlider.Enabled = true;
                ZoomLabel.Enabled = true;

                LaserBox.Enabled = true;

                
            }
            else
            {
                HandSwipeBox.Enabled = false;
                HandSwipeSensitivity.Enabled = false;
                HandSwipeSlider.Enabled = false;
                HandSwipeLabel.Enabled = false;

                ZoomBox.Enabled = false;
                ZoomSensitivity.Enabled = false;
                ZoomSlider.Enabled = false;
                ZoomLabel.Enabled = false;

                LaserBox.Enabled = false;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PowerPointActive = _ppActive;
            Properties.Settings.Default.HandSwipeActive = _hsActive;
            Properties.Settings.Default.HandSwipeSensitivity = _hsSensitivity;
            Properties.Settings.Default.ZoomActive = _zActive;
            Properties.Settings.Default.ZoomSensitivity = _zSensitvity;
            Properties.Settings.Default.LaserActive = _lActive;
            Properties.Settings.Default.OfficeLensActive = _olActive;

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
