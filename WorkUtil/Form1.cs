using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WorkUtil.Entity;
using WorkUtil.Interface;
using WorkUtil.Util;

namespace WorkUtil
{
    public partial class Form1 : Form
    {
        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        private const int COPY_KEYID = 10; //热键ID（自定义）
        private const int PASTE_KEYID = 20; //热键ID（自定义）


        private List<HotKey> list;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.checkBox1.Checked = true;
            //list = SerializeUtil<List<HotKey>>.deSerializeNow("date.dat");
            this.dgv.DataSource = list;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            IHotKey aucInputKey = new FrmInputKey();
            HotKey hotKey = aucInputKey.getHotKey(new HotKey());
        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    if (msg.WParam.ToInt32() == COPY_KEYID)
                    {
                        SendKeys.Send("^c");
                    }
                    else if (msg.WParam.ToInt32() == PASTE_KEYID)
                    {
                        SendKeys.Send("^v");
                    }
                    break;
                case WM_CREATE:
                    //SystemHotKeyUtil.RegHotKey(this.Handle, COPY_KEYID, SystemHotKeyUtil.KeyModifiers.None, Keys.F1);
                    //SystemHotKeyUtil.RegHotKey(this.Handle, PASTE_KEYID, SystemHotKeyUtil.KeyModifiers.None, Keys.F2);
                    break;
                case WM_DESTROY:
                    SystemHotKeyUtil.UnregisterHotKey(this.Handle, COPY_KEYID);
                    SystemHotKeyUtil.UnregisterHotKey(this.Handle, PASTE_KEYID);
                    break;
                default:
                    break;
            }
        }

        private void creatHotkey()
        {
            //if (list.Count < 1)
            //{
            //    return;
            //}
            //foreach (var item in list)
            //{
            //    SystemHotKeyUtil.RegHotKey(this.Handle
            //        , item.HotKeyID
            //        , SystemHotKeyUtil.KeyModifiers.None
            //        , Keys.F1);
            //}
            SystemHotKeyUtil.RegHotKey(this.Handle, COPY_KEYID, SystemHotKeyUtil.KeyModifiers.None, Keys.F1);
            SystemHotKeyUtil.RegHotKey(this.Handle, PASTE_KEYID, SystemHotKeyUtil.KeyModifiers.None, Keys.F3);
        }

        private void distory()
        {
            SystemHotKeyUtil.UnregisterHotKey(this.Handle, COPY_KEYID);
            SystemHotKeyUtil.UnregisterHotKey(this.Handle, PASTE_KEYID);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                creatHotkey();
            }
            else
            {
                distory();
            }
        }
    }
}
