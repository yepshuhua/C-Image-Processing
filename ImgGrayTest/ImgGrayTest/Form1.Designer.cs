namespace ImgGrayTest
{
    partial class ImgGrayTest
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
            this.Open = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.Pixel = new System.Windows.Forms.Button();
            this.Menory = new System.Windows.Forms.Button();
            this.pointer = new System.Windows.Forms.Button();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(37, 46);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 0;
            this.Open.Text = "打开图片";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(37, 92);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "保存图片";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(37, 138);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 2;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Pixel
            // 
            this.Pixel.Location = new System.Drawing.Point(37, 200);
            this.Pixel.Name = "Pixel";
            this.Pixel.Size = new System.Drawing.Size(75, 23);
            this.Pixel.TabIndex = 3;
            this.Pixel.Text = "提取像素法";
            this.Pixel.UseVisualStyleBackColor = true;
            this.Pixel.Click += new System.EventHandler(this.Pixel_Click);
            // 
            // Menory
            // 
            this.Menory.Location = new System.Drawing.Point(37, 246);
            this.Menory.Name = "Menory";
            this.Menory.Size = new System.Drawing.Size(75, 23);
            this.Menory.TabIndex = 4;
            this.Menory.Text = "内存法";
            this.Menory.UseVisualStyleBackColor = true;
            this.Menory.Click += new System.EventHandler(this.Menory_Click);
            // 
            // pointer
            // 
            this.pointer.Location = new System.Drawing.Point(37, 292);
            this.pointer.Name = "pointer";
            this.pointer.Size = new System.Drawing.Size(75, 23);
            this.pointer.TabIndex = 5;
            this.pointer.Text = "指针法";
            this.pointer.UseVisualStyleBackColor = true;
            this.pointer.Click += new System.EventHandler(this.pointer_Click);
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(37, 375);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(100, 21);
            this.timeBox.TabIndex = 6;
            this.timeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "运行时间：";
            // 
            // ImgGrayTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.pointer);
            this.Controls.Add(this.Menory);
            this.Controls.Add(this.Pixel);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Open);
            this.Name = "ImgGrayTest";
            this.Text = "ImgGrayTest";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImgGrayTest_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Pixel;
        private System.Windows.Forms.Button Menory;
        private System.Windows.Forms.Button pointer;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label label1;
    }
}

