namespace HistTest
{
    partial class linearPOForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartLinear = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scaling = new System.Windows.Forms.TextBox();
            this.Offset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartLinear
            // 
            this.StartLinear.Location = new System.Drawing.Point(26, 160);
            this.StartLinear.Name = "StartLinear";
            this.StartLinear.Size = new System.Drawing.Size(75, 23);
            this.StartLinear.TabIndex = 0;
            this.StartLinear.Text = "确定";
            this.StartLinear.UseVisualStyleBackColor = true;
            this.StartLinear.Click += new System.EventHandler(this.StartLinear_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(150, 160);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 1;
            this.Close.Text = "退出";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "线性点运算:g(x,y)=pf(x,y)+L";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "斜率(P):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "偏移量(L):";
            // 
            // scaling
            // 
            this.scaling.Location = new System.Drawing.Point(101, 66);
            this.scaling.Name = "scaling";
            this.scaling.Size = new System.Drawing.Size(100, 21);
            this.scaling.TabIndex = 5;
            this.scaling.Text = "1";
            // 
            // Offset
            // 
            this.Offset.Location = new System.Drawing.Point(101, 109);
            this.Offset.Name = "Offset";
            this.Offset.Size = new System.Drawing.Size(100, 21);
            this.Offset.TabIndex = 6;
            this.Offset.Text = "0";
            // 
            // linearPOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 202);
            this.ControlBox = false;
            this.Controls.Add(this.Offset);
            this.Controls.Add(this.scaling);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.StartLinear);
            this.Name = "linearPOForm";
            this.Text = "线性点运算";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartLinear;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox scaling;
        private System.Windows.Forms.TextBox Offset;
    }
}