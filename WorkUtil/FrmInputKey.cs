using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkUtil
{
    public partial class FrmInputKey : Form
    {
        public FrmInputKey()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.Text = "请直接在键盘上输入新的快捷键";
        }
    }
}
