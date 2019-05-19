using System;

namespace WorkUtil.Entity
{
    [Serializable]
    class HotKey
    {
        public int HotKeyId { get; set; }
        internal InputKey HotKeys { get; set; }
        internal InputKey SendKey { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
