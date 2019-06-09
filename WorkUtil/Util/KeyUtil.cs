using System.Text;
using System.Windows.Forms;
using WorkUtil.Cst;
using WorkUtil.Entity;

namespace WorkUtil.Util
{
    class KeyUtil
    {

        /// <summary>
        /// 获取用户输入
        /// </summary>
        /// <param name="e"></param>
        /// <param name="inputKey"></param>
        public static void setKey(KeyEventArgs e, InputKey inputKey)
        {
            if (e.Modifiers != 0)
            {
                inputKey.Modifiers = e.Modifiers;
            }
            if ((e.KeyValue >= 33 && e.KeyValue <= 40)
                || (e.KeyValue >= 65 && e.KeyValue <= 90)
                || (e.KeyValue >= 112 && e.KeyValue <= 123))
            {
                inputKey.Keys = e.KeyCode;
            }
            else if (e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                inputKey.Keys = e.KeyCode;
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="inputKey"></param>
        /// <returns></returns>
        public static string getDispaly(InputKey inputKey)
        {
            if (inputKey == null)
            {
                return string.Empty;
            }
            StringBuilder txtShow = new StringBuilder();
            if (inputKey.Modifiers != 0)
            {
                txtShow.Append(inputKey.Modifiers.ToString() + " + ");
            }
            int keyCode = (int)inputKey.Keys;

            if ((keyCode >= 33 && keyCode <= 40)
                || (keyCode >= 65 && keyCode <= 90)
                || (keyCode >= 112 && keyCode <= 123)
                || keyCode == 8)
            {
                txtShow.Append(inputKey.Keys.ToString());
            }
            else if (keyCode >= 48 && keyCode <= 57)
            {
                txtShow.Append(keyCode.ToString().Substring(1));
            }
            return txtShow.ToString();
        }

        public static string getSendKey(InputKey inputKey)
        {
            if (inputKey == null)
            {
                return string.Empty;
            }
            StringBuilder sendKey = new StringBuilder();

            switch (inputKey.Modifiers)
            {
                case Keys.Alt:
                    sendKey.Append(KeyCodeCst.Atl);
                    break;
                case Keys.Control:
                    sendKey.Append(KeyCodeCst.CTRL);
                    break;
                case Keys.Shift:
                    sendKey.Append(KeyCodeCst.SHIFT);
                    break;
                default:
                    break;
            }
            int keyCode = (int)inputKey.Keys;
            if (keyCode == 8)
            {
                sendKey.Append(KeyCodeCst.BACKSPACE);
            }
            if ((keyCode >= 33 && keyCode <= 40)
                || (keyCode >= 65 && keyCode <= 90)
                || (keyCode >= 112 && keyCode <= 123))
            {
                sendKey.Append(inputKey.Keys.ToString());
            }
            else if (keyCode >= 48 && keyCode <= 57)
            {
                sendKey.Append(keyCode.ToString().Substring(1));
            }
            return sendKey.ToString();
        }

        /// <summary>
        /// 获取用户组合键枚举
        /// </summary>
        /// <param name="inputKey"></param>
        /// <returns></returns>
        public static SystemHotKeyUtil.KeyModifiers getKeyModifiersEnum(InputKey inputKey)
        {
            if (inputKey == null)
            {
                return SystemHotKeyUtil.KeyModifiers.None;
            }
            switch (inputKey.Modifiers)
            {
                case Keys.Alt:
                    return SystemHotKeyUtil.KeyModifiers.Alt;
                case Keys.Control:
                    return SystemHotKeyUtil.KeyModifiers.Ctrl;
                case Keys.Shift:
                    return SystemHotKeyUtil.KeyModifiers.Shift;
                default:
                    return SystemHotKeyUtil.KeyModifiers.None;
            }
        }
    }
}
