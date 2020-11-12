using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphocsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string curFileName;
        private System.Drawing.Bitmap curBitmap;

        private void open_Click(object sender, EventArgs e)
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
        private void amplify_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            float x = (float)double.Parse(zoomText.Text);
            SolidBrush brush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            g.FillRectangle(brush, rect);
            if (curBitmap != null)
            {
                g.DrawImage(curBitmap, 200, 20, curBitmap.Width / 2 * x, curBitmap.Height / 2 * x);
            }
            brush.Dispose();
        }

        private void close_Click(object sender, EventArgs e)
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
                g.DrawImage(curBitmap, 200 , 20, curBitmap.Width/2, curBitmap.Height/2);
                g.DrawImage(curBitmap, 200, 300, curBitmap.Width/2, curBitmap.Height/2);
            }
        }

        private void reduce_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();   //创建画图对象并创建画布
            //创建画刷并指定 颜色
            SolidBrush brush = new SolidBrush(Color.White);
            //选择指定区域
            Rectangle rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            //在指定区域填充指定颜色
            g.FillRectangle(brush, rect);
            //获取缩放比例
            float x = (float)double.Parse(zoomText.Text);
            if (curBitmap != null)
            {
                //按给出的缩放比例缩小
                g.ScaleTransform(x, x);
                //rect = new Rectangle(200, 20, curBitmap.Width/2, curBitmap.Height/2);
                // DrawImage(Image, Rectangle, Rectangle, GraphicsUnit)  在指定位置并且按指定大小绘制指定的 Image 的指定部分。
                g.DrawImage(curBitmap, rect, 0, 0, curBitmap.Width, curBitmap.Height, GraphicsUnit.Pixel);
            }
        }

        private void translation_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            float x = (float)double.Parse(translationText.Text);
            // float y = (float)double.Parse(yoffText.Text);
            //指定填充的颜色
            SolidBrush brush = new SolidBrush(Color.White);
            //选择指定区域
            Rectangle rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            //在指定区域填充指定颜色
            g.FillRectangle(brush, rect);
            if (curBitmap != null)
            {
                g.TranslateTransform(x, x);
                g.DrawImage(curBitmap, 200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            }

        }

        private void rotate_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //指定填充的颜色
            SolidBrush brush = new SolidBrush(Color.White);
            //选择指定区域
            Rectangle rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            //在指定区域填充指定颜色
            g.FillRectangle(brush, rect);
            //获取旋转的角度
            float x = (float)double.Parse(angleText.Text);
            if (curBitmap != null)
            {
                g.RotateTransform(x);
                //rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
                g.DrawImage(curBitmap, rect, 0, 0, curBitmap.Width, curBitmap.Height, GraphicsUnit.Pixel);

            }
        }

        private void choose_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //指定填充的颜色
            SolidBrush brush = new SolidBrush(Color.White);
            //选择指定区域
            Rectangle rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            //在指定区域填充指定颜色
            g.FillRectangle(brush, rect);
            if (curBitmap != null)
            {
                RectangleF destRect = new RectangleF(200.0F, 20.0F, curBitmap.Width / 4F, curBitmap.Height / 4F);
                RectangleF srcRect = new RectangleF(0.0F, 0.0F, curBitmap.Width / 1.0F, curBitmap.Height / 1.0F);
                GraphicsUnit units = GraphicsUnit.Pixel;
                g.DrawImage(curBitmap, destRect, srcRect, units);
            }

        }

        private void angulation_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            //指定填充的颜色
            SolidBrush brush = new SolidBrush(Color.White);
            //选择指定区域
            Rectangle rect = new Rectangle(200, 20, curBitmap.Width / 2, curBitmap.Height / 2);
            //在指定区域填充指定颜色
            g.FillRectangle(brush, rect);
            if (curBitmap != null)
            {
                Point ulComer = new Point(200, 20);     //原图左上角坐标 
                Point urComer = new Point(curBitmap.Width / 2, 40);   //在图像右上角坐标
                Point llComer = new Point(curBitmap.Width / 2, curBitmap.Height / 2);   //原图像左下角坐标
                Point[] destPara = { ulComer, urComer, llComer };
                g.DrawImage(curBitmap, destPara);
            }
        }
    }
}


