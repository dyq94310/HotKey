using Common.Utils;
using Common.Utils.PublicEntity;
using System;
using System.Collections.Generic;
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

        private const string SAVE_FILE = "date.dat";

        /// <summary>
        /// 热键集合
        /// </summary>
        private List<HotKey> list;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            try
            {
                list = SerializeUtil<List<HotKey>>.deSerializeNow(SAVE_FILE);
            }
            catch
            {
                list = new List<HotKey>();
            }

            List<KeyValue> columns = new List<KeyValue>
            {
                new KeyValue("HotKeyId", "热键ID"),
                new KeyValue("Note", "备注")
            };
            ControlUtil.setDgvNormal(dgv);
            ControlUtil.setDgvColumn(dgv, columns);
            dgv.DataSource = list;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            InsertHotKey();
        }

        private void InsertHotKey()
        {
            IHotKey aucInputKey = new FrmInputKey();
            HotKey hotKey = aucInputKey.getHotKey(new HotKey());
            if (hotKey.HotKeys == null)
            {
                return;
            }

            list.Add(hotKey);
            this.dgv.DataSource = null;
            this.dgv.DataSource = list;
        }

        private void updateHotKey(HotKey hk)
        {
            this.dgv.DataSource = null;
            list.Remove(hk);
            IHotKey aucInputKey = new FrmInputKey();
            HotKey hotKey = aucInputKey.getHotKey(hk);
            list.Add(hotKey);
            this.dgv.DataSource = list;
        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    sendKey(msg.WParam.ToInt32());
                    break;
                case WM_CREATE:
                    //creatHotkey();
                    break;
                case WM_DESTROY:
                    distory();
                    break;
                default:
                    break;
            }
        }

        private void creatHotkey()
        {
            if (list == null)
            {
                return;
            }
            foreach (var item in list)
            {
                SystemHotKeyUtil.RegHotKey(this.Handle
                    , item.HotKeyId
                    , item.HotKeys.Modifiers
                    , item.HotKeys.Keys);
            }
        }

        private void distory()
        {
            if (list == null)
            {
                return;
            }
            foreach (var item in list)
            {
                SystemHotKeyUtil.UnregisterHotKey(this.Handle
                    , item.HotKeyId);
            }
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

        private void sendKey(int hotkeyId)
        {
            if (list == null)
            {
                return;
            }
            foreach (var item in list)
            {
                if (item.HotKeyId == hotkeyId)
                {
                    SendKeys.Send(item.SendKey.Sends);
                    return;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SerializeUtil<List<HotKey>>.serializeNow(list, SAVE_FILE);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确的删除当前热键", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                list.RemoveAt(this.dgv.CurrentRow.Index);
                this.dgv.DataSource = null;
                this.dgv.DataSource = list;
            }
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HotKey hotKey = list[this.dgv.CurrentRow.Index];
            updateHotKey(hotKey);
        }

        private void Dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HotKey hotKey = list[this.dgv.CurrentRow.Index];
            FrmInputKey frmInputKey = new FrmInputKey(hotKey);
            frmInputKey.Show();
        }
    }
}
