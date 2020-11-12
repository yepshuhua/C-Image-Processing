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
    public partial class Translation : Form
    {
        public Translation()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string GetXOffset
        {
            get
            {
                //横向平移量
                return xOffset.Text;
            }
        }
        public string GetYOffset
        {
            get
            {//纵向平移量
                return yOffset.Text;
            }
        }

    }
}
