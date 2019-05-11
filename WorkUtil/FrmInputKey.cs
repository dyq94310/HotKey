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
