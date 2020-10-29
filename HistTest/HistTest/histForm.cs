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
    public partial class histForm : Form
    {
        //图像数据
        private int[] countPixel;
        private System.Drawing.Bitmap bmpHist;
        //记录最大的灰度级个数
        private int maxPixel;
        public histForm(Bitmap bmp)
        {
            InitializeComponent();
            //把主窗体的图像传递给从窗体
            bmpHist = bmp;
            //灰度级计数
            countPixel = new int[256];
        }
       

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void histForm_Paint(object sender, PaintEventArgs e)
        {
            //获取Graphics对象
            Graphics g = e.Graphics;
            Pen curpen = new Pen(Brushes.Black, 1);
            //绘制坐标轴
            g.DrawLine(curpen, 50, 240, 360, 240);
            g.DrawLine(curpen, 50, 240, 50, 20);
            //标识刻度值(横坐标)
            g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(46, 250));
            g.DrawLine(curpen,100, 240, 100, 250);
            g.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(93, 250));
            g.DrawLine(curpen, 150, 240, 150, 250);
            g.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(138, 250));
            g.DrawLine(curpen, 200, 240, 200, 250);
            g.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(189, 250));
            g.DrawLine(curpen, 250, 240, 250, 250);
            g.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(239, 250));
            g.DrawLine(curpen, 300, 240, 300, 250);
            g.DrawString("250", new Font("New Timer", 8), Brushes.Black, new PointF(289, 250));
            g.DrawLine(curpen, 350, 240, 350, 250);
            g.DrawString("300", new Font("New Timer", 8), Brushes.Black, new PointF(339, 250));
            //纵坐标
            g.DrawLine(curpen, 40, 40, 50, 40);

            //标识刻度值(纵坐标)
            g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(34, 234));
            g.DrawString(maxPixel.ToString(), new Font("New Timer", 8), Brushes.Black, new PointF(18, 34));
            //绘制直方图
            double temp = 0;
            for(int i = 0; i < 256; i++)
            {
                //纵坐标长度
                temp = 200.0 * countPixel[i] / maxPixel;
                g.DrawLine(curpen, 50 + i, 240, 50 + i, 240 - (int)temp);
            }
            //释放对象
            curpen.Dispose();
        }

        private void histForm_Load(object sender, EventArgs e)
        {
            //锁定灰度图像
            Rectangle rect = new Rectangle(0, 0, bmpHist.Width, bmpHist.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmpHist.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmpHist.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpHist.Width * bmpHist.Height*3;
            byte[] grayValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);

            byte temp = 0;
            maxPixel = 0;
            //灰度等级
            Array.Clear(countPixel, 0, 256);
            //计算各个灰度缘的像素个数，并实现找到灰度频率最大的像素
            for (int i = 0; i < bytes; i+=3)
            {
                //灰度级
                temp = grayValues[i];
                //计数加1
                countPixel[temp]++;
                if (countPixel[temp] > maxPixel)
                {
                    //找到灰度频率最大的像素数，用于绘制直方图
                    maxPixel = countPixel[temp];
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
            //解锁
            bmpHist.UnlockBits(bmpData);

        }
    }
}
