using System;
using System.Text;
using System.Windows.Forms;
using WorkUtil.Entity;
using WorkUtil.Interface;
using WorkUtil.Util;

namespace WorkUtil
{
    partial class FrmInputKey : Form, IHotKey
    {
        public FrmInputKey()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.Text = "编辑或添加";
            this.txtHotKeys.KeyDown += TxtKeys_KeyDown;
            this.txtSendKeys.KeyDown += TxtKeys_KeyDown;
        }

        private void TxtKeys_KeyDown(object sender, KeyEventArgs e)
        {
            InputKey inputkey = new InputKey();
            if (e.Modifiers != 0)
            {
                inputkey.Modifiers = e.Modifiers;
            }
            inputkey.Keys = e.KeyCode;
            ((Control)sender).Text = KeyUtil.getDispaly(inputkey);
            ((Control)sender).Tag = inputkey;
        }

        public HotKey getHotKey(HotKey hotKey)
        {
            this.txtHotKeyId.Text = hotKey.HotKeyID.ToString();
            this.txtHotKeys.Text = KeyUtil.getDispaly(hotKey.HotKeys);
            this.txtSendKeys.Text = KeyUtil.getDispaly(hotKey.SendKey);

            if (this.ShowDialog() != DialogResult.OK)
            {
                return hotKey;
            }
            hotKey.HotKeyID = Convert.ToInt32(this.txtHotKeyId.Text);
            hotKey.HotKeys = (InputKey)this.txtHotKeys.Tag;
            hotKey.SendKey = (InputKey)this.txtSendKeys.Tag;
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
