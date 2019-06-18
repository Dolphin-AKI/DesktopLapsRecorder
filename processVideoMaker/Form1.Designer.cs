namespace processVideoMaker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_Label_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_worn = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Option = new System.Windows.Forms.ToolStripMenuItem();
            this.option_Versioninfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Option_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.label_savedir = new System.Windows.Forms.Label();
            this.Link_saveDir = new System.Windows.Forms.TextBox();
            this.label_fname = new System.Windows.Forms.Label();
            this.TB_FileName = new System.Windows.Forms.TextBox();
            this.panel_IO = new System.Windows.Forms.Panel();
            this.button_openSaveDir = new System.Windows.Forms.Button();
            this.Button_directrySet = new System.Windows.Forms.Button();
            this.label_startrec = new System.Windows.Forms.Label();
            this.label_stoprec = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_videoSize = new System.Windows.Forms.Label();
            this.label_videoTime = new System.Windows.Forms.Label();
            this.label_recTime = new System.Windows.Forms.Label();
            this.label_pause = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.button_pause = new System.Windows.Forms.Button();
            this.stop_rec = new System.Windows.Forms.Button();
            this.start_rec = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel_IO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Label_status,
            this.toolStripStatusLabel_worn});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // TS_Label_status
            // 
            this.TS_Label_status.Name = "TS_Label_status";
            resources.ApplyResources(this.TS_Label_status, "TS_Label_status");
            // 
            // toolStripStatusLabel_worn
            // 
            this.toolStripStatusLabel_worn.Name = "toolStripStatusLabel_worn";
            resources.ApplyResources(this.toolStripStatusLabel_worn, "toolStripStatusLabel_worn");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_file,
            this.Menu_Option});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // Menu_file
            // 
            this.Menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile_exit});
            this.Menu_file.Name = "Menu_file";
            resources.ApplyResources(this.Menu_file, "Menu_file");
            this.Menu_file.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuFile_exit
            // 
            this.menuFile_exit.Name = "menuFile_exit";
            resources.ApplyResources(this.menuFile_exit, "menuFile_exit");
            this.menuFile_exit.Click += new System.EventHandler(this.menuFile_exit_Click);
            // 
            // Menu_Option
            // 
            this.Menu_Option.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.option_Versioninfo,
            this.toolStripMenuItem_Option_Setting});
            this.Menu_Option.Name = "Menu_Option";
            resources.ApplyResources(this.Menu_Option, "Menu_Option");
            // 
            // option_Versioninfo
            // 
            this.option_Versioninfo.Name = "option_Versioninfo";
            resources.ApplyResources(this.option_Versioninfo, "option_Versioninfo");
            this.option_Versioninfo.Click += new System.EventHandler(this.option_Versioninfo_Click);
            // 
            // toolStripMenuItem_Option_Setting
            // 
            this.toolStripMenuItem_Option_Setting.Name = "toolStripMenuItem_Option_Setting";
            resources.ApplyResources(this.toolStripMenuItem_Option_Setting, "toolStripMenuItem_Option_Setting");
            this.toolStripMenuItem_Option_Setting.Click += new System.EventHandler(this.toolStripMenuItem_Option_Setting_Click);
            // 
            // label_savedir
            // 
            resources.ApplyResources(this.label_savedir, "label_savedir");
            this.label_savedir.Name = "label_savedir";
            // 
            // Link_saveDir
            // 
            resources.ApplyResources(this.Link_saveDir, "Link_saveDir");
            this.Link_saveDir.Name = "Link_saveDir";
            // 
            // label_fname
            // 
            resources.ApplyResources(this.label_fname, "label_fname");
            this.label_fname.Name = "label_fname";
            // 
            // TB_FileName
            // 
            resources.ApplyResources(this.TB_FileName, "TB_FileName");
            this.TB_FileName.Name = "TB_FileName";
            // 
            // panel_IO
            // 
            this.panel_IO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_IO.Controls.Add(this.button_openSaveDir);
            this.panel_IO.Controls.Add(this.label_fname);
            this.panel_IO.Controls.Add(this.TB_FileName);
            this.panel_IO.Controls.Add(this.label_savedir);
            this.panel_IO.Controls.Add(this.Link_saveDir);
            this.panel_IO.Controls.Add(this.Button_directrySet);
            resources.ApplyResources(this.panel_IO, "panel_IO");
            this.panel_IO.Name = "panel_IO";
            // 
            // button_openSaveDir
            // 
            this.button_openSaveDir.BackgroundImage = global::processVideoMaker.Properties.Resources.OpenFolder_32x;
            resources.ApplyResources(this.button_openSaveDir, "button_openSaveDir");
            this.button_openSaveDir.Name = "button_openSaveDir";
            this.button_openSaveDir.UseVisualStyleBackColor = true;
            this.button_openSaveDir.Click += new System.EventHandler(this.button_openSaveDir_Click);
            // 
            // Button_directrySet
            // 
            this.Button_directrySet.BackgroundImage = global::processVideoMaker.Properties.Resources.folder_Open_16xLG;
            resources.ApplyResources(this.Button_directrySet, "Button_directrySet");
            this.Button_directrySet.Name = "Button_directrySet";
            this.Button_directrySet.UseVisualStyleBackColor = true;
            this.Button_directrySet.Click += new System.EventHandler(this.Button_directrySet_Click);
            // 
            // label_startrec
            // 
            resources.ApplyResources(this.label_startrec, "label_startrec");
            this.label_startrec.Name = "label_startrec";
            // 
            // label_stoprec
            // 
            resources.ApplyResources(this.label_stoprec, "label_stoprec");
            this.label_stoprec.Name = "label_stoprec";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label_videoSize);
            this.panel1.Controls.Add(this.label_videoTime);
            this.panel1.Controls.Add(this.label_recTime);
            this.panel1.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label_videoSize
            // 
            resources.ApplyResources(this.label_videoSize, "label_videoSize");
            this.label_videoSize.Name = "label_videoSize";
            // 
            // label_videoTime
            // 
            resources.ApplyResources(this.label_videoTime, "label_videoTime");
            this.label_videoTime.Name = "label_videoTime";
            // 
            // label_recTime
            // 
            resources.ApplyResources(this.label_recTime, "label_recTime");
            this.label_recTime.Name = "label_recTime";
            // 
            // label_pause
            // 
            resources.ApplyResources(this.label_pause, "label_pause");
            this.label_pause.Name = "label_pause";
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // button_pause
            // 
            this.button_pause.BackgroundImage = global::processVideoMaker.Properties.Resources.pause;
            resources.ApplyResources(this.button_pause, "button_pause");
            this.button_pause.Name = "button_pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // stop_rec
            // 
            this.stop_rec.BackgroundImage = global::processVideoMaker.Properties.Resources.rec_stop;
            resources.ApplyResources(this.stop_rec, "stop_rec");
            this.stop_rec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stop_rec.Name = "stop_rec";
            this.stop_rec.UseVisualStyleBackColor = true;
            this.stop_rec.Click += new System.EventHandler(this.stop_rec_Click);
            // 
            // start_rec
            // 
            this.start_rec.BackgroundImage = global::processVideoMaker.Properties.Resources.rec_start;
            resources.ApplyResources(this.start_rec, "start_rec");
            this.start_rec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_rec.Name = "start_rec";
            this.start_rec.UseVisualStyleBackColor = true;
            this.start_rec.Click += new System.EventHandler(this.start_rec_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_pause);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_stoprec);
            this.Controls.Add(this.label_startrec);
            this.Controls.Add(this.panel_IO);
            this.Controls.Add(this.stop_rec);
            this.Controls.Add(this.start_rec);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_IO.ResumeLayout(false);
            this.panel_IO.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_file;
        private System.Windows.Forms.Button start_rec;
        private System.Windows.Forms.Button stop_rec;
        private System.Windows.Forms.Label label_savedir;
        private System.Windows.Forms.TextBox Link_saveDir;
        private System.Windows.Forms.Button Button_directrySet;
        private System.Windows.Forms.Label label_fname;
        private System.Windows.Forms.TextBox TB_FileName;
        private System.Windows.Forms.ToolStripStatusLabel TS_Label_status;
        private System.Windows.Forms.Panel panel_IO;
        private System.Windows.Forms.Button button_openSaveDir;
        private System.Windows.Forms.Label label_startrec;
        private System.Windows.Forms.Label label_stoprec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_videoTime;
        private System.Windows.Forms.Label label_recTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_worn;
        private System.Windows.Forms.Label label_videoSize;
        private System.Windows.Forms.ToolStripMenuItem Menu_Option;
        private System.Windows.Forms.ToolStripMenuItem menuFile_exit;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Label label_pause;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem option_Versioninfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Option_Setting;
    }
}

