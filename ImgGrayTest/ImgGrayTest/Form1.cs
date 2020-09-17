using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgGrayTest
{
    public partial class ImgGrayTest : Form
    {
        public ImgGrayTest()
        {
            InitializeComponent();
        }
        private string curFileName;
        private System.Drawing.Bitmap curBitmap;
        //打开图像文件
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

        private void ImgGrayTest_Paint(object sender, PaintEventArgs e)
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
        //保存图像文件
        private void Save_Click(object sender, EventArgs e)
        {
            if (curBitmap == null)
                return;
            SaveFileDialog savelog = new SaveFileDialog(); //调用saveFileDialog
            savelog.Title = "保存为"; //设置对话标题
            savelog.OverwritePrompt = true; //改写已存在文件时提示用户
            savelog.Filter = "BMP文件(*.bmp)|*.bmp|" + "Gif文件（*.gif)|*.gif|" + "JPEG文件(*.jpg)|*.jpg|" + "PNG文件(*.pgn)|*.png"; //为图像选择一个筛选器
            savelog.ShowHelp = true; //启动帮助按钮
                                     //如果选择了格式，则保存图像
            if (savelog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savelog.FileName; //获取用户选择文件
                string strFileExtn = fileName.Remove(0, fileName.Length - 3); //获取用户选择文件的扩展名
                switch (strFileExtn) //保存文件
                {
                    case "bmp":  //bmp格式
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case "jpg": //jpg格式
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case "gif": //gif格式
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case "tif": //tif格式
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case "png":
                        //png格式
                        curBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png); break; ;
                    default: break;
                }
            }

        }
        //关闭窗口
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pixel_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                Color curColor;
                int ret;
                for(int i = 0; i < curBitmap.Width; i++)//二维数组循环
                {
                    for(int j = 0; j < curBitmap.Height; j++)
                    {
                        curColor = curBitmap.GetPixel(i, j);//获取该点像素的RGB值
                        ret = (int)(curColor.R * 0.2229 + curColor.G * 0.587 + curColor.B * 0.114);//计算灰度值
                        curBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));//设置像素点的灰度值R=G=B=ret
                    }
                }
            }
            Invalidate(); //对窗体进行重新绘制，这将强行执行paint事件处理程序 
        }

        private void Menory_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //位图矩形
                Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                //以可读写方式锁定全部位图像素
                System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits
                    (rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                //获得首地址
                IntPtr ptr = bmpData.Scan0;
                //24位bmp位图字节数
                int bytes = curBitmap.Width * curBitmap.Height * 3;
                //定义位图数组
                byte[] rgbValues = new byte[bytes];
                //复制被锁定的位图像素值到该数组内
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                //灰度化
                double colorTemp = 0;
            }
        }
    }
}
