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
                g.DrawImage(curBitmap, 160, 20, curBitmap.Width, curBitmap.Height);
            }
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //定义并实例化新窗体，并把图像传递给它
                histForm histform = new histForm(curBitmap);
                //打开窗体histogram
                histform.Show();
            }
        }

        private void LinearPO_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //实例化linearPOForm窗体
                linearPOForm linearForm = new linearPOForm();
                if (linearForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height * 3;
                    byte[] grayValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                    int temp = 0;
                    //string类型转换为double类型
                    //得到斜率
                    double a = Convert.ToDouble(linearForm.GetScaling);
                    //得到偏移量
                    double b = Convert.ToDouble(linearForm.GetOffset);
                    double colorTemp = 0;
                    for (int i = 0; i < grayValues.Length; i += 3)
                    {
                        //利用公式计算灰度值
                        colorTemp = grayValues[i + 2] * 0.229 + grayValues[i + 1] * 0.587 + grayValues[i] * 0.114;
                        //R=G=b
                        grayValues[i] = grayValues[i + 1] = grayValues[i + 2] = (byte)colorTemp;
                    }
                    for (int i = 0; i < grayValues.Length; i += 3)
                    {
                        //根据公式计算线性点运算
                        //加0.5表示四舍五入
                        temp = (int)(a * grayValues[i] + b + 0.5);                        //灰度值限制在0-255之间
                        //大于255，则为255，小于0，则为0
                        if (temp > 255)
                            grayValues[i] = grayValues[i + 1] = grayValues[i + 2] = 255;
                        else if (temp < 0)
                            grayValues[i] = grayValues[i + 1] = grayValues[i + 2] = 0;
                        else
                            grayValues[i] = grayValues[i + 1] = grayValues[i + 2] = (byte)temp;
                    }
                    System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }
                Invalidate();
            }

        }

        private void stretch_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpdata = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpdata.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height * 3;
                byte[] grayvalue = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayvalue, 0, bytes);
                byte a = 255, b = 0;
                double p;
                double colorTemp;
                //计算最大和最小灰度级
                for (int i = 0; i < bytes; i += 3)
                {
                    //利用公式计算灰度值
                    colorTemp = grayvalue[i + 2] * 0.229 + grayvalue[i + 1] * 0.587 + grayvalue[i] * 0.114;
                    //R=G=b
                    grayvalue[i] = grayvalue[i + 1] = grayvalue[i + 2] = (byte)colorTemp;
                    //最小灰度级
                    if (a < grayvalue[i])
                    {
                        a = grayvalue[i];
                    }
                    //最大灰度级
                    if (b > grayvalue[i])
                    {
                        b = grayvalue[i];
                    }
                }
                //得到斜率
                p = 255.0 / (b - a);

                //灰度拉伸
                for (int i = 0; i < bytes; i += 3)
                {
                    //公式应用
                    grayvalue[i] = grayvalue[i + 1] = grayvalue[i + 2] = (byte)(p * ((byte)grayvalue[i] - a) + 0.5);
                }
                System.Runtime.InteropServices.Marshal.Copy(grayvalue, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpdata);
            }
            Invalidate();
        }

        private void equalization_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                System.Drawing.Imaging.BitmapData bmpdata = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                IntPtr ptr = bmpdata.Scan0;
                int bytes = curBitmap.Width * curBitmap.Height*3;
                byte[] grayValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
                byte temp;
                int[] tempArray = new int[256];//实现对每一个灰度级进行累计计算
                int[] countPixel = new int[256];//实现对灰度级为i的像素的累计
                byte[] pixelMap = new byte[256];//实现灰度级在0~255之间的公式计算
                //计算各灰度级的像素个数
                for (int i = 0; i < bytes; i++)
                {
                    //灰度级
                    temp = grayValues[i];
                    //计数加1
                    countPixel[temp]++;
                }
                //计算各灰度级的累计分布函数
                for (int i = 0; i < 256; i++)
                {
                    //公式 （2）的计算
                    if (i != 0)
                    {
                        tempArray[i] = tempArray[i - 1] + countPixel[i];
                    }
                    else
                    {
                        tempArray[0] = countPixel[0];
                    }
                    //计算累计概率函数，并把值扩展到0～255范围内,公式（3）
                    pixelMap[i] = (byte)(255.0 * tempArray[i] / bytes + 0.5);
                }
                //灰度等级映射转换处理
                for (int i = 0; i < bytes; i++)
                {
                    temp = grayValues[i];
                    grayValues[i] = pixelMap[temp];
                }
                System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
                curBitmap.UnlockBits(bmpdata);
                Invalidate();
            }

        }

        private void shaping_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //实例化shapingForm窗体
                shapingForm sForm = new shapingForm();
                if (sForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = curBitmap.Width * curBitmap.Height*3;
                    byte[] grayValue = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValue, 0, bytes);
                    byte temp = 0;
                    double[] PPixel = new double[256];
                    double[] QPixel = new double[256];
                    int[] qPixel = new int[256];
                    int[] tempArray = new int[256];
                    //计算原图像的各灰度级拿给个数
                    for (int i = 0; i < grayValue.Length; i+=3)
                    {
                        // temp = grayValue[i];
                        temp = (byte)(0.229 * grayValue[i + 2] + 0.587 * grayValue[i + 1] + 0.114 * grayValue[i]);
                        grayValue[i] = grayValue[i + 1] = grayValue[i + 2] = temp;
                        qPixel[temp]++;
                    }
                    //计算该灰度级的累积分布函数
                    for (int i = 0; i < 256; i++)
                    {
                        if (i != 0)
                        {
                            tempArray[i] = tempArray[i - 1] + qPixel[i];
                        }
                        else
                        {
                            tempArray[0] = qPixel[0];
                        }
                        QPixel[i] = (double)tempArray[i] / (double)(bmpData.Width*bmpData.Height);
                    }
                    //得到被匹配的直方图的累积分布函数
                    PPixel = sForm.ApplicationP;

                    double diffA, diffB;
                    byte k = 0;
                    byte[] maxPixel = new byte[256];
                    //直方图匹配
                    for (int i = 0; i < 256; i++)
                    {
                        diffB = 1;
                        for (int j = k; j < 256; j++)
                        {
                            //找到两个累计分布函数中最相似的位置
                            diffA = Math.Abs(QPixel[i] - PPixel[j]);
                            if (diffA - diffB < 1.0E-08)
                            {
                                //记下差值
                                diffB = diffA;
                                k = (byte)j;
                            }
                            else
                            {
                                //找到了，记录下位置，并退出内循环
                                k = (byte)(j - 1);
                                break;
                            }
                        }
                        //达到最大灰度级，标识未处理灰度级，并退出外循环
                        if (k == 255)
                        {
                            for (int l = i; l < 256; l++)
                            {
                                maxPixel[l] = k;
                            }
                            break;
                        }
                        //得到映射关系
                        maxPixel[i] = k;
                    }
                    //灰度级映射处理
                    for (int i = 0; i < bytes; i++)
                    {
                        temp = grayValue[i];
                        grayValue[i] = maxPixel[temp];
                    }
                    System.Runtime.InteropServices.Marshal.Copy(grayValue, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }
                Invalidate();
            }
        }
    }
}

