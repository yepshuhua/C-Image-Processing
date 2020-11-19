using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChangeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string curFileName;
        private System.Drawing.Bitmap curBitmap;
        private void Open_Click(object sender, EventArgs e)
        {
            //创建openFileDialog
            OpenFileDialog opnlg = new OpenFileDialog();
            //为图像选择一个筛选器
            opnlg.Filter = "所有图像｜*.bmp;*.pcx;*.png;*,jpg;*.gif;" + "*.tif;*.ico;*.dxf;*.cgm;*.cdr;*.wmf'*.eps;.emf|" +
                "位图(*.bmp;*.jpg;*.png;...)|*.bmp;*.pcx;*.png;*.jpg;*.gif;*.tif;*.ico|" +
                "矢量图（*.wmf;*.eps;*.emf;...)|*.dxf;*.cgm;*.cdr;*.wmf;*.eps;*.emf|";
            //设置对话框标题
            opnlg.Title = "打开图像文件";
            //启动”帮助“按钮
            opnlg.ShowHelp = true;
            //如果结果为打开，选定文件
            if (opnlg.ShowDialog() == DialogResult.OK)
            {

                curFileName = opnlg.FileName;    //读取当前选中的文件名
                //使用Image.fromFile创建图像对象
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(curFileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message); //抛出异常
                }
            }
            Invalidate(); //对窗体进行重新绘制，这将强行执行paint事件处理程序
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //获取Graphics对象
            Graphics g = e.Graphics;
            if (curBitmap != null)
            {
                //使用DrawImage方法绘制图像
                //160，20：显示在主窗体内，图像左上角的坐标
                //curBitmap.Width,curBitmap.Height:图像的宽度和高度
                g.DrawImage(curBitmap, 200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
                g.DrawImage(curBitmap, 200, 300, curBitmap.Width / 2, curBitmap.Height / 2);
            }
        }

        private void rainbow_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                int width = curBitmap.Width;
                int height = curBitmap.Height;
                for (int i = 0; i < width - 1; i++)
                {
                    for (int j = 0; j < height - 1; j++)
                    {
                        Color cc1 = curBitmap.GetPixel(i, j);
                        Color cc2 = curBitmap.GetPixel(i, j + 1);
                        Color cc3 = curBitmap.GetPixel(i + 1, j);
                        int rr = 2 * (int)Math.Sqrt((cc3.R - cc1.R) * (cc3.R - cc1.R) + (cc2.R - cc1.R) * (cc2.R - cc1.R));
                        int gg = 2 * (int)Math.Sqrt((cc3.G - cc1.G) * (cc3.G - cc1.G) + (cc2.G - cc1.G) * (cc2.G - cc1.G));
                        int bb = 2 * (int)Math.Sqrt((cc3.B - cc1.B) * (cc3.B - cc1.B) + (cc2.B - cc1.B) * (cc2.B - cc1.B));
                        if (rr > 255) rr = 255;
                        if (gg > 255) gg = 255;
                        if (bb > 255) bb = 255;
                        curBitmap.SetPixel(i, j, Color.FromArgb(rr, gg, bb));
                    }
                }
            }
            Graphics g = this.CreateGraphics();
            Rectangle rect1 = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            // DrawImage(Image, Rectangle, Rectangle, GraphicsUnit)  在指定位置并且按指定大小绘制指定的 Image 的指定部分。
            g.DrawImage(curBitmap, rect1, 0, 0, curBitmap.Width, curBitmap.Height, GraphicsUnit.Pixel);

        }

        private void relief_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {

                int width = curBitmap.Width;
                int height = curBitmap.Height;
                for (int i = 0; i < width - 1; i++)
                {
                    for (int j = 0; j < height - 1; j++)
                    {
                        Color c1 = curBitmap.GetPixel(i, j);
                        Color c2 = curBitmap.GetPixel(i + 1, j);
                        int rr = Math.Abs(c1.R - c2.R + 128);
                        int gg = Math.Abs(c1.G - c2.G + 128);
                        int bb = Math.Abs(c1.B - c2.B + 128);
                        if (rr > 255) rr = 255;
                        if (rr < 0) rr = 0;
                        if (gg > 255) gg = 255;
                        if (gg < 0) gg = 0;
                        if (bb > 255) bb = 255;
                        if (bb < 0) bb = 0;

                        curBitmap.SetPixel(i, j, Color.FromArgb(rr, gg, bb));
                    }
                }
            }
            Graphics g = this.CreateGraphics();
            Rectangle rect1 = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            g.DrawImage(curBitmap, rect1, 0, 0, curBitmap.Width, curBitmap.Height, GraphicsUnit.Pixel);
        }

        private void black_Click(object sender, EventArgs e)
        {
            int type = (int)double.Parse(textBox1.Text);
            if (curBitmap != null)
            {
                unsafe
                {
                    int width = curBitmap.Width;
                    int height = curBitmap.Height;
                    Rectangle rect = new Rectangle(0, 0, width, height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits
                            (rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    //24位bmp位图字节数
                    int bytes = curBitmap.Width * curBitmap.Height * 3;
                    //定义位图数组
                    byte[] rgbValues = new byte[bytes];
                    //复制被锁定的位图像素值到该数组内
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                    double colorTemp = 0;
                    for (int i = 0; i < rgbValues.Length; i += 3)
                    {
                        int r, g, b;
                        r = rgbValues[i + 2];
                        g = rgbValues[i + 1];
                        b = rgbValues[i];

                        switch (type)
                        {
                            case 0://平均值法
                                colorTemp = ((r + g + b) / 3);
                                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)colorTemp;
                                break;
                            case 1://最大值法
                                colorTemp = r > g ? r : g;
                                colorTemp = colorTemp > b ? colorTemp : b;
                                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)colorTemp;
                                break;
                            case 2://加权平均值法

                                colorTemp = (int)((0.229 * r) + (int)(0.587 * g) + (int)(0.114 * b));
                                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)colorTemp;
                                break;
                        }
                    }
                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }
            }
            Graphics g1 = this.CreateGraphics();
            Rectangle rect1 = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            g1.DrawImage(curBitmap, rect1, 0, 0, curBitmap.Width, curBitmap.Height, GraphicsUnit.Pixel);
        }

    }
}