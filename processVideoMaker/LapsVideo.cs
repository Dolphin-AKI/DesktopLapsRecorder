using System;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.FFMPEG;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace processVideoMaker
{


    /// <summary>
    /// モニタ上をタイムラプス撮影するコンポーネント
    /// </summary>
    public class LapsVideo 
    {
        // == Default variable=====
        private int _default_interval = 1000;
        private int _default_quantity_value = 330;
        private int _default_FlameRate = 30;

        // == Using variable ====

        /// <summary>
        /// 録画モード
        /// </summary>
        public enum RecordMode
        {
            normal,
            MotionDetection,
            MotionDetection_Lite,
            MotionDetection_VeryLite
        }
        private RecordMode _recordMode = RecordMode.normal;
        /// <summary>
        /// 設定されている録画モード
        /// 
        /// </summary>
        public RecordMode recordMode
        {
            get { return _recordMode; }
            set { this._recordMode = value; }
        }

        private float _MotionRecordThrethold = 0.001f;
        /// <summary>
        /// 動き検知録画で記録する画面差分量閾値
        /// </summary>
        public float motionRecordThreshold
        {
            get { return this._MotionRecordThrethold; }
            set { this._MotionRecordThrethold = (float)value; }
        }

     

        private Rectangle _recordBound;
        /// <summary>
        /// Unknown(作っといて忘れた)
        /// </summary>
        public Rectangle recordBound
        {
            get { return _recordBound; }
            set { this._recordBound = value; }
        }


        private int _interval = 1000;
        /// <summary>
        /// 撮影間隔
        /// </summary>
        public int interval
        {
            set { this._interval = value; }
            get { return this._interval; }

        }
         
        private int _quantity_value = 330;
        /// <summary>
        /// 品質
        /// </summary>
        public int quantity
        {
            set { this._quantity_value = value; }
            get { return this._quantity_value; }
        }

        private int _frameRate = 30;
        /// <summary>
        /// フレームレート
        /// </summary>
        public int frameRate
        {
            set { this._frameRate = value; }
            get
            {
                return _frameRate;
            }
        }

        private VideoCodec _codec = VideoCodec.MPEG4;
        /// <summary>
        /// ビデオコーデック
        /// </summary>
        public VideoCodec Video_codec
        {
            set { this._codec = value; }
            get { return _codec; }
        }

        private int _bitRate = 1500000;
        /// <summary>
        /// ビットレート
        /// </summary>
        public int bitRate
        {
            set { this._bitRate = value; }
            get { return _bitRate; }
        }

        private int _writed_frame = 0;
        /// <summary>
        /// 書込みフレーム数
        /// </summary>
        public int writed_frame
        {
            get { return _writed_frame; }
        }
        
        /// <summary>
        /// ポーズ状態
        /// </summary>
        public bool isPause
        {
            get { return record_pause; }
        }

        /// <summary>
        /// 録画を実行しているかどうか
        /// </summary>
        public bool isRecording
        {
            get { return recording; }
        }

        private Rectangle _captureRect;
        /// <summary>
        /// 画面録画領域
        /// </summary>
        public Rectangle captureRect
        {
            get { return _captureRect; }
            set { this._captureRect = value; }
        }

        private Screen _targetScreen;
        /// <summary>
        /// 対象画面（モニター）
        /// </summary>
        public Screen targetScreen
        {
            get { return _targetScreen; }
            set { this._targetScreen = value; }
        }
            
        // == No change variable ====
        static private int _MaxBitRate = 30000000;
        /// <summary>
        /// 最大ビットレート
        /// </summary>
        public int MaxBitRate
        {
            get { return _MaxBitRate; }
        }

        /// <summary>
        /// 打刻機能を使用するかどうか
        /// </summary>
        public bool insert_time
        {
            set { this._insert_time = value; }
            get { return _insert_time; }
        }

        private float __insert_time_scale = 0.05f;
        /// <summary>
        /// 打刻時の時計の大きさ
        /// </summary>
        public float insert_time_scale
        {
            set { this.__insert_time_scale = value; }
            get { return __insert_time_scale; }
        }

        


        // == variable ====
        private VideoFileWriter mpegWriter;
        System.Timers.Timer lapsTimer;

        private bool recording;
        private bool record_pause;
        private bool _writing_frame;
        private bool _insert_time;
        private bool _stopFlag;
        private Bitmap _bitmap;


        /// <summary>
        /// レコーダーをインスタンス化
        /// </summary>
        /// <param name="activDisplay">録画対象とするScreen</param>
        public LapsVideo(Screen activDisplay)
        {
            _targetScreen = activDisplay;
            _captureRect = _targetScreen.Bounds;

            lapsTimer = new System.Timers.Timer();
            lapsTimer.Elapsed += new ElapsedEventHandler(VideoRecord);
            lapsTimer.AutoReset = true;

            record_pause = false;
            _writing_frame = false;
            _stopFlag = false;
        }

        /// <summary>
        /// 録画を開始する
        /// </summary>
        /// <param name="filename">録画ファイル名</param>
        public void StartRecording(string filename)
        {
            _stopFlag = false;
            recording = true;

            // ファイル名に拡張子追加
            if(_codec == VideoCodec.Raw)
            {
                filename += ".avi";
            }
            else if(_codec == VideoCodec.MPEG4)
            {
                filename += ".mp4";
            }

            try
            {
                _bitmap = new Bitmap(_captureRect.Width, _captureRect.Height);

                mpegWriter = new VideoFileWriter();
                mpegWriter.Open(filename, _bitmap.Width, _bitmap.Height, _frameRate, _codec, _bitRate);

                _pastFrame = null;
            }
            catch(Exception e)
            {
                MessageBox.Show(
                    e.ToString(),
                    "Error 録画を開始できませんでした",
                    MessageBoxButtons.OK);

                mpegWriter.Dispose();
            }

            lapsTimer.Interval = this.interval;
            lapsTimer.Enabled = true;
            lapsTimer.Start();
            _writed_frame = 0;
            
        }

        /// <summary>
        /// 録画領域を設定してもらう
        /// </summary>
        /// <param name="targetScreen">対象のモニタ</param>
        /// <param name="bound">録画領域</param>
        public void SetCaptureBound(Screen targetScreen,Rectangle bound)
        {
            _targetScreen = targetScreen;

            //複数ディスプレイ環境でほかのディスプレイの領域指定を合わせる
            bound.X += targetScreen.Bounds.X;
            bound.Y += targetScreen.Bounds.Y;


            //解像度が偶数である必要があるため
            //偶数にする処理

            if(bound.Width % 2 == 1)
            {
                bound.Width -= 1;
            }

            if(bound.Height % 2 == 1)
            {
                bound.Height -= 1;
            }

            _captureRect = bound;

            Console.WriteLine(_captureRect);
        }


        /// <summary>
        /// フルスクリーンの録画をセットするとき
        /// </summary>
        /// <param name="targetScreen">対象のモニタ</param>
        public void SetCaptureBoundFullScreen(Screen targetScreen)
        {
            Rectangle bound = new Rectangle(0, 0, targetScreen.Bounds.Width, targetScreen.Bounds.Height);

            SetCaptureBound(targetScreen, bound);
        }


        //private Graphics g;
        /// <summary>
        /// 間欠録画を実行する本体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoRecord(object sender , ElapsedEventArgs e)
        {
            Console.WriteLine(_writing_frame + "[" + _writed_frame + "]");

            // 録画可能かチェック
            if(_writing_frame || record_pause || _stopFlag)
            {
                return;
            }

            // 書き込みを行うためロックをかける
            _writing_frame = true;

            Graphics g = Graphics.FromImage(_bitmap);

            // 録画形式によって分岐
            try
            {
                switch (recordMode)
                {
                    case RecordMode.normal:
                        WriteFrame(g);
                        break;

                    case RecordMode.MotionDetection:
                        DiffWriteFrame(g);
                        break;

                    case RecordMode.MotionDetection_Lite:
                        DiffWriteFrame(g);
                        break;

                    case RecordMode.MotionDetection_VeryLite:
                        DiffWriteFrame(g);
                        break;
                }

                

            }
            catch(AForge.Video.VideoException ex)
            {

                ForcedStopRecording();
 
                _writing_frame = false;

                MessageBox.Show(
                    "記録に失敗し録画を停止しました\n継続する場合は再度録画を開始してください",
                    "Video EndFrame Writing Error",
                    MessageBoxButtons.OK);

            }

            g.Dispose();

            //　解放
            _writing_frame = false;


        }

        /// <summary>
        /// 通常の記録方式
        /// </summary>
        /// <param name="bitmap">ビデオフレームに追加するbitmap</param>
        private void WriteFrame(Graphics g)
        {
            g.CopyFromScreen(new Point(_captureRect.X, _captureRect.Y), new Point(0, 0), _bitmap.Size);
            ImageProcessing(g);
            mpegWriter.WriteVideoFrame(_bitmap);
            _writed_frame += 1;
        }


        private Bitmap _pastFrame = null;
        private BitmapData current_bitmap;
        private BitmapData past_bitmap;
        /// <summary>
        /// 動き検知録画
        /// インターバル1秒以上に制限しよう・・・
        /// </summary>
        /// <param name="g"></param>
        private void DiffWriteFrame(Graphics g)
        {
            g.CopyFromScreen(new Point(_captureRect.X, _captureRect.Y), new Point(0, 0), _bitmap.Size);


            if (_pastFrame == null)
            {
                mpegWriter.WriteVideoFrame(_bitmap);
                _pastFrame = (Bitmap)_bitmap.Clone();
                _writed_frame += 1;
            }
            else
            {
                /* 標準のGetPixelではとっても遅いので高速アルゴリズムを使用
                 * ビットマップデータをアンマネージ配列にコピーしてから処理をするものらしい
                 * *リサイズ手法はダメそう
                 */
                current_bitmap = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height),
                    ImageLockMode.ReadOnly,
                    _bitmap.PixelFormat);

                past_bitmap = _pastFrame.LockBits(new Rectangle(0, 0, _pastFrame.Width, _pastFrame.Height),
                    ImageLockMode.ReadOnly,
                    _pastFrame.PixelFormat);

                int bsize = current_bitmap.Stride * _bitmap.Height;
                byte[] byte_current = new byte[bsize];
                byte[] byte_past = new byte[bsize];

                Marshal.Copy(current_bitmap.Scan0, byte_current, 0, bsize);
                Marshal.Copy(past_bitmap.Scan0, byte_past, 0, bsize);

                //差分量計算
                int diff = 0;
                float Diff = 0;
                switch (recordMode)
                {
                    // -----------------------------------------------------------------------------------------
                    case RecordMode.MotionDetection:
                        //全画素に対して差分計算（最高精度・最大計算量）
                        try
                        {
                            for (int i = 0; i < bsize; i++)
                            {

                                if (byte_current[i] != byte_past[i])
                                {
                                    diff += 1;
                                }
                            }
                        }
                        finally
                        {
                            _bitmap.UnlockBits(current_bitmap);
                            _pastFrame.UnlockBits(past_bitmap);
                        }

                        Diff = (float)((float)diff / (float)bsize);

                        break;

                    //------------------------------------------------------------------------------------------
                    case RecordMode.MotionDetection_Lite:
                        // 部分的にアクセスしてして差分計算（精度が落ちる分,計算量も落ちる）
                        try
                        {
                            for (int i = 0; i < bsize; i = i + 50)
                            {

                                if (byte_current[i] != byte_past[i])
                                {
                                    diff += 1;
                                }
                            }
                        }
                        finally
                        {
                            _bitmap.UnlockBits(current_bitmap);
                            _pastFrame.UnlockBits(past_bitmap);
                        }

                        Diff = (float)((float)diff / (float)(bsize / 50f));

                        break;


                    //-----------------------------------------------------------------------------------------
                    case RecordMode.MotionDetection_VeryLite:
                        // 部分アクセス量をさらに間引く（ほんとスペックが壊滅してる時用）
                        try
                        {
                            for (int i = 0; i < bsize; i = i + 75)
                            {

                                if (byte_current[i] != byte_past[i])
                                {
                                    diff += 1;
                                }
                            }
                        }
                        finally
                        {
                            _bitmap.UnlockBits(current_bitmap);
                            _pastFrame.UnlockBits(past_bitmap);
                        }

                        Diff = (float)((float)diff / (float)((float)bsize / 75f));

                        break;


                    // ----------------------------------------------------------------------------
                    default:
                        //全画素に対して差分計算（最高精度・最大計算量） 万が一ケース
                        try
                        {
                            for (int i = 0; i < bsize; i++)
                            {

                                if (byte_current[i] != byte_past[i])
                                {
                                    diff += 1;
                                }
                            }
                        }
                        finally
                        {
                            _bitmap.UnlockBits(current_bitmap);
                            _pastFrame.UnlockBits(past_bitmap);
                        }

                        Diff = (float)((float)diff / (float)bsize);
                        break;

                }


                //閾値以上の変化があったら記録
                if (Diff > _MotionRecordThrethold)
                {
                    _pastFrame = (Bitmap)_bitmap.Clone();

                    ImageProcessing(g);

                    mpegWriter.WriteVideoFrame(_bitmap);
                    
                    _writed_frame += 1;

                }


            }
         
        }



        /// <summary>
        /// 画像加工を行うメソッドはここに登録
        /// 動画処理のメインから呼び出す
        /// </summary>
        private void ImageProcessing(Graphics g)
        {
            if (insert_time)
            {
                InsertTime(g);
            }
        }



        /// <summary>
        /// 現在時間を動画に挿入する
        /// 挿入位置は左上
        /// </summary>
        /// <param name="g"></param>
        private void InsertTime(Graphics g)
        {
            SolidBrush sb = new SolidBrush(Color.FromArgb(170, 100, 100, 100));
            // 打刻背景塗り （1px ＝ 0.75pt）y[取得領域の5％]　x[取得領域5％分のフォントサイズ x 15文字 x ちょっと短めに(85%)]
            g.FillRectangle(sb, 5, 5, captureRect.Height * __insert_time_scale * 0.75f * 15f * 0.85f , captureRect.Height * __insert_time_scale);

            Font font = new Font("MS UI Gothic", captureRect.Height * __insert_time_scale * 0.75f);
            string str = DateTime.Now.ToString();
            g.DrawString(str, font, Brushes.White, 6, 6);
            font.Dispose();
            sb.Dispose();
        }

        /// <summary>
        /// 録画を停止する
        /// </summary>
        /// <returns>0：正常終了したとき。　1:フレームの書き込み中などで終了できないとき。</returns>
        public int StopRecoed()
        {
            _stopFlag = true;
            if (_writing_frame)
            {
                return 1;
            }

            lapsTimer.Stop();

            try
            {
                mpegWriter.Close();
                mpegWriter.Dispose();
                _bitmap.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }



            if (_pastFrame != null)
            {
                _pastFrame.Dispose();
            }



            record_pause = false;
            _writing_frame = false;

            recording = false;

            GC.Collect();

            return 0;

        }

        /// <summary>
        /// 書き込み中だろうが何だろうが強制的に録画を中止する。
        /// </summary>
        public void ForcedStopRecording()
        {
            lapsTimer.Stop();
            mpegWriter.Close();
            mpegWriter.Dispose();
            _bitmap.Dispose();

            if(_pastFrame != null)
            {
                _pastFrame.Dispose();
            }


            record_pause = false;
            _writing_frame = false;

            recording = false;
        }

        /// <summary>
        /// 録画を一時停止する
        /// </summary>
        public void Pause()
        {
            record_pause = true;
        }


        /// <summary>
        /// 一時停止から復帰する
        /// </summary>
        public void RevartPause()
        {
            record_pause = false;
        }

    }
}
