using Common.Utils;
using Common.Utils.PublicEntity;
using log4net;
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

        public static readonly ILog loginfo = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 热键集合
        /// </summary>
        private List<HotKey> list;

        public Form1()
        {
            InitializeComponent();
            init();
            loginfo.Info("启动成功");
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
            timer1.Start();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            InsertHotKey();
        }

        private void InsertHotKey()
        {

            this.dgv.DataSource = null;

            IHotKey aucInputKey = new FrmInputKey();
            HotKey cmd = new HotKey();
            cmd.HotKeyId = new Random().Next();
            HotKey hotKey = aucInputKey.getHotKey(cmd);
            if (hotKey.RegKeys == null)
            {
                return;
            }

            list.Add(hotKey);
            this.dgv.DataSource = list;
        }

        private void updateHotKey(HotKey hk)
        {
            if (!list.Contains(hk))
            {
                MessageBox.Show("选择出错，请重启应用");
                return;
            }
            IHotKey aucInputKey = new FrmInputKey();
            aucInputKey.getHotKey(hk);
        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    mapping(msg.WParam.ToInt32());
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
                    , item.RegKeys.Modifiers
                    , item.RegKeys.Keys);

                loginfo.Info
                    (string.Format("RegHotKey，id={0},hotKey={1},note={2}"
                    , item.HotKeyId
                    , item.RegKeys.Display
                    , item.Note));
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
                loginfo.Info(string.Format("UnregisterHotKey，id={0},note={1}", item.HotKeyId, item.Note));
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

        private void mapping(int hotkeyId)
        {
            if (list == null)
            {
                return;
            }
            foreach (var item in list)
            {
                if (item.HotKeyId == hotkeyId)
                {
                    SendKeys.Send(item.SendKeys.Sends.ToLower());
                    loginfo.Info(string.Format("success:ID={0},note={1},send={2}", hotkeyId, item.Note, item.SendKeys.Sends.ToLower()));
                    return;
                }
            }
            loginfo.Info(string.Format("ID not find,ID={0}", hotkeyId));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SerializeUtil<List<HotKey>>.serializeNow(list, SAVE_FILE);
            }
            catch (Exception ex)
            {
                loginfo.Info("save fail");
                MessageBox.Show("保存失败" + ex);
            }
            MessageBox.Show("保存成功");
            loginfo.Info("save success");
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
            updateHotKey(hotKey);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon1.Visible = false;
            }
        }


        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(20, "最小化", "已经最小化", ToolTipIcon.Info);
            }

        }

        private void OpenMainCms_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void ExitCms_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool bTransparent;
        private System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.bTransparent)
            {
                this.bTransparent = false;       //显示透明图标	     
           //     this.notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("IconNotifyTransp");
            }
            else
            {
                this.bTransparent = true;      //显示托盘图标	    
             //   this.notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("empy");
            }

        }
    }
}
