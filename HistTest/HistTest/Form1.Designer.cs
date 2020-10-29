namespace HistTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Close = new System.Windows.Forms.Button();
            this.histogram = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.LinearPO = new System.Windows.Forms.Button();
            this.stretch = new System.Windows.Forms.Button();
            this.equalization = new System.Windows.Forms.Button();
            this.shaping = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(37, 92);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(37, 150);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(75, 23);
            this.histogram.TabIndex = 2;
            this.histogram.Text = "绘制直方图";
            this.histogram.UseVisualStyleBackColor = true;
            this.histogram.Click += new System.EventHandler(this.histogram_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(37, 46);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 3;
            this.Open.Text = "打开图像";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // LinearPO
            // 
            this.LinearPO.Location = new System.Drawing.Point(37, 196);
            this.LinearPO.Name = "LinearPO";
            this.LinearPO.Size = new System.Drawing.Size(75, 23);
            this.LinearPO.TabIndex = 4;
            this.LinearPO.Text = "线性点运算";
            this.LinearPO.UseVisualStyleBackColor = true;
            this.LinearPO.Click += new System.EventHandler(this.LinearPO_Click);
            // 
            // stretch
            // 
            this.stretch.Location = new System.Drawing.Point(37, 242);
            this.stretch.Name = "stretch";
            this.stretch.Size = new System.Drawing.Size(75, 23);
            this.stretch.TabIndex = 5;
            this.stretch.Text = "灰度拉伸";
            this.stretch.UseVisualStyleBackColor = true;
            this.stretch.Click += new System.EventHandler(this.stretch_Click);
            // 
            // equalization
            // 
            this.equalization.Location = new System.Drawing.Point(37, 288);
            this.equalization.Name = "equalization";
            this.equalization.Size = new System.Drawing.Size(75, 23);
            this.equalization.TabIndex = 6;
            this.equalization.Text = "直方图均衡";
            this.equalization.UseVisualStyleBackColor = true;
            this.equalization.Click += new System.EventHandler(this.equalization_Click);
            // 
            // shaping
            // 
            this.shaping.Location = new System.Drawing.Point(37, 334);
            this.shaping.Name = "shaping";
            this.shaping.Size = new System.Drawing.Size(75, 23);
            this.shaping.TabIndex = 7;
            this.shaping.Text = "直方图匹配";
            this.shaping.UseVisualStyleBackColor = true;
            this.shaping.Click += new System.EventHandler(this.shaping_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.shaping);
            this.Controls.Add(this.equalization);
            this.Controls.Add(this.stretch);
            this.Controls.Add(this.LinearPO);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.Close);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button histogram;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button LinearPO;
        private System.Windows.Forms.Button stretch;
        private System.Windows.Forms.Button equalization;
        private System.Windows.Forms.Button shaping;
    }
}

