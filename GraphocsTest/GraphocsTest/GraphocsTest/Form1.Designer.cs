namespace GraphocsTest
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
            this.open = new System.Windows.Forms.Button();
            this.amplify = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.reduce = new System.Windows.Forms.Button();
            this.rotate = new System.Windows.Forms.Button();
            this.translation = new System.Windows.Forms.Button();
            this.choose = new System.Windows.Forms.Button();
            this.angulation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.angleText = new System.Windows.Forms.TextBox();
            this.translationText = new System.Windows.Forms.TextBox();
            this.zoomText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(37, 46);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 0;
            this.open.Text = "打开图像";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // amplify
            // 
            this.amplify.Location = new System.Drawing.Point(37, 138);
            this.amplify.Name = "amplify";
            this.amplify.Size = new System.Drawing.Size(75, 23);
            this.amplify.TabIndex = 1;
            this.amplify.Text = "放大图像";
            this.amplify.UseVisualStyleBackColor = true;
            this.amplify.Click += new System.EventHandler(this.amplify_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(37, 92);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 2;
            this.close.Text = "关闭";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // reduce
            // 
            this.reduce.Location = new System.Drawing.Point(37, 184);
            this.reduce.Name = "reduce";
            this.reduce.Size = new System.Drawing.Size(75, 23);
            this.reduce.TabIndex = 3;
            this.reduce.Text = "缩小图像";
            this.reduce.UseVisualStyleBackColor = true;
            this.reduce.Click += new System.EventHandler(this.reduce_Click);
            // 
            // rotate
            // 
            this.rotate.Location = new System.Drawing.Point(37, 276);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(75, 23);
            this.rotate.TabIndex = 4;
            this.rotate.Text = "图像旋转";
            this.rotate.UseVisualStyleBackColor = true;
            this.rotate.Click += new System.EventHandler(this.rotate_Click);
            // 
            // translation
            // 
            this.translation.Location = new System.Drawing.Point(37, 230);
            this.translation.Name = "translation";
            this.translation.Size = new System.Drawing.Size(75, 23);
            this.translation.TabIndex = 5;
            this.translation.Text = "图像平移";
            this.translation.UseVisualStyleBackColor = true;
            this.translation.Click += new System.EventHandler(this.translation_Click);
            // 
            // choose
            // 
            this.choose.Location = new System.Drawing.Point(37, 320);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(75, 23);
            this.choose.TabIndex = 7;
            this.choose.Text = "选定";
            this.choose.UseVisualStyleBackColor = true;
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // angulation
            // 
            this.angulation.Location = new System.Drawing.Point(37, 366);
            this.angulation.Name = "angulation";
            this.angulation.Size = new System.Drawing.Size(75, 23);
            this.angulation.TabIndex = 9;
            this.angulation.Text = "图像扭曲";
            this.angulation.UseVisualStyleBackColor = true;
            this.angulation.Click += new System.EventHandler(this.angulation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "旋转角度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "平移量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "缩放比例";
            // 
            // angleText
            // 
            this.angleText.Location = new System.Drawing.Point(81, 409);
            this.angleText.Name = "angleText";
            this.angleText.Size = new System.Drawing.Size(100, 21);
            this.angleText.TabIndex = 13;
            // 
            // translationText
            // 
            this.translationText.Location = new System.Drawing.Point(81, 455);
            this.translationText.Name = "translationText";
            this.translationText.Size = new System.Drawing.Size(100, 21);
            this.translationText.TabIndex = 14;
            // 
            // zoomText
            // 
            this.zoomText.Location = new System.Drawing.Point(81, 501);
            this.zoomText.Name = "zoomText";
            this.zoomText.Size = new System.Drawing.Size(100, 21);
            this.zoomText.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 573);
            this.Controls.Add(this.zoomText);
            this.Controls.Add(this.translationText);
            this.Controls.Add(this.angleText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angulation);
            this.Controls.Add(this.choose);
            this.Controls.Add(this.translation);
            this.Controls.Add(this.rotate);
            this.Controls.Add(this.reduce);
            this.Controls.Add(this.close);
            this.Controls.Add(this.amplify);
            this.Controls.Add(this.open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button amplify;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button reduce;
        private System.Windows.Forms.Button rotate;
        private System.Windows.Forms.Button translation;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.Button angulation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox angleText;
        private System.Windows.Forms.TextBox translationText;
        private System.Windows.Forms.TextBox zoomText;
    }
}

