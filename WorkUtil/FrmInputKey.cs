using System;
using System.Text;
using System.Windows.Forms;
using WorkUtil.Entity;
using WorkUtil.Interface;

namespace WorkUtil
{
    partial class FrmInputKey : Form, IHotKey
    {

        private HotKey hotKey = new HotKey();
        public FrmInputKey()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.Text = "编辑或添加";
            this.txtRowKeys.KeyDown += TxtKeys_KeyDown;
            this.txtSendKeys.KeyDown += TxtKeys_KeyDown;
        }

        private void TxtKeys_KeyDown(object sender, KeyEventArgs e)
        {
            Control control = (Control)sender;
            InputKey inputkey = new InputKey();

            StringBuilder sendKey = new StringBuilder();
            StringBuilder txtShow = new StringBuilder();

            control.Text = string.Empty;
            if (e.Modifiers != 0)
            {
                inputkey.Modifiers = e.Modifiers;
            }
            string keyStr = string.Empty;
            if ((e.KeyValue >= 33 && e.KeyValue <= 40)
                || (e.KeyValue >= 65 && e.KeyValue <= 90)
                || (e.KeyValue >= 112 && e.KeyValue <= 123))
            {
                inputkey.Keys = e.KeyCode;
                keyStr = e.KeyCode.ToString();
            }
            else if ((e.KeyValue >= 48 && e.KeyValue <= 57))
            {
                inputkey.Keys = e.KeyCode;
                keyStr = e.KeyCode.ToString().Substring(1);
            }

            txtShow.Append(keyStr);
            sendKey.Append(keyStr);

            control.Text = txtShow.ToString();
            control.Tag = sendKey.ToString();
        }

        public HotKey getHotKey(HotKey hotKey)
        {
            this.hotKey = hotKey;
            if (this.ShowDialog() != DialogResult.OK)
            {
                return hotKey;
            }

            hotKey.HotKeyID = Convert.ToInt32(this.txtHotKeyId.Text);

            return hotKey;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
