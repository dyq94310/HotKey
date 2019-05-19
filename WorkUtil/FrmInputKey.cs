using System;
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

        public FrmInputKey(HotKey hotKey)
        {
            InitializeComponent();
            init();

            this.txtHotKeyId.Text = hotKey.HotKeyId.ToString();
            this.txtHotKeys.Text = hotKey.HotKeys == null ? string.Empty : hotKey.HotKeys.Display;
            this.txtSendKeys.Text = hotKey.SendKey == null ? string.Empty : hotKey.SendKey.Display;
            this.txtNote.Text = hotKey.Note;
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
            inputkey.Display = KeyUtil.getDispaly(inputkey);
            inputkey.Sends = KeyUtil.getSendKey(inputkey);
            ((Control)sender).Text = inputkey.Display;
            ((Control)sender).Tag = inputkey;
        }

        public HotKey getHotKey(HotKey hotKey)
        {
            this.txtHotKeyId.Text = hotKey.HotKeyId.ToString();
            this.txtHotKeys.Text = hotKey.HotKeys == null ? string.Empty : hotKey.HotKeys.Display;
            this.txtSendKeys.Text = hotKey.SendKey == null ? string.Empty : hotKey.SendKey.Display;
            this.txtNote.Text = hotKey.Note;
            if (this.ShowDialog() != DialogResult.OK)
            {
                return hotKey;
            }
            hotKey.HotKeyId = Convert.ToInt32(this.txtHotKeyId.Text);
            hotKey.SendKey = (InputKey)this.txtHotKeys.Tag;
            hotKey.HotKeys = (InputKey)this.txtSendKeys.Tag;
            hotKey.Note = this.txtNote.Text;
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
