using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkUtil.Util;

namespace WorkUtil
{
    public partial class Form1 : Form
    {

        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        private const int HotKeyID = 1; //热键ID（自定义）

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
                case WM_HOTKEY: //窗口消息：热键
                    int tmpWParam = msg.WParam.ToInt32();
                    if (tmpWParam == HotKeyID)
                    {
                        System.Windows.Forms.SendKeys.Send("^v");
                    }
                    break;
                case WM_CREATE: //窗口消息：创建
                    SystemHotKeyUtil.RegHotKey(this.Handle, HotKeyID, SystemHotKeyUtil.KeyModifiers.None, Keys.F1);
                    break;
                case WM_DESTROY: //窗口消息：销毁
                    SystemHotKeyUtil.UnregisterHotKey(this.Handle, HotKeyID); //销毁热键
                    break;
                default:
                    break;
            }
        }
    }
}
