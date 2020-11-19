using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometricOperationForm
{
    public partial class ModelForm : Form
    {
        public ModelForm()
        {
            InitializeComponent();
        }
        private string curFileName;
        private System.Drawing.Bitmap curBitmap;
        private void translation_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                Translation traForm = new Translation();
                if (traForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = bmpData.Stride * bmpData.Height;
                    byte[] grayValue = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValue, 0, bytes);
                    int x = Convert.ToInt32(traForm.GetXOffset);
                    int y = Convert.ToInt32(traForm.GetYOffset);
                    byte[] tempArray = new byte[bytes];
                    for (int i = 0; i < bytes; i++)   //实现对空余的位置设置为白色
                    {
                        tempArray[i] = 255;
                    }
                    for (int i = 0; i < curBitmap.Height; i++)
                    {
                        if ((i + y) < curBitmap.Height && (i + y) > 0)
                            for (int j = 0; j < bmpData.Stride; j += 3)
                            {
                                if ((j + x * 3) < bmpData.Stride && (j + x * 3) > 0)
                                {
                                    tempArray[(j + x * 3) + 0 + (i + y) * bmpData.Stride] = grayValue[j + 0 + i * bmpData.Stride];
                                    tempArray[(j + x * 3) + 1 + (i + y) * bmpData.Stride] = grayValue[j + 1 + i * bmpData.Stride];
                                    tempArray[(j + x * 3) + 2 + (i + y) * bmpData.Stride] = grayValue[j + 2 + i * bmpData.Stride];
                                }
                            }
                    }
                    grayValue = (byte[])tempArray.Clone();
                    //for(int  i=0;i<bytes;i++)
                    //grayValue[i]=tempArray[i];
                    System.Runtime.InteropServices.Marshal.Copy(grayValue, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }
                Invalidate();
            }
        }

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



        private void ModelForm_Paint(object sender, PaintEventArgs e)
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

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mirror_Click(object sender, EventArgs e)
        {
            if (curBitmap != null)
            {
                //
                Mirror mirForm = new Mirror();
                if (mirForm.ShowDialog() == DialogResult.OK)
                {
                    Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
                    System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, curBitmap.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = bmpData.Stride * curBitmap.Height;
                    byte[] grayValue = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, grayValue, 0, bytes);
                    //水平中轴
                    int halfWidth = curBitmap.Width / 2;
                    //垂直中轴
                    int halfHeight = curBitmap.Height / 2;
                    byte temp;

                    if (mirForm.GetMirror)
                    {
                        //水平镜像处理
                        for (int j = 0; j< curBitmap.Height; j++)
                        {
                            for (int i = 0; i< halfWidth;i++)
                            {
                                //以水平中轴为对称轴，两边像素值互换
                                temp = grayValue[j * bmpData.Stride + i*3];
                                grayValue[j * bmpData.Stride + i*3] = grayValue[j * bmpData.Stride +( curBitmap.Width - (1 + i))*3];
                                grayValue[j * bmpData.Stride + (curBitmap.Width - (1 + i))*3] = temp;

                                temp = grayValue[1 + j * bmpData.Stride + i*3];
                                grayValue[1 + j * bmpData.Stride + i*3] = grayValue[1 + j * bmpData.Stride + (curBitmap.Width - (1 + i))*3];
                                grayValue[1 + j * bmpData.Stride + (curBitmap.Width - (1 + i))*3] = temp;

                                temp = grayValue[2+j * bmpData.Stride + i*3];
                                grayValue[2 + j * bmpData.Stride + i*3] = grayValue[2+j * bmpData.Stride + (curBitmap.Width - (1 + i))*3];
                                grayValue[2 + j * bmpData.Stride + (curBitmap.Width - (1 + i))*3] = temp;
                            }
                        }
                    }
                    else
                    {
                        //垂直镜像处理
                        for (int j = 0; j < curBitmap.Width;j++)
                        {
                            for (int i = 0; i < halfHeight; i++)
                            {
                                //以垂直中轴线为对称轴，两边像素互换
                                temp = grayValue[i * bmpData.Stride + j * 3];
                                grayValue[i * bmpData.Stride + j * 3] = grayValue[(curBitmap.Height - i - 1) * bmpData.Stride + j * 3];
                                grayValue[(curBitmap.Height - i - 1) * bmpData.Stride + j * 3] = temp;

                                temp = grayValue[1 + i * bmpData.Stride + j * 3];
                                grayValue[1 + i * bmpData.Stride + j * 3] = grayValue[1 + (curBitmap.Height - i - 1) * bmpData.Stride +j * 3];
                                grayValue[1 + (curBitmap.Height - i - 1) * bmpData.Stride + j * 3] = temp;

                                temp = grayValue[2 + i * bmpData.Stride + j * 3];
                                grayValue[2 + i * bmpData.Stride + j * 3] = grayValue[2 + (curBitmap.Height - i - 1) * bmpData.Stride + j * 3];
                                grayValue[2 + (curBitmap.Height - i - 1) * bmpData.Stride + j * 3] = temp;

                            }

                        }
                    }
                    System.Runtime.InteropServices.Marshal.Copy(grayValue, 0, ptr, bytes);
                    curBitmap.UnlockBits(bmpData);
                }
                Invalidate();
            }
        }
    }
}
