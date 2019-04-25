using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReClassNET.UI
{
    public partial class ScrollableSplitTable : ScrollableCustomControl
    {
        public SplitTablePanel Panel => PanelControl;

        public ScrollableSplitTable()
        {
            InitializeComponent();
        }
    }
}
