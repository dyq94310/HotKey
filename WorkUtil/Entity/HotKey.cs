using System;

namespace WorkUtil.Entity
{
    [Serializable]
    class HotKey
    {
        public int HotKeyID { get; set; }
        public bool DefaulClick { get; set; }
        internal InputKey InputKey { get; set; }
        internal InputKey SendKey { get; set; }
    }
}
