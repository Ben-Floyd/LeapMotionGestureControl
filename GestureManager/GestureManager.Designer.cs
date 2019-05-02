namespace LeapMotionGestureManager
{
    partial class GestureManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestureManager));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LensBox = new System.Windows.Forms.CheckBox();
            this.HandSwipeBox = new System.Windows.Forms.CheckBox();
            this.ZoomBox = new System.Windows.Forms.CheckBox();
            this.LaserBox = new System.Windows.Forms.CheckBox();
            this.HandSwipeSlider = new System.Windows.Forms.TrackBar();
            this.ZoomSlider = new System.Windows.Forms.TrackBar();
            this.HandSwipeLabel = new System.Windows.Forms.Label();
            this.ZoomLabel = new System.Windows.Forms.Label();
            this.HandSwipeSensitivity = new System.Windows.Forms.TextBox();
            this.ZoomSensitivity = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HandSwipeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ZoomSensitivity);
            this.panel1.Controls.Add(this.HandSwipeSensitivity);
            this.panel1.Controls.Add(this.ZoomLabel);
            this.panel1.Controls.Add(this.HandSwipeLabel);
            this.panel1.Controls.Add(this.ZoomSlider);
            this.panel1.Controls.Add(this.HandSwipeSlider);
            this.panel1.Controls.Add(this.LaserBox);
            this.panel1.Controls.Add(this.ZoomBox);
            this.panel1.Controls.Add(this.HandSwipeBox);
            this.panel1.Location = new System.Drawing.Point(61, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 492);
            this.panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(335, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(210, 36);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Leap Motion";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // LensBox
            // 
            this.LensBox.AutoSize = true;
            this.LensBox.Checked = true;
            this.LensBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LensBox.Location = new System.Drawing.Point(973, 328);
            this.LensBox.Name = "LensBox";
            this.LensBox.Size = new System.Drawing.Size(213, 36);
            this.LensBox.TabIndex = 3;
            this.LensBox.Text = "Office Lense";
            this.LensBox.UseVisualStyleBackColor = true;
            this.LensBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged_1);
            // 
            // HandSwipeBox
            // 
            this.HandSwipeBox.AutoSize = true;
            this.HandSwipeBox.Checked = true;
            this.HandSwipeBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HandSwipeBox.Location = new System.Drawing.Point(62, 78);
            this.HandSwipeBox.Name = "HandSwipeBox";
            this.HandSwipeBox.Size = new System.Drawing.Size(361, 36);
            this.HandSwipeBox.TabIndex = 4;
            this.HandSwipeBox.Text = "Next Slide (Hand Swipe)";
            this.HandSwipeBox.UseVisualStyleBackColor = true;
            this.HandSwipeBox.CheckedChanged += new System.EventHandler(this.HandSwipeBox_CheckedChanged);
            // 
            // ZoomBox
            // 
            this.ZoomBox.AutoSize = true;
            this.ZoomBox.Checked = true;
            this.ZoomBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ZoomBox.Location = new System.Drawing.Point(62, 250);
            this.ZoomBox.Name = "ZoomBox";
            this.ZoomBox.Size = new System.Drawing.Size(403, 36);
            this.ZoomBox.TabIndex = 5;
            this.ZoomBox.Text = "All Slide View (Pinch Zoom)";
            this.ZoomBox.UseVisualStyleBackColor = true;
            this.ZoomBox.CheckedChanged += new System.EventHandler(this.ZoomBox_CheckedChanged);
            // 
            // LaserBox
            // 
            this.LaserBox.AutoSize = true;
            this.LaserBox.Checked = true;
            this.LaserBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LaserBox.Location = new System.Drawing.Point(62, 419);
            this.LaserBox.Name = "LaserBox";
            this.LaserBox.Size = new System.Drawing.Size(393, 36);
            this.LaserBox.TabIndex = 6;
            this.LaserBox.Text = "Laser Pointer (Screen Tap)";
            this.LaserBox.UseVisualStyleBackColor = true;
            this.LaserBox.CheckedChanged += new System.EventHandler(this.LaserBox_CheckedChanged);
            // 
            // HandSwipeSlider
            // 
            this.HandSwipeSlider.Location = new System.Drawing.Point(169, 130);
            this.HandSwipeSlider.Maximum = 100;
            this.HandSwipeSlider.Name = "HandSwipeSlider";
            this.HandSwipeSlider.Size = new System.Drawing.Size(474, 114);
            this.HandSwipeSlider.SmallChange = 5;
            this.HandSwipeSlider.TabIndex = 7;
            this.HandSwipeSlider.Value = 50;
            this.HandSwipeSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // ZoomSlider
            // 
            this.ZoomSlider.Location = new System.Drawing.Point(169, 299);
            this.ZoomSlider.Maximum = 100;
            this.ZoomSlider.Name = "ZoomSlider";
            this.ZoomSlider.Size = new System.Drawing.Size(474, 114);
            this.ZoomSlider.TabIndex = 8;
            this.ZoomSlider.Value = 50;
            this.ZoomSlider.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // HandSwipeLabel
            // 
            this.HandSwipeLabel.AutoSize = true;
            this.HandSwipeLabel.Location = new System.Drawing.Point(18, 147);
            this.HandSwipeLabel.Name = "HandSwipeLabel";
            this.HandSwipeLabel.Size = new System.Drawing.Size(145, 32);
            this.HandSwipeLabel.TabIndex = 9;
            this.HandSwipeLabel.Text = "Sensitivity";
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.AutoSize = true;
            this.ZoomLabel.Location = new System.Drawing.Point(18, 321);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(145, 32);
            this.ZoomLabel.TabIndex = 10;
            this.ZoomLabel.Text = "Sensitivity";
            // 
            // HandSwipeSensitivity
            // 
            this.HandSwipeSensitivity.AcceptsReturn = true;
            this.HandSwipeSensitivity.Location = new System.Drawing.Point(659, 147);
            this.HandSwipeSensitivity.Name = "HandSwipeSensitivity";
            this.HandSwipeSensitivity.Size = new System.Drawing.Size(100, 38);
            this.HandSwipeSensitivity.TabIndex = 11;
            this.HandSwipeSensitivity.Text = "50%";
            this.HandSwipeSensitivity.TextChanged += new System.EventHandler(this.HandSwipeSensitivity_TextChanged);
            // 
            // ZoomSensitivity
            // 
            this.ZoomSensitivity.Location = new System.Drawing.Point(649, 315);
            this.ZoomSensitivity.Name = "ZoomSensitivity";
            this.ZoomSensitivity.Size = new System.Drawing.Size(100, 38);
            this.ZoomSensitivity.TabIndex = 12;
            this.ZoomSensitivity.Text = "50%";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(1194, 633);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(107, 50);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(1009, 630);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(138, 50);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GestureManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1326, 692);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.LensBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestureManager";
            this.Text = "Leap Gesture Manager";
            this.Load += new System.EventHandler(this.GestureManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HandSwipeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox LensBox;
        private System.Windows.Forms.CheckBox LaserBox;
        private System.Windows.Forms.CheckBox ZoomBox;
        private System.Windows.Forms.CheckBox HandSwipeBox;
        private System.Windows.Forms.TrackBar ZoomSlider;
        private System.Windows.Forms.TrackBar HandSwipeSlider;
        private System.Windows.Forms.Label HandSwipeLabel;
        private System.Windows.Forms.TextBox ZoomSensitivity;
        private System.Windows.Forms.TextBox HandSwipeSensitivity;
        private System.Windows.Forms.Label ZoomLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}

