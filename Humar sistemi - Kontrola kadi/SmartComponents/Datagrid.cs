using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KontrolaKadi
{
    public class Datagrid : DataGridView
    {
        public bool ShowOnGUI = true;
                
        public Datagrid()
        {
            this.SetStyle(ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.OptimizedDoubleBuffer, true);

            this.ReadOnly = true;
            this.Enabled = false;

            this.SelectionChanged += Datagrid_SelectionChanged;
        }

        private void Datagrid_SelectionChanged(object sender, EventArgs e)
        {
            this.ClearSelection();
        }
    }
}
