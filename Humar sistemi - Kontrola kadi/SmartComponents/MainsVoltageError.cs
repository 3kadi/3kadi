using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolaKadi
{
    public class MainsVoltageError : Panel
    {
        Label lbl = new Label();
      
        public MainsVoltageError(Gui form)
        {
            lbl.Text = "NAPAJANJE!";
            
            this.BackColor = form.rectTopColor;
            this.Width = 100;
            Height = 60;
            Top = 5;
            Left = 500;

           
            Panel img = new Panel();
            img.BackgroundImage = Properties.Resources.electfault;
            img.BackgroundImageLayout = ImageLayout.Stretch;
            img.Width = 55;
            img.Height = 40;
            img.Top = 0;
            img.Left = 10;


            lbl.ForeColor = Color.White;
            lbl.BackColor = form.rectTopColor;
            lbl.Top = 45;
            var f = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            lbl.Font = f;

            Controls.Add(img);
            Controls.Add(lbl);
        }
        
    }
}
