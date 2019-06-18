using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;

namespace processVideoMaker
{
    /// <summary>
    /// 設定フォームコントロール
    /// </summary>
    public partial class Form_Setting : Form
    {
        /// <summary>
        /// 接続しているlapsVideo
        /// </summary>
        private LapsVideo lpv;


        public Form_Setting()
        {
            InitializeComponent();

        }

        /// <summary>
        /// lapsVideoに設定されている情報をセットする
        /// </summary>
        /// <param name="lpv">接続しているLapsVideoコンポ―ネント</param>
        public void InitializeUI(LapsVideo lpv)
        {
            this.lpv = lpv;
            // UI 初期化


            txtBox_interval.Text = lpv.interval.ToString();
            textBox_fps.Text = lpv.frameRate.ToString();
            trackBar_quality.Value = lpv.quantity;

            // MotionDetectionの閾値設定
            try
            {
                float tval = (int)(Math.Pow(lpv.motionRecordThreshold, 1 / 4) * 1414.2);
                if (tval < trackBar_MotionThrethold.Minimum)
                {
                    tval = trackBar_MotionThrethold.Minimum;
                }

                if (tval > trackBar_MotionThrethold.Maximum)
                {
                    tval = trackBar_MotionThrethold.Maximum;
                }
                trackBar_MotionThrethold.Value = (int)(Math.Pow(lpv.motionRecordThreshold, 1.0 / 4.0) * 1414.2);
            }
            catch
            {
                trackBar_MotionThrethold.Value = trackBar_MotionThrethold.Minimum;
            }
            setComboBoxValue(lpv);

            // 日時焼き込みの設定項目
            checkBox_insert_dateTime.Checked = lpv.insert_time;
            try
            {
                trackBar_process_timeScale.Value = (int)(lpv.insert_time_scale * 100.0f)+1;
            }
            catch
            {
                trackBar_process_timeScale.Value = 5;
            }


            float val = trackBar_quality.Value / 10f;
            label_qualityvalue.Text = val.ToString("F1") + "%";
            label_bitrate.Text = Form1.kgmConvert(lpv.MaxBitRate * val / 100.0) + "bps(about)";

            
            val = (float)(Math.Pow((float)trackBar_MotionThrethold.Value / 1414.2, 4));
            label_motionThrethold.Text = (val*100f).ToString("F4") + "%";
            Update_LbInfo();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 録画形式のコンボボックスをセットする
        /// </summary>
        /// <param name="lpv"></param>
        private void setComboBoxValue(LapsVideo lpv)
        {
            if(lpv.Video_codec == AForge.Video.FFMPEG.VideoCodec.Raw)
            {
                CB_extension.SelectedIndex = 0;
            }
            else if(lpv.Video_codec == AForge.Video.FFMPEG.VideoCodec.MPEG4)
            {
                CB_extension.SelectedIndex = 1;
            }
            

            if(lpv.recordMode == LapsVideo.RecordMode.normal)
            {
                comboBox_recordMode.SelectedIndex = 0;
            }
            else if(lpv.recordMode == LapsVideo.RecordMode.MotionDetection)
            {
                comboBox_recordMode.SelectedIndex = 1;

            }
            else if(lpv.recordMode == LapsVideo.RecordMode.MotionDetection_Lite)
            {
                comboBox_recordMode.SelectedIndex = 2;
            }
            else if(lpv.recordMode == LapsVideo.RecordMode.MotionDetection_VeryLite)
            {
                comboBox_recordMode.SelectedIndex = 3;
            }


        }

        /// <summary>
        /// LapsVideoプログラムに設定を反映する
        /// </summary>
        private void SetValuesToLapsVideo()
        {
            // インターバルのセット
            if(txtBox_interval.Text == "")
            {
                lpv.interval = 1000;
                txtBox_interval.Text = "1000";
            }
            else
            {
                try
                {
                    lpv.interval = int.Parse(txtBox_interval.Text);
                }
                catch (FormatException)
                {
                    lpv.interval = 1000;
                    txtBox_interval.Text = "1000";
                    MessageBox.Show(
                        "値に問題があるためデフォルト値をセットしました\nミリ秒整数値での入力をお願いします。",
                        "インターバルの値が不正です",
                        MessageBoxButtons.OK);
                }
            }

            //フレームレートのセット
            if (textBox_fps.Text == "")
            {
                lpv.frameRate = 30;
                textBox_fps.Text = "30";
            }
            else
            {
                try
                {
                    lpv.frameRate = int.Parse(textBox_fps.Text);
                }
                catch (FormatException)
                {
                    lpv.frameRate = 30;
                    textBox_fps.Text = "30";
                    MessageBox.Show(
                        "値に問題があるためデフォルト値をセットしました\nミリ秒整数値での入力をお願いします。",
                        "フレームレートの値が不正です",
                        MessageBoxButtons.OK);
                }
            }

            // 品質のセット
            lpv.bitRate = (int)((double)lpv.MaxBitRate * (double)trackBar_quality.Value / 1000.0);
            lpv.quantity = trackBar_quality.Value;

            // 打刻のセット
            lpv.insert_time = checkBox_insert_dateTime.Checked;
            lpv.insert_time_scale = (float)trackBar_process_timeScale.Value / 100.0f;

            //コーデックのセット
            AForge.Video.FFMPEG.VideoCodec codec;
            switch (CB_extension.SelectedIndex)
            {
                case 0:
                    codec = AForge.Video.FFMPEG.VideoCodec.Raw;
                    break;

                case 1:
                    codec = AForge.Video.FFMPEG.VideoCodec.MPEG4;
                    break;

                default:
                    codec = AForge.Video.FFMPEG.VideoCodec.Raw;
                    break;

            }

            lpv.Video_codec = codec;

            //録画モードのセット
            LapsVideo.RecordMode recMode;
            switch (comboBox_recordMode.SelectedIndex)
            {
                case 0:
                    recMode = LapsVideo.RecordMode.normal;
                    break;

                case 1:
                    recMode = LapsVideo.RecordMode.MotionDetection;
                    break;

                case 2:
                    recMode = LapsVideo.RecordMode.MotionDetection_Lite;
                    break;

                case 3:
                    recMode = LapsVideo.RecordMode.MotionDetection_VeryLite;
                    break;

                default:
                    recMode = LapsVideo.RecordMode.normal;
                    break;
            }

            lpv.recordMode = recMode;

            // MotionDetectionの閾値のセット
            lpv.motionRecordThreshold = (float)(Math.Pow((float)trackBar_MotionThrethold.Value/1414.2,4));


        }

        /// <summary>
        /// ラベル情報のアップデート
        /// </summary>
        private void Update_LbInfo()
        {
            double rate;
            try
            {
                rate = double.Parse(textBox_fps.Text) * double.Parse(txtBox_interval.Text) * 0.001;
            }
            catch
            {
                rate = 1;
            }

            if(rate == 0)
            {
                rate = 1;
            }

            double new_bitrate = lpv.MaxBitRate * trackBar_quality.Value / 10.0;

            string str = rate.ToString("F2") + "倍速\n";
            str += "1時間の録画で " + TimeSpan.FromSeconds(3600/rate).ToString(@"hh\:mm\:ss") + " の録画になります\n";

            if(double.Parse(txtBox_interval.Text) < 100)
            {
                str += "！短い間隔のラプス撮影は正常に動作しない可能性があります！";
            }

            LB_info.Text = str;
        }


        /// <summary>
        /// 「設定」ボタンを押したときの挙動
        /// 設定されている情報をLapsVideoコンポーネントに反映させて終了させる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_set_Click(object sender, EventArgs e)
        {
            SetValuesToLapsVideo();
            this.Close();
        }

        /// <summary>
        /// 「キャンセル」を押したときの挙動
        /// 何もせずにクローズする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 「品質スライドバー」を変更したときの挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_quality_Scroll(object sender, EventArgs e)
        {
            float val = trackBar_quality.Value / 10f;
            label_qualityvalue.Text = val.ToString("F1") + "%";
            label_bitrate.Text = Form1.kgmConvert(lpv.MaxBitRate * val / 100.0) + "bps(about)";
            Update_LbInfo();
        }

        /// <summary>
        /// インターバルに書き込みがあるときの挙動
        /// 数字以外を記入禁止にしている。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_interval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                
            }
        }

        /// <summary>
        /// fpsに書き込みがあるときの挙動
        /// 数字以外を記入禁止にしている。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_fps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                
            }
        }

        /// <summary>
        /// インターバルにセットされた値をチェックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_interval_TextChanged(object sender, EventArgs e)
        {
            if(comboBox_recordMode.SelectedIndex == 1)
            {
                if(int.Parse(txtBox_interval.Text) < 1000)
                {
                    txtBox_interval.Text = "1000";
                    MessageBox.Show(
                        "動き検知録画の時はインターバルは1000ミリ秒以下は指定できません",
                        "",
                        MessageBoxButtons.OK);
                }
            }


            Update_LbInfo();
        }

        /// <summary>
        /// fpsの値を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_fps_TextChanged(object sender, EventArgs e)
        {
            Update_LbInfo();
        }

        private void label_bitrate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 録画モードの変更があった時の挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_recordMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_recordMode.SelectedIndex)
            {
                case 0:
                    label_mode_description.Text = "通常録画です";
                    trackBar_MotionThrethold.Enabled = false;
                    break;

                case 1:
                    label_mode_description.Text = "動きがあった時のみ録画します(推奨)";
                    trackBar_MotionThrethold.Enabled = true;

                    if(int.Parse(txtBox_interval.Text) < 1000)
                    {
                        txtBox_interval.Text = "1000";
                        MessageBox.Show(
                            "動体検知録画の時はインターバルは1000ミリ秒以下は指定できません",
                            "",
                            MessageBoxButtons.OK);
                    }
                    break;

                case 2:
                    label_mode_description.Text = "動きがあった時のみ録画します(軽量)";
                    trackBar_MotionThrethold.Enabled = true;

                    break;

                case 3:
                    label_mode_description.Text = "動きがあった時のみ録画します(非推奨)\n軽量版でも動作が重いときに検討してください。";
                    trackBar_MotionThrethold.Enabled = true;

                    break;

                default:
                    trackBar_MotionThrethold.Enabled = false;
                    break;
            }
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// MotionDetectionモードの閾値を変更したときの挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_MotionThrethold_Scroll(object sender, EventArgs e)
        {
            float val = (float)(Math.Pow((float)trackBar_MotionThrethold.Value / 1414.2, 4)); //指数変化で最大50%になる(2乗の時は)
            label_motionThrethold.Text = (val*100f).ToString("F4") + "%";
        }

        private void checkBox_insert_dateTime_CheckedChanged(object sender, EventArgs e)
        {

        }

        private setBoundForm _set_boundform;

        /// <summary>
        /// 録画領域取得のボタンを押したときの挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_setCaptureWindow_Click(object sender, EventArgs e)
        {
            Screen s = Screen.FromControl(this);

            _set_boundform = new setBoundForm(lpv,s);
            _set_boundform.ShowDialog(this);

        }

        /// <summary>
        /// フルスクリーン録画のボタンを押したときの挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_capwin_fullscreen_Click(object sender, EventArgs e)
        {
            lpv.SetCaptureBoundFullScreen(Screen.FromControl(this));

            MessageBox.Show(
                "このモニタ画面をキャプチャ対象に設定しました",
                "確認",
                MessageBoxButtons.OK);

        }

        private void groupBox_process_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar_process_timeScale_Scroll(object sender, EventArgs e)
        {

        }
    }




    
}
