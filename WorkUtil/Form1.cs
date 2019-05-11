using System;
using System.Windows.Forms;
using WorkUtil.Util;

namespace WorkUtil
{
    public partial class Form1 : Form
    {

        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        private const int COPY_KEYID = 1; //热键ID（自定义）
        private const int PASTE_KEYID = 2; //热键ID（自定义）

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FrmInputKey aucInputKey = new FrmInputKey();
            aucInputKey.Show();
        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    if (msg.WParam.ToInt32() == COPY_KEYID)
                    {
                        System.Windows.Forms.SendKeys.Send("^c");
                    }
                    else if (msg.WParam.ToInt32() == PASTE_KEYID)
                    {
                        System.Windows.Forms.SendKeys.Send("^v");
                    }
                    break;
                case WM_CREATE:
                    SystemHotKeyUtil.RegHotKey(this.Handle, COPY_KEYID, SystemHotKeyUtil.KeyModifiers.None, Keys.F1);
                    SystemHotKeyUtil.RegHotKey(this.Handle, PASTE_KEYID, SystemHotKeyUtil.KeyModifiers.None, Keys.F2);
                    break;
                case WM_DESTROY:
                    SystemHotKeyUtil.UnregisterHotKey(this.Handle, COPY_KEYID);
                    SystemHotKeyUtil.UnregisterHotKey(this.Handle, PASTE_KEYID);
                    break;
                default:
                    break;
            }
        }

        private void hotkey()
        {

        }
    }
}
