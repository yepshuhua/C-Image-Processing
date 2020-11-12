namespace GeometricOperationForm
{
    partial class Mirror
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
            this.Close = new System.Windows.Forms.Button();
            this.StartMirror = new System.Windows.Forms.Button();
            this.图像镜像 = new System.Windows.Forms.GroupBox();
            this.horMirror = new System.Windows.Forms.RadioButton();
            this.verMirror = new System.Windows.Forms.RadioButton();
            this.图像镜像.SuspendLayout();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(155, 170);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 3;
            this.Close.Text = "退出";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // StartMirror
            // 
            this.StartMirror.Location = new System.Drawing.Point(28, 170);
            this.StartMirror.Name = "StartMirror";
            this.StartMirror.Size = new System.Drawing.Size(75, 23);
            this.StartMirror.TabIndex = 2;
            this.StartMirror.Text = "确定";
            this.StartMirror.UseVisualStyleBackColor = true;
            this.StartMirror.Click += new System.EventHandler(this.StartMirror_Click);
            // 
            // 图像镜像
            // 
            this.图像镜像.Controls.Add(this.verMirror);
            this.图像镜像.Controls.Add(this.horMirror);
            this.图像镜像.Location = new System.Drawing.Point(38, 34);
            this.图像镜像.Name = "图像镜像";
            this.图像镜像.Size = new System.Drawing.Size(170, 105);
            this.图像镜像.TabIndex = 4;
            this.图像镜像.TabStop = false;
            this.图像镜像.Text = "图像镜像";
            // 
            // horMirror
            // 
            this.horMirror.AutoSize = true;
            this.horMirror.Checked = true;
            this.horMirror.Location = new System.Drawing.Point(40, 35);
            this.horMirror.Name = "horMirror";
            this.horMirror.Size = new System.Drawing.Size(71, 16);
            this.horMirror.TabIndex = 0;
            this.horMirror.TabStop = true;
            this.horMirror.Text = "水平镜像";
            this.horMirror.UseVisualStyleBackColor = true;
            // 
            // verMirror
            // 
            this.verMirror.AutoSize = true;
            this.verMirror.Location = new System.Drawing.Point(40, 70);
            this.verMirror.Name = "verMirror";
            this.verMirror.Size = new System.Drawing.Size(71, 16);
            this.verMirror.TabIndex = 1;
            this.verMirror.Text = "垂直镜像";
            this.verMirror.UseVisualStyleBackColor = true;
            // 
            // Mirror
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 222);
            this.ControlBox = false;
            this.Controls.Add(this.图像镜像);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.StartMirror);
            this.Name = "Mirror";
            this.Text = "图像镜像";
            this.图像镜像.ResumeLayout(false);
            this.图像镜像.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button StartMirror;
        private System.Windows.Forms.GroupBox 图像镜像;
        private System.Windows.Forms.RadioButton verMirror;
        private System.Windows.Forms.RadioButton horMirror;
    }
}