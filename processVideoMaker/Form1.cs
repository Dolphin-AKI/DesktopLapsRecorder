#define FFMPEG
//今後はFFMPEGを使用しましょー


using System;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Collections;


#if VFW
using AForge.Video.VFW;
#elif FFMPEG
using AForge.Video.FFMPEG;
#endif


namespace processVideoMaker
{
    /// <summary>
    /// ラプスレコーダーの通常ウィンドウ
    /// 各コントロールを行う
    /// </summary>
    public partial class Form1 : Form
    {

        System.Timers.Timer lapsTimer;
        Stopwatch recordingTimer;
        System.Timers.Timer SleepDeterrence;


        // 改良型追加
        private LapsVideo lapsVideo;


        // 設定Formの変数
        private Form_Setting form_setting;

        // スリープ管理
        /// <summary>
        /// 録画中にスリープをしたかどうかを保持する
        /// </summary>
        private bool sleeped_in_recording = false;


        //===スリープ抑止用処理の宣言===
        [DllImport("kernel32.dll")]
        extern static ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        [FlagsAttribute]
        public enum ExecutionState : uint
        {
            Null = 0,
            SystemRequirwd = 1,
            DisplayRequired = 2,
            Continious = 0x80000000,
        }

        [DllImport("user32.dll")]
        extern static uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public int type;
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        //    --- dwFlags ---
        const int MOUSEEVENTF_MOVED = 0x0001;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;  // 左ボタン Down
        const int MOUSEEVENTF_LEFTUP = 0x0004;  // 左ボタン Up
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;  // 右ボタン Down
        const int MOUSEEVENTF_RIGHTUP = 0x0010;  // 右ボタン Up
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;  // 中ボタン Down
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;  // 中ボタン Up
        const int MOUSEEVENTF_WHEEL = 0x0080;
        const int MOUSEEVENTF_XDOWN = 0x0100;
        const int MOUSEEVENTF_XUP = 0x0200;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        const int screen_length = 0x10000;
        //    ---------------


        // =========================




        public Form1()
        {
            InitializeComponent();

            Screen sc = Screen.FromControl(this);

            lapsVideo = new LapsVideo(sc);

            Config_read();

            

            //　録画中のUI更新サブプロセス
            lapsTimer = new System.Timers.Timer();
            lapsTimer.Elapsed += new ElapsedEventHandler(recordVideo_UI_update);
            lapsTimer.AutoReset = true;
            lapsTimer.Interval = 1000;

            // UI初期化
            stop_rec.Enabled = false;
            toolStripStatusLabel_worn.Text = "";
            recordingTimer = new Stopwatch();

            label_recTime.Text = "00.00:00:00";
            label_videoTime.Text = "00.00:00:00";
            label_videoSize.Text = "0B";



            //スリープにしないための処理のサブプロセス
            SleepDeterrence = new System.Timers.Timer();
            SleepDeterrence.Elapsed += new ElapsedEventHandler(sleepDeterrence);
            SleepDeterrence.AutoReset = true;
            SleepDeterrence.Interval = 30000;

            sleeped_in_recording = false;

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);


            activeateItemsEndRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// スリープに入ってしまった場合録画を一時中断する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_PowerModeChanged(object sender , PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Suspend:

                    if (lapsVideo.isRecording)
                    {
                        sleeped_in_recording = true;
                    }


                    Invoke((MethodInvoker)delegate
                    {                       

                        lapsVideo.ForcedStopRecording();

                        
                    }); 
                    
                    break;

                case PowerModes.Resume:

                    if (sleeped_in_recording)
                    {
                        MessageBox.Show(
                            "システムが中断されたため録画を停止しました\n継続する場合は再度録画を開始してください",
                            "録画を停止しました",
                            MessageBoxButtons.OK);
                    }

                    sleeped_in_recording = false;

                    break;
            }
        }

        /// <summary>
        /// フォーム終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lapsVideo.isRecording)
            {
                e.Cancel = true;
                DialogResult res = MessageBox.Show(
                    "録画中です\n録画を終了しますか？",
                    "録画中",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if(res == DialogResult.Yes)
                {
                    lapsVideo.ForcedStopRecording();
                    e.Cancel = false;
                    SystemEvents.PowerModeChanged -= new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
                }
                else if(res == DialogResult.No)
                {

                }
            }
            else
            {
                SystemEvents.PowerModeChanged -= new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            }

            Config_save();
        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// スリープ、画面転換を行わないようにするメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sleepDeterrence(object sender, ElapsedEventArgs e)
        {
            SetThreadExecutionState(ExecutionState.DisplayRequired);

            INPUT[] input = new INPUT[1];

            input[0].mi.dx = 0;
            input[0].mi.dy = 0;
            input[0].mi.dwFlags = MOUSEEVENTF_MOVED;

            SendInput(1, input, Marshal.SizeOf(input[0]));
        }


        /// <summary>
        /// 録画開始ボタンを押したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_rec_Click(object sender, EventArgs e)
        {

            string fName = makeFileName();            

            lapsVideo.StartRecording(fName);

            lapsTimer.Start();

            SleepDeterrence.Enabled = true;
            SleepDeterrence.Start();


            disableItemsInRecording();

            recordingTimer.Reset();
            recordingTimer.Start();


        }

        /// <summary>
        /// 録画中のUI更新
        /// </summary>
        private void recordVideo_UI_update(object sender, ElapsedEventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {
                label_recTime.Text = recordingTimer.Elapsed.ToString(@"dd\.hh\:mm\:ss");
                label_videoTime.Text = TimeSpan.FromSeconds(lapsVideo.writed_frame / (double)lapsVideo.frameRate).ToString(@"dd\.hh\:mm\:ss");
                label_videoSize.Text = kgmConvert( (double)( (double)lapsVideo.bitRate/8.0 * (double)lapsVideo.writed_frame / (double)lapsVideo.frameRate)) + "B";
                
            });

        }

        

        // パスを含むファイル名の作成
        //　動画作成パスに送る
        private string makeFileName()
        {
            string filename = "";

            //ディレクトリの設定　
            //なければプログラムフォルダのvideosフォルダを指定
            if (Link_saveDir.Text.Equals(""))
            {
                if (!Directory.Exists("videos"))
                {
                    Directory.CreateDirectory("videos");
                }

                filename += @"videos\";
                Link_saveDir.Text = "videos";
            }
            else
            {
                filename += @Link_saveDir.Text + @"\";
            }

            //ビデオ名を設定
            if (TB_FileName.Text.Equals(""))
            {
                filename += "noname";
                TB_FileName.Text = "noname";
            }
            else
            {
                filename += TB_FileName.Text;
            }

            //年月日時分秒付け足し
            filename += "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

            //拡張子付け足し 
            //任意に変更処理できるようにした
#if VFW
            filename += ".avi";

#elif false
            filename += ".mp4";
#endif



            return filename;
        }


        /// <summary>
        /// 録画終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stop_rec_Click(object sender, EventArgs e)
        {

            //lapsVideo.StopRecoed();
            
            while (lapsVideo.StopRecoed() != 0)
            {
                Console.WriteLine("*");
                System.Threading.Thread.Sleep(500);
                
            }
            
                
            lapsTimer.Stop();

            activeateItemsEndRecord();

            recordingTimer.Stop();
            
        }

        /// <summary>
        /// 強制終了
        /// </summary>
        private void ForcedStopRecording()
        {

            lapsVideo.ForcedStopRecording();

            lapsTimer.Stop();

            activeateItemsEndRecord();
            recordingTimer.Stop();
        }

        /// <summary>
        /// インターバル設定ボックスの入力制限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Interval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            
        }

        private void textBox_Interval_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        /// <summary>
        /// 録画開始時に無効にするインターフェイス
        /// </summary>
        private void disableItemsInRecording()
        {
            start_rec.Enabled = false;
            TB_FileName.Enabled = false;
            Link_saveDir.Enabled = false;
            stop_rec.Enabled = true;
            button_pause.Enabled = true;
            toolStripMenuItem_Option_Setting.Enabled = false;
            Button_directrySet.Enabled = false;
            TS_Label_status.Text = "Recording...";

 
        }


        /// <summary>
        /// 録画終了時にもとに戻すインターフェイス
        /// </summary>
        private void activeateItemsEndRecord()
        {
            start_rec.Enabled = true;
            TB_FileName.Enabled = true;
            Link_saveDir.Enabled = true;
            stop_rec.Enabled = false;
            button_pause.Enabled = false;
            toolStripMenuItem_Option_Setting.Enabled = true;
            Button_directrySet.Enabled = true;
            TS_Label_status.Text = "";
        }

        /// <summary>
        /// 保存フォルダをセットするボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_directrySet_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select movie save folder";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            fbd.ShowNewFolderButton = true;


            if(fbd.ShowDialog(this) == DialogResult.OK)
            {
                Link_saveDir.Text = fbd.SelectedPath;
            }
        }

        
        private void textBox_Interval_TextChanged(object sender, EventArgs e)
        {
            
            
        }
               
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 保存フォルダを開くボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_openSaveDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Link_saveDir.Text);
            }
            catch
            {
                Process.Start(@"videos");
                Link_saveDir.Text = "videos";
            }
        }

        

        /// <summary>
        /// 数値をキロメガギガコンバート
        /// (1024計算にしとこうか迷い中)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string kgmConvert(int value)
        {
            string ext = "";
            double v;
            if(value < 1000)
            {
                v = value;
            }
            else if(value < 1000000)
            {
                ext = "k";
                v = value / 1000.0;
            }
            else if(value < 1000000000)
            {
                ext = "M";
                v = value / 1000000.0;
            }
            else
            {
                ext = "G";
                v = value / 1000000000.0;
            }

            return v.ToString("F1") + ext;
        }
        public static string kgmConvert(float value)
        {
            string ext = "";
            double v;
            if (value < 1000)
            {
                v = value;
            }
            else if (value < 1000000)
            {
                ext = "k";
                v = value / 1000.0;
            }
            else if (value < 1000000000)
            {
                ext = "M";
                v = value / 1000000.0;
            }
            else
            {
                ext = "G";
                v = value / 1000000000.0;
            }

            return v.ToString("F1") + ext;
        }
        public static string kgmConvert(double value)
        {
            string ext = "";
            double v;
            if (value < 1000)
            {
                v = value;
            }
            else if (value < 1000000)
            {
                ext = "k";
                v = value / 1000.0;
            }
            else if (value < 1000000000)
            {
                ext = "M";
                v = value / 1000000.0;
            }
            else
            {
                ext = "G";
                v = value / 1000000000.0;
            }

            return v.ToString("F1") + ext;
        }


        /// <summary>
        /// ファイルメニューからの終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFile_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// ポーズボタンを押したときの動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_pause_Click(object sender, EventArgs e)
        {
            if (lapsVideo.isPause)
            {
                TS_Label_status.Text = "Recording...";
                TS_Label_status.ForeColor = Color.Black;
                lapsVideo.RevartPause();
            }
            else
            {
                TS_Label_status.Text = "  -PAUSE-  ";
                TS_Label_status.ForeColor = Color.Orange;
                lapsVideo.Pause();
            }
        }

        /// <summary>
        /// 強制的に録画を一時停止させる
        /// </summary>
        /// <param name="pause"></param>
        private void ForcedPause(bool pause)
        {
            if (!pause)
            {
                TS_Label_status.Text = "Recording...";
                TS_Label_status.ForeColor = Color.Black;
                lapsVideo.RevartPause();
            }
            else
            {
                TS_Label_status.Text = "  -PAUSE-  ";
                TS_Label_status.ForeColor = Color.Orange;
                lapsVideo.Pause();
            }

        }

        /// <summary>
        /// 設定ファイル読み込み
        /// </summary>
        private void Config_read()
        {
            if (System.IO.File.Exists(@"config.conf"))
            {
                System.IO.StreamReader reader = (new System.IO.StreamReader(@"config.conf", System.Text.Encoding.GetEncoding("shift_jis")));
                string _saved_status = reader.ReadToEnd();
                reader.Close();

                string[] _saved_status_value = _saved_status.Split(',');

                try
                {
                    lapsVideo.interval = int.Parse( _saved_status_value[0] );
                    lapsVideo.quantity = int.Parse(_saved_status_value[1]);
                    Link_saveDir.Text = _saved_status_value[2];
                    lapsVideo.frameRate = int.Parse(_saved_status_value[3]);
                    
                    if(_saved_status_value[4] == "Normal")
                    {
                        lapsVideo.recordMode = LapsVideo.RecordMode.normal;
                    }
                    else if( _saved_status_value[4] == "Motion")
                    {
                        lapsVideo.recordMode = LapsVideo.RecordMode.MotionDetection;
                    }
                    else if(_saved_status_value[4] == "MotionL")
                    {
                        lapsVideo.recordMode = LapsVideo.RecordMode.MotionDetection;
                    }
                    else if(_saved_status_value[4] == "MotionVL")
                    {
                        lapsVideo.recordMode = LapsVideo.RecordMode.MotionDetection_VeryLite;
                    }
                    lapsVideo.motionRecordThreshold = float.Parse(_saved_status_value[5]);
                    
                    if(_saved_status_value[6] == "0")
                    {
                        lapsVideo.insert_time = false;
                    }
                    else
                    {
                        lapsVideo.insert_time = true;
                    }

                    Rectangle rct = new Rectangle(int.Parse(_saved_status_value[7]), int.Parse(_saved_status_value[8]), int.Parse(_saved_status_value[9]), int.Parse(_saved_status_value[10]));

                    lapsVideo.SetCaptureBound(Screen.FromControl(this), rct);

                    lapsVideo.insert_time_scale = float.Parse(_saved_status_value[11]);

                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "config file is broken. appriciation uses default settings",
                        "config read error",
                        MessageBoxButtons.OK);
                    
                }
                

            }
        }

        /// <summary>
        /// 設定情報をファイルに書き込む
        /// </summary>
        private void Config_save()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"config.conf", false, System.Text.Encoding.GetEncoding("shift_jis"));

            string _save_status = "";

            _save_status += lapsVideo.interval.ToString() + ",";
            _save_status += lapsVideo.quantity.ToString() + ",";
            _save_status += Link_saveDir.Text + ",";
            _save_status += lapsVideo.frameRate + ",";

            if(lapsVideo.recordMode == LapsVideo.RecordMode.normal)
            {
                _save_status += "Normal";
            }
            else if(lapsVideo.recordMode == LapsVideo.RecordMode.MotionDetection)
            {
                _save_status += "Motion";
            }
            else if(lapsVideo.recordMode == LapsVideo.RecordMode.MotionDetection_Lite)
            {
                _save_status += "MotionL";
            }
            else if(lapsVideo.recordMode == LapsVideo.RecordMode.MotionDetection_VeryLite)
            {
                _save_status += "MotionVL";
            }
            _save_status += ",";

            _save_status += lapsVideo.motionRecordThreshold.ToString("F5") + ",";

            if (lapsVideo.insert_time)
            {
                _save_status += "1";
            }
            else
            {
                _save_status += "0";
            }
            _save_status += ",";


            _save_status += lapsVideo.captureRect.X.ToString() + "," + lapsVideo.captureRect.Y.ToString() + "," + lapsVideo.captureRect.Width.ToString() + "," + lapsVideo.captureRect.Height.ToString();


            _save_status += ",";
            _save_status += lapsVideo.insert_time_scale.ToString("F2");

            sw.Write(_save_status);
            sw.Close();


        }


        /// <summary>
        /// バージョンインフォ表示(これでいいのか・・・？)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void option_Versioninfo_Click(object sender, EventArgs e)
        {
           
           string str = "Laps Video Recorder (processVideoMaker)\r\nVersion:" + Version.version + "\r\n \r\n using AForge.Video.ffmpeg" + "\r\n -AKI-";

            MessageBox.Show(
                str,
                "version info",
                MessageBoxButtons.OK);
        
        }

        /// <summary>
        /// 設定ウィンドウを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Option_Setting_Click(object sender, EventArgs e)
        {
            form_setting = new Form_Setting();
            form_setting.InitializeUI(lapsVideo);
            form_setting.ShowDialog(this);
        }

    }

    /// <summary>
    /// バージョン表示
    /// </summary>
    public class Version
    {
        /// <summary>
        /// 現在のソフトウェアバージョン
        /// </summary>
        static private string _version = "1.3.1";
        /// <summary>
        /// 現在のソフトウェアバージョン
        /// </summary>
        public static string version
        {
            get { return _version; }
        }

    }


}
