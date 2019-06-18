namespace processVideoMaker
{
    partial class Form_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Setting));
            this.label1 = new System.Windows.Forms.Label();
            this.CB_extension = new System.Windows.Forms.ComboBox();
            this.LB_Interval = new System.Windows.Forms.Label();
            this.txtBox_interval = new System.Windows.Forms.TextBox();
            this.LB_interval_ext = new System.Windows.Forms.Label();
            this.LB_quality = new System.Windows.Forms.Label();
            this.trackBar_quality = new System.Windows.Forms.TrackBar();
            this.label_qualityvalue = new System.Windows.Forms.Label();
            this.label_bitrate = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.LB_info = new System.Windows.Forms.Label();
            this.LB_framerate = new System.Windows.Forms.Label();
            this.textBox_fps = new System.Windows.Forms.TextBox();
            this.LB_framerate_ext = new System.Windows.Forms.Label();
            this.button_set = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_recordmode = new System.Windows.Forms.Label();
            this.comboBox_recordMode = new System.Windows.Forms.ComboBox();
            this.trackBar_MotionThrethold = new System.Windows.Forms.TrackBar();
            this.label_motionThrethold = new System.Windows.Forms.Label();
            this.label_motionThreshold_descript = new System.Windows.Forms.Label();
            this.checkBox_insert_dateTime = new System.Windows.Forms.CheckBox();
            this.button_setCaptureWindow = new System.Windows.Forms.Button();
            this.button_capwin_fullscreen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_recordMode = new System.Windows.Forms.GroupBox();
            this.label_motion_detection_threthold_description = new System.Windows.Forms.Label();
            this.label_mode_description = new System.Windows.Forms.Label();
            this.groupBox_Quality = new System.Windows.Forms.GroupBox();
            this.groupBox_process = new System.Windows.Forms.GroupBox();
            this.label_process_time_scale_big = new System.Windows.Forms.Label();
            this.label_process_time_scale_little = new System.Windows.Forms.Label();
            this.label_process_scale = new System.Windows.Forms.Label();
            this.trackBar_process_timeScale = new System.Windows.Forms.TrackBar();
            this.groupBox_standard = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_quality)).BeginInit();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MotionThrethold)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_recordMode.SuspendLayout();
            this.groupBox_Quality.SuspendLayout();
            this.groupBox_process.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_process_timeScale)).BeginInit();
            this.groupBox_standard.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CB_extension
            // 
            resources.ApplyResources(this.CB_extension, "CB_extension");
            this.CB_extension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_extension.FormattingEnabled = true;
            this.CB_extension.Items.AddRange(new object[] {
            resources.GetString("CB_extension.Items"),
            resources.GetString("CB_extension.Items1")});
            this.CB_extension.Name = "CB_extension";
            // 
            // LB_Interval
            // 
            resources.ApplyResources(this.LB_Interval, "LB_Interval");
            this.LB_Interval.Name = "LB_Interval";
            // 
            // txtBox_interval
            // 
            resources.ApplyResources(this.txtBox_interval, "txtBox_interval");
            this.txtBox_interval.Name = "txtBox_interval";
            this.txtBox_interval.TextChanged += new System.EventHandler(this.txtBox_interval_TextChanged);
            this.txtBox_interval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_interval_KeyPress);
            // 
            // LB_interval_ext
            // 
            resources.ApplyResources(this.LB_interval_ext, "LB_interval_ext");
            this.LB_interval_ext.Name = "LB_interval_ext";
            // 
            // LB_quality
            // 
            resources.ApplyResources(this.LB_quality, "LB_quality");
            this.LB_quality.Name = "LB_quality";
            // 
            // trackBar_quality
            // 
            resources.ApplyResources(this.trackBar_quality, "trackBar_quality");
            this.trackBar_quality.LargeChange = 10;
            this.trackBar_quality.Maximum = 1000;
            this.trackBar_quality.Minimum = 1;
            this.trackBar_quality.Name = "trackBar_quality";
            this.trackBar_quality.TickFrequency = 10;
            this.trackBar_quality.Value = 1;
            this.trackBar_quality.Scroll += new System.EventHandler(this.trackBar_quality_Scroll);
            // 
            // label_qualityvalue
            // 
            resources.ApplyResources(this.label_qualityvalue, "label_qualityvalue");
            this.label_qualityvalue.Name = "label_qualityvalue";
            // 
            // label_bitrate
            // 
            resources.ApplyResources(this.label_bitrate, "label_bitrate");
            this.label_bitrate.Name = "label_bitrate";
            this.label_bitrate.Click += new System.EventHandler(this.label_bitrate_Click);
            // 
            // infoPanel
            // 
            resources.ApplyResources(this.infoPanel, "infoPanel");
            this.infoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoPanel.Controls.Add(this.LB_info);
            this.infoPanel.Name = "infoPanel";
            // 
            // LB_info
            // 
            resources.ApplyResources(this.LB_info, "LB_info");
            this.LB_info.Name = "LB_info";
            // 
            // LB_framerate
            // 
            resources.ApplyResources(this.LB_framerate, "LB_framerate");
            this.LB_framerate.Name = "LB_framerate";
            // 
            // textBox_fps
            // 
            resources.ApplyResources(this.textBox_fps, "textBox_fps");
            this.textBox_fps.Name = "textBox_fps";
            this.textBox_fps.TextChanged += new System.EventHandler(this.textBox_fps_TextChanged);
            this.textBox_fps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_fps_KeyPress);
            // 
            // LB_framerate_ext
            // 
            resources.ApplyResources(this.LB_framerate_ext, "LB_framerate_ext");
            this.LB_framerate_ext.Name = "LB_framerate_ext";
            // 
            // button_set
            // 
            resources.ApplyResources(this.button_set, "button_set");
            this.button_set.Name = "button_set";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // button_cancel
            // 
            resources.ApplyResources(this.button_cancel, "button_cancel");
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_recordmode
            // 
            resources.ApplyResources(this.label_recordmode, "label_recordmode");
            this.label_recordmode.Name = "label_recordmode";
            // 
            // comboBox_recordMode
            // 
            resources.ApplyResources(this.comboBox_recordMode, "comboBox_recordMode");
            this.comboBox_recordMode.FormattingEnabled = true;
            this.comboBox_recordMode.Items.AddRange(new object[] {
            resources.GetString("comboBox_recordMode.Items"),
            resources.GetString("comboBox_recordMode.Items1"),
            resources.GetString("comboBox_recordMode.Items2"),
            resources.GetString("comboBox_recordMode.Items3")});
            this.comboBox_recordMode.Name = "comboBox_recordMode";
            this.comboBox_recordMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_recordMode_SelectedIndexChanged);
            // 
            // trackBar_MotionThrethold
            // 
            resources.ApplyResources(this.trackBar_MotionThrethold, "trackBar_MotionThrethold");
            this.trackBar_MotionThrethold.Maximum = 1000;
            this.trackBar_MotionThrethold.Minimum = 1;
            this.trackBar_MotionThrethold.Name = "trackBar_MotionThrethold";
            this.trackBar_MotionThrethold.TickFrequency = 10;
            this.trackBar_MotionThrethold.Value = 1;
            this.trackBar_MotionThrethold.Scroll += new System.EventHandler(this.trackBar_MotionThrethold_Scroll);
            // 
            // label_motionThrethold
            // 
            resources.ApplyResources(this.label_motionThrethold, "label_motionThrethold");
            this.label_motionThrethold.Name = "label_motionThrethold";
            // 
            // label_motionThreshold_descript
            // 
            resources.ApplyResources(this.label_motionThreshold_descript, "label_motionThreshold_descript");
            this.label_motionThreshold_descript.Name = "label_motionThreshold_descript";
            // 
            // checkBox_insert_dateTime
            // 
            resources.ApplyResources(this.checkBox_insert_dateTime, "checkBox_insert_dateTime");
            this.checkBox_insert_dateTime.Name = "checkBox_insert_dateTime";
            this.checkBox_insert_dateTime.UseVisualStyleBackColor = true;
            this.checkBox_insert_dateTime.CheckedChanged += new System.EventHandler(this.checkBox_insert_dateTime_CheckedChanged);
            // 
            // button_setCaptureWindow
            // 
            resources.ApplyResources(this.button_setCaptureWindow, "button_setCaptureWindow");
            this.button_setCaptureWindow.Name = "button_setCaptureWindow";
            this.button_setCaptureWindow.UseVisualStyleBackColor = true;
            this.button_setCaptureWindow.Click += new System.EventHandler(this.button_setCaptureWindow_Click);
            // 
            // button_capwin_fullscreen
            // 
            resources.ApplyResources(this.button_capwin_fullscreen, "button_capwin_fullscreen");
            this.button_capwin_fullscreen.Name = "button_capwin_fullscreen";
            this.button_capwin_fullscreen.UseVisualStyleBackColor = true;
            this.button_capwin_fullscreen.Click += new System.EventHandler(this.button_capwin_fullscreen_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.button_setCaptureWindow);
            this.groupBox1.Controls.Add(this.button_capwin_fullscreen);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox_recordMode
            // 
            resources.ApplyResources(this.groupBox_recordMode, "groupBox_recordMode");
            this.groupBox_recordMode.Controls.Add(this.label_motion_detection_threthold_description);
            this.groupBox_recordMode.Controls.Add(this.label_mode_description);
            this.groupBox_recordMode.Controls.Add(this.trackBar_MotionThrethold);
            this.groupBox_recordMode.Controls.Add(this.label_motionThrethold);
            this.groupBox_recordMode.Controls.Add(this.label_recordmode);
            this.groupBox_recordMode.Controls.Add(this.comboBox_recordMode);
            this.groupBox_recordMode.Controls.Add(this.label_motionThreshold_descript);
            this.groupBox_recordMode.Name = "groupBox_recordMode";
            this.groupBox_recordMode.TabStop = false;
            // 
            // label_motion_detection_threthold_description
            // 
            resources.ApplyResources(this.label_motion_detection_threthold_description, "label_motion_detection_threthold_description");
            this.label_motion_detection_threthold_description.Name = "label_motion_detection_threthold_description";
            // 
            // label_mode_description
            // 
            resources.ApplyResources(this.label_mode_description, "label_mode_description");
            this.label_mode_description.Name = "label_mode_description";
            // 
            // groupBox_Quality
            // 
            resources.ApplyResources(this.groupBox_Quality, "groupBox_Quality");
            this.groupBox_Quality.Controls.Add(this.label_bitrate);
            this.groupBox_Quality.Controls.Add(this.LB_quality);
            this.groupBox_Quality.Controls.Add(this.label_qualityvalue);
            this.groupBox_Quality.Controls.Add(this.trackBar_quality);
            this.groupBox_Quality.Name = "groupBox_Quality";
            this.groupBox_Quality.TabStop = false;
            // 
            // groupBox_process
            // 
            resources.ApplyResources(this.groupBox_process, "groupBox_process");
            this.groupBox_process.Controls.Add(this.label_process_time_scale_big);
            this.groupBox_process.Controls.Add(this.label_process_time_scale_little);
            this.groupBox_process.Controls.Add(this.label_process_scale);
            this.groupBox_process.Controls.Add(this.trackBar_process_timeScale);
            this.groupBox_process.Controls.Add(this.checkBox_insert_dateTime);
            this.groupBox_process.Name = "groupBox_process";
            this.groupBox_process.TabStop = false;
            this.groupBox_process.Enter += new System.EventHandler(this.groupBox_process_Enter);
            // 
            // label_process_time_scale_big
            // 
            resources.ApplyResources(this.label_process_time_scale_big, "label_process_time_scale_big");
            this.label_process_time_scale_big.Name = "label_process_time_scale_big";
            // 
            // label_process_time_scale_little
            // 
            resources.ApplyResources(this.label_process_time_scale_little, "label_process_time_scale_little");
            this.label_process_time_scale_little.Name = "label_process_time_scale_little";
            // 
            // label_process_scale
            // 
            resources.ApplyResources(this.label_process_scale, "label_process_scale");
            this.label_process_scale.Name = "label_process_scale";
            // 
            // trackBar_process_timeScale
            // 
            resources.ApplyResources(this.trackBar_process_timeScale, "trackBar_process_timeScale");
            this.trackBar_process_timeScale.Minimum = 1;
            this.trackBar_process_timeScale.Name = "trackBar_process_timeScale";
            this.trackBar_process_timeScale.Value = 1;
            this.trackBar_process_timeScale.Scroll += new System.EventHandler(this.trackBar_process_timeScale_Scroll);
            // 
            // groupBox_standard
            // 
            resources.ApplyResources(this.groupBox_standard, "groupBox_standard");
            this.groupBox_standard.Controls.Add(this.label1);
            this.groupBox_standard.Controls.Add(this.CB_extension);
            this.groupBox_standard.Controls.Add(this.LB_Interval);
            this.groupBox_standard.Controls.Add(this.txtBox_interval);
            this.groupBox_standard.Controls.Add(this.LB_interval_ext);
            this.groupBox_standard.Controls.Add(this.LB_framerate);
            this.groupBox_standard.Controls.Add(this.textBox_fps);
            this.groupBox_standard.Controls.Add(this.LB_framerate_ext);
            this.groupBox_standard.Name = "groupBox_standard";
            this.groupBox_standard.TabStop = false;
            // 
            // Form_Setting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_standard);
            this.Controls.Add(this.groupBox_process);
            this.Controls.Add(this.groupBox_Quality);
            this.Controls.Add(this.groupBox_recordMode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.infoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Setting";
            this.Load += new System.EventHandler(this.Form_Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_quality)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MotionThrethold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox_recordMode.ResumeLayout(false);
            this.groupBox_recordMode.PerformLayout();
            this.groupBox_Quality.ResumeLayout(false);
            this.groupBox_Quality.PerformLayout();
            this.groupBox_process.ResumeLayout(false);
            this.groupBox_process.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_process_timeScale)).EndInit();
            this.groupBox_standard.ResumeLayout(false);
            this.groupBox_standard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_extension;
        private System.Windows.Forms.Label LB_Interval;
        private System.Windows.Forms.TextBox txtBox_interval;
        private System.Windows.Forms.Label LB_interval_ext;
        private System.Windows.Forms.Label LB_quality;
        private System.Windows.Forms.TrackBar trackBar_quality;
        private System.Windows.Forms.Label label_qualityvalue;
        private System.Windows.Forms.Label label_bitrate;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label LB_info;
        private System.Windows.Forms.Label LB_framerate;
        private System.Windows.Forms.TextBox textBox_fps;
        private System.Windows.Forms.Label LB_framerate_ext;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_recordmode;
        private System.Windows.Forms.ComboBox comboBox_recordMode;
        private System.Windows.Forms.TrackBar trackBar_MotionThrethold;
        private System.Windows.Forms.Label label_motionThrethold;
        private System.Windows.Forms.Label label_motionThreshold_descript;
        private System.Windows.Forms.CheckBox checkBox_insert_dateTime;
        private System.Windows.Forms.Button button_setCaptureWindow;
        private System.Windows.Forms.Button button_capwin_fullscreen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_recordMode;
        private System.Windows.Forms.GroupBox groupBox_Quality;
        private System.Windows.Forms.GroupBox groupBox_process;
        private System.Windows.Forms.GroupBox groupBox_standard;
        private System.Windows.Forms.Label label_mode_description;
        private System.Windows.Forms.Label label_process_scale;
        private System.Windows.Forms.TrackBar trackBar_process_timeScale;
        private System.Windows.Forms.Label label_process_time_scale_big;
        private System.Windows.Forms.Label label_process_time_scale_little;
        private System.Windows.Forms.Label label_motion_detection_threthold_description;
    }
}