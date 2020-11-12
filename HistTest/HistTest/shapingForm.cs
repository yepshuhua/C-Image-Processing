using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistTest
{
    public partial class shapingForm : Form
    {
        private string shapingFileName;
        private System.Drawing.Bitmap shapingBitbmp;
        private int[] shapingPiexl;
        private double[] cumHist;
        private int shapingSize;
        private int maxPiexl;

        public shapingForm()
        {
            InitializeComponent();
            shapingPiexl = new int[256];
            cumHist = new double[256];

        }

        private void Open_Click(object sender, EventArgs e)
        {
            //打开所要匹配的图像，得到其直方图
            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Filter = "所有图像文件|*.bmp;*.pcx;*.png;*.jpg;*.gif";
            opnDlg.ShowHelp = true;
            opnDlg.Title = "打开图像文件";
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                shapingFileName = opnDlg.FileName;
                try
                {
                    shapingBitbmp = (Bitmap)Image.FromFile(shapingFileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                //在窗体绘制直方图
                Rectangle rect = new Rectangle(0, 0, shapingBitbmp.Width, shapingBitbmp.Height);
                System.Drawing.Imaging.BitmapData bmpData = shapingBitbmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, shapingBitbmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                shapingSize = shapingBitbmp.Width * shapingBitbmp.Height;
                byte[] grayvalue = new byte[shapingSize];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayvalue, 0, shapingSize);
                byte temp = 0;
                maxPiexl = 0;
                Array.Clear(shapingPiexl, 0, 256);
                for (int i = 0; i < shapingSize; i++)
                {
                    temp = grayvalue[i];
                    shapingPiexl[temp]++;
                    if (shapingPiexl[temp] > maxPiexl)
                    {
                        maxPiexl = shapingPiexl[temp];
                    }
                }
                System.Runtime.InteropServices.Marshal.Copy(grayvalue, 0, ptr, shapingSize);
            }
            Invalidate();
        }

        private void Startshaping_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void shapingForm_Paint(object sender, PaintEventArgs e)
        {
            if (shapingBitbmp != null)
            {
                Graphics g = e.Graphics;
                Pen curpen = new Pen(Brushes.Black, 1);
                g.DrawLine(curpen, 50, 240, 320, 240);
                g.DrawLine(curpen, 50, 240, 50, 20);
                g.DrawLine(curpen, 50, 240, 50, 20);

                g.DrawLine(curpen, 100, 240, 50, 245);
                g.DrawLine(curpen, 150, 240, 50, 245);
                g.DrawLine(curpen, 200, 240, 50, 245);
                g.DrawLine(curpen, 250, 240, 50, 245);
                g.DrawLine(curpen, 300, 240, 50, 245);
                g.DrawString("0", new Font("new Timer", 8), Brushes.Black, new PointF(46, 245));
                g.DrawString("50", new Font("new Timer", 8), Brushes.Black, new PointF(92, 245));
                g.DrawString("100", new Font("new Timer", 8), Brushes.Black, new PointF(139, 245));
                g.DrawString("150", new Font("new Timer", 8), Brushes.Black, new PointF(189, 245));
                g.DrawString("200", new Font("new Timer", 8), Brushes.Black, new PointF(239, 245));
                g.DrawString("250", new Font("new Timer", 8), Brushes.Black, new PointF(289, 245));

                g.DrawLine(curpen, 48, 40, 50, 40);
                g.DrawString("0", new Font("new Timer", 8), Brushes.Black, new PointF(34, 234));
                g.DrawString(maxPiexl.ToString(), new Font("new Timer", 8), Brushes.Black, new PointF(18, 34));

                double temp = 0;
                int[] tempArray = new int[256];
                for (int i = 0; i < 255; i++)
                {
                    temp = 200 * (double)shapingPiexl[i] / (double)maxPiexl;
                    g.DrawLine(curpen, 50 + i, 240, 50 + i, 240 - (int)temp);
                    //计算该直方囷各灰度级的累积分布函数
                    if (i != 0)
                    {
                        tempArray[i] = tempArray[i - 1] + shapingPiexl[i];
                    }
                    else
                    {
                        tempArray[0] = shapingPiexl[0];
                    }
                    cumHist[i] = (double)tempArray[i] / (double)shapingSize;
                }
                curpen.Dispose();
            }
        }
        public double[] ApplicationP
        {
            get { return cumHist; }
        }
    }
}
