using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KontrolaKadi
{
    public partial class Gui
    {
        bool invalidationNecesery = false;
        
       
        private void TestGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormControl.HideForm_Gui();
            e.Cancel = true;
        }


        private void Gui_Load(object sender, EventArgs e)
        {
            
            FormControl.bt1.RunPCWatchdog();

            // Worker for populating values
            Thread Populator = new Thread(new ThreadStart(Populate))
            {
                Name = "ValuePopulator Thread",
                IsBackground = true
            };           
            Populator.Start();

            WL_UserAction("Gui "+ GuiID +" initialized (Application started)",true);
            
        }
                
        private void ButtonLogin(object sender, EventArgs e)
        {
            FormControl.identify.ShowIDDialog(); // Identify your self
        }

        private void ButtonLogoff(object sender, EventArgs e)
        {
            FormControl.identify.Logoff();            
        }

        // back color
        private void Button2_Click_1(object sender, EventArgs e)
        {
            int argb = -1;
            try
            {
                ColorDialog c1 = new ColorDialog();
                if (c1.ShowDialog() == DialogResult.OK)
                {
                    argb = c1.Color.ToArgb();
                    panel.BackColor = Color.FromArgb(argb);
                    settings.Element("GuiBackgroundColor").SetValue(argb.ToString());
                    XML_handler.SaveXML();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Problem ocurded while writing color to XML file: " + ex.Message);                
            }

            Gui.WL_UserAction("Color changed to: " + argb + " - (ArgbFormat)", true);

        }

        // settings menu       
        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (FormControl.identify.GetPermision(2))
            {
                FormControl.ShowForm_Settings();
                FormControl.HideForm_Gui();
                WL_UserAction("User entered Settings menu", true);
            }
            else
            {
                FormControl.identify.ShowPermissionError();
            }
        }

        // mouse leaves
        private void Gui_LostFocus(object sender, EventArgs e)
        {
            for (int i = 1; i < StKadi + 1; i++)
            {
                _bordered[i] = false;
                _bordered2[i] = false;
            }
            UpdateGui();
        }

        // Mouse Hover event
        private void OnMouseHover(object sender, MouseEventArgs e)
        {
            

            for (int i = 1; i < StKadi + 1; i++)
            {

                if (_Containers[i].Contains(e.Location)) // if hovers on "kadi"
                {
                    if (_bordered[i] == false)
                    {
                        _bordered[i] = true;
                        invalidationNecesery = true;                        
                    }
                }
                else
                {
                    if (_bordered[i] == true)
                    {
                        _bordered[i] = false;
                        invalidationNecesery = true;                        
                    }



                    if (_UnderlineRectString2[i].Contains(e.Location)) // if hovers on "kadi"
                    {
                        if (_bordered2[i] == false)
                        {
                            _bordered2[i] = true;
                            invalidationNecesery = true;
                        }
                    }
                    else
                    {
                        if (_bordered2[i])
                        {
                            _bordered2[i] = false;
                            invalidationNecesery = true;
                        }
                    }
                }

            }

            if (invalidationNecesery)
            {                
                UpdateGui(false);
                invalidationNecesery = false;
            }

            
            if (panelStat.zapisek1.Focused || panelStat.zapisek2.Focused || panelStat.zapisek3.Focused || panelStat.zapisek1Chk.Focused || panelStat.zapisek2Chk.Focused || panelStat.zapisek3Chk.Focused)
            {
                if (!panelStat.ClientRectangle.Contains(e.Location))
                {
                    panelStat.Focus(); // unfocus textbox
                }
            }
                       
        }

        // Mouse Click event
        private void OnMouseClick(object sender, MouseEventArgs e)
        {

            int num = 0;

            
            try
            {
                GuiDisabled_NoConnection = Convert.ToBoolean(settingsXML.Element("root").Element("GENERAL").Element("DisableGuiOnLostConnection").Value);
            }
            catch
            {
                GuiDisabled_NoConnection = true;
            }

            // checks if click is performed on drawing
            for (int i = 1; i < StKadi + 1; i++)
            {
                kadi[i].Visible = false;
                if (_Containers[i].Contains(e.Location) && kadi[i].TypeOfKad != 0)
                {
                    if (btnStarted.StartedStatus == (int)StartedButton.StatedStatus.Started || GuiDisabled_NoConnection == false)
                    {
                        if (FormControl.identify.GetPermision(3) == true)
                        {
                            panel.Visible = false;
                            num = i;
                            WL_UserAction("User entered submenu (Kad " + kadi[i].ID + ")", true);
                        }
                        else
                        {
                            WL_UserAction("User was denied entering submenu (Kad " + kadi[i].ID + ") beacause he/she has no permission to do so", true);
                            FormControl.identify.ShowPermissionError();
                            return;
                        }
                    }
                    else
                    {
                        WL_UserAction("User was denied entering submenu (Kad " + kadi[i].ID + ") because system was not started yet", true);
                        Misc.MessageBoxShowOnActiveMonitor(this, "Please start/connect to System first!");
                        return;
                    }
                }

            }
            if (num != 0)
            {
                kadi[num].Visible = true;
                return;
            }


            // checks if click is performed on number
            for (int i = 1; i < StKadi + 1; i++)
            {
                if (_UnderlineRectString2[i].Contains(e.Location))
                {
                    if (FormControl.identify.GetPermision(6) == true)
                    {
                        FormControl.bt1.Prop1.ToggleENFromIndex(i, this);
                    }
                    else
                    {
                        FormControl.identify.ShowPermissionError();
                    }
                }
            }
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            // Graphic needs to be repainted when panel size changes              
            UpdateGui();

        }

    }
}
