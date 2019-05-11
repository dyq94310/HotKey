using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkUtil.Util;

namespace WorkUtil.Entity
{
    class InputKey
    {
        public Keys Keys { get; set; }
        public Keys Modifiers { get; set; }
        public string Show { get; set; }

    }
}
