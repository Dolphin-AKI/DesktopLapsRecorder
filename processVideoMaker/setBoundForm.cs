using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace processVideoMaker
{
    public partial class setBoundForm : Form
    {
        Screen ActivScreen;

        Point MD = new Point();
        Point MU = new Point();
        Bitmap bmp;
        bool view = false;

        LapsVideo lpv;

        public setBoundForm(LapsVideo lpv,Screen setScreen)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = setScreen.Bounds.Location;

            ActivScreen = setScreen;

            InitializeComponent();

            this.lpv = lpv;

            pictureBox1.Size = ActivScreen.Bounds.Size;
            Console.Write(pictureBox1.Size);

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // 描画フラグON
            view = true;

            // Mouseを押した座標を記録
            MD.X = e.X;
            MD.Y = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Point start = new Point();
            Point end = new Point();

            // Mouseを離した座標を記録
            MU.X = e.X;
            MU.Y = e.Y;

            //System.Diagnostics.Debug.WriteLine("MouseUp({0},{1})->({2},{3})", MD.X, MD.Y, MU.X, MU.Y);

            // 座標から(X,Y)座標を計算
            GetRegion(MD, MU, ref start, ref end);

            // 領域を描画
            DrawRegion(start, end);

            //PictureBox1に表示する
            pictureBox1.Image = bmp;

            // 描画フラグOFF
            view = false;

            //Console.WriteLine(MD.ToString() + "," + MU.ToString());

            lpv.SetCaptureBound(ActivScreen, new Rectangle(start, new Size(GetLength(start.X, end.X), GetLength(start.Y, end.Y)) ) );

            MessageBox.Show(
                "指定した領域をキャプチャ対象に設定しました",
                "確認",
                MessageBoxButtons.OK);

            this.Close();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point();
            Point start = new Point();
            Point end = new Point();

            // 描画フラグcheck
            if (view == false)
            {
                return;
            }

            // カーソルが示している場所の座標を取得
            p.X = e.X;
            p.Y = e.Y;

            // 座標から(X,Y)座標を計算
            GetRegion(MD, p, ref start, ref end);

            //System.Diagnostics.Debug.WriteLine("Move ({0},{1})", e.X, e.Y);

            // 領域を描画
            DrawRegion(start, end);

            //PictureBox1に表示する
            pictureBox1.Image = bmp;
        }

        private void GetRegion(Point p1, Point p2, ref Point start, ref Point end)
        {
            start.X = Math.Min(p1.X, p2.X);
            start.Y = Math.Min(p1.Y, p2.Y);

            end.X = Math.Max(p1.X, p2.X);
            end.Y = Math.Max(p1.Y, p2.Y);
        }

        private int GetLength(int start, int end)
        {
            return Math.Abs(start - end);
        }

        private void DrawRegion(Point start, Point end)
        {
            Pen blackPen = new Pen(Color.Black);
            Graphics g = Graphics.FromImage(bmp);
            SolidBrush sb = new SolidBrush(Color.FromArgb(127, 50, 93, 255));

            // 描画する線を点線に設定
            blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            // 画面を消去
            g.Clear(SystemColors.Control);

            // 領域を描画
            g.FillRectangle(sb, start.X, start.Y, GetLength(start.X, end.X), GetLength(start.Y, end.Y));
            g.DrawRectangle(blackPen, start.X, start.Y, GetLength(start.X, end.X), GetLength(start.Y, end.Y));

            g.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
