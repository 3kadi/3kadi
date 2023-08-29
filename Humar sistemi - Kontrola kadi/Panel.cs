using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KontrolaKadi
{
    public class MyPanel : Panel
    {
        public Panel Panel { get; set; }
        public int ID { get; set; }

        public MyPanel()
        {
            DoubleBuffered = false;
            SetStyle(ControlStyles.UserPaint | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer, true);

            Dock = DockStyle.Fill;
            
        }

        
    }
}
