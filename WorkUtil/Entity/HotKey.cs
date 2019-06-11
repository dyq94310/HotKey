using System;

namespace WorkUtil.Entity
{
    [Serializable]
    class HotKey
    {
        public int HotKeyId { get; set; }
        /// <summary>
        /// 注册键
        /// </summary>
        internal InputKey RegKeys { get; set; }
        /// <summary>
        /// 发送键
        /// </summary>
        internal InputKey SendKeys { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
