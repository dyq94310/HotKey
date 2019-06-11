using log4net.Config;
using System;
using System.IO;
using System.Windows.Forms;

namespace WorkUtil
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 用代码加载 log4net 的配置文件
            string log4netConfig = "Config/log4net.config";
            if (File.Exists(log4netConfig))
            {
                XmlConfigurator.Configure(new FileInfo(log4netConfig));
            }
            else
            {
                MessageBox.Show("Log4net配置文件[ " + log4netConfig + " ]不存在", "Log4net配置");
            }


            Application.Run(new Form1());
        }
    }
}
