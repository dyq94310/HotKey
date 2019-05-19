using System;
using System.Windows.Forms;

namespace WorkUtil.Entity
{
    [Serializable]
    class InputKey
    {
        public Keys Keys { get; set; }
        public Keys Modifiers { get; set; }
        public string Display { get; set; }
        public string Sends { get; set; }
    }
}
