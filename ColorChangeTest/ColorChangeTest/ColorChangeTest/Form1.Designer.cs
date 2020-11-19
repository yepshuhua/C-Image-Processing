namespace ColorChangeTest
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
            this.Open = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.rainbow = new System.Windows.Forms.Button();
            this.relief = new System.Windows.Forms.Button();
            this.black = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(65, 55);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 5;
            this.Open.Text = "打开图像";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(65, 108);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 6;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // rainbow
            // 
            this.rainbow.Location = new System.Drawing.Point(65, 165);
            this.rainbow.Name = "rainbow";
            this.rainbow.Size = new System.Drawing.Size(75, 23);
            this.rainbow.TabIndex = 7;
            this.rainbow.Text = "霓虹处理";
            this.rainbow.UseVisualStyleBackColor = true;
            this.rainbow.Click += new System.EventHandler(this.rainbow_Click);
            // 
            // relief
            // 
            this.relief.Location = new System.Drawing.Point(65, 219);
            this.relief.Name = "relief";
            this.relief.Size = new System.Drawing.Size(75, 23);
            this.relief.TabIndex = 8;
            this.relief.Text = "浮雕处理";
            this.relief.UseVisualStyleBackColor = true;
            this.relief.Click += new System.EventHandler(this.relief_Click);
            // 
            // black
            // 
            this.black.Location = new System.Drawing.Point(65, 283);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(75, 23);
            this.black.TabIndex = 9;
            this.black.Text = "黑化处理";
            this.black.UseVisualStyleBackColor = true;
            this.black.Click += new System.EventHandler(this.black_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "算法选择";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 371);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.black);
            this.Controls.Add(this.relief);
            this.Controls.Add(this.rainbow);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button rainbow;
        private System.Windows.Forms.Button relief;
        private System.Windows.Forms.Button black;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

