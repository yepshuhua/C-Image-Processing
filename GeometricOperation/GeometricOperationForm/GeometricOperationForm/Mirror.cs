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
    public partial class Mirror : Form
    {
        public Mirror()
        {
            InitializeComponent();
        }

        private void StartMirror_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public bool GetMirror
        {
            get
            {
                //得到的是水平镜像还垂直镜像
                return horMirror.Checked;
            }
        }
    }
}
