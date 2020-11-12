namespace GeometricOperationForm
{
    partial class ModelForm
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
            this.Open = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.translation = new System.Windows.Forms.Button();
            this.mirror = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(37, 46);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 4;
            this.Open.Text = "打开图像";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(37, 92);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 5;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // translation
            // 
            this.translation.Location = new System.Drawing.Point(37, 150);
            this.translation.Name = "translation";
            this.translation.Size = new System.Drawing.Size(75, 23);
            this.translation.TabIndex = 6;
            this.translation.Text = "图像平移";
            this.translation.UseVisualStyleBackColor = true;
            this.translation.Click += new System.EventHandler(this.translation_Click);
            // 
            // mirror
            // 
            this.mirror.Location = new System.Drawing.Point(37, 196);
            this.mirror.Name = "mirror";
            this.mirror.Size = new System.Drawing.Size(75, 23);
            this.mirror.TabIndex = 7;
            this.mirror.Text = "图像镜像";
            this.mirror.UseVisualStyleBackColor = true;
            this.mirror.Click += new System.EventHandler(this.mirror_Click);
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mirror);
            this.Controls.Add(this.translation);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Open);
            this.Name = "ModelForm";
            this.Text = "ModleForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ModelForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button translation;
        private System.Windows.Forms.Button mirror;
    }
}