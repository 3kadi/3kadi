using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace Humar_sistemi___Kontrola_kadi
{
    public class Dropdowns
    {
        
        public class Histereza : DataGridViewComboBoxCell
        {
            string[] datasource = { PropComm.NA, "1°C", "2°C", "3°C", "4°C", "5°C" };
            
            public Histereza()
            {
                Value = datasource[0]; 
                DataSource = datasource;                  
            }
        }

        public class Delta : DataGridViewComboBoxCell
        {
            string[] datasource = { PropComm.NA, "1°C", "2°C", "3°C", "4°C", "5°C" , "6°C", "7°C", "8°C", "9°C", "10°C" };

            public Delta()
            {
                Value = datasource[0];
                DataSource = datasource;
            }
        }

        public class TestTime : DataGridViewComboBoxCell
        {
            List<string> datasource = new List<string>();

            string[] mins = { "00", "15", "30", "45" };
            string[] hrs = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };           

            public TestTime()
            {

                foreach (var item in hrs)
                {
                    foreach (var it in mins)
                    {
                        datasource.Add(item+":"+it);
                    }
                }
                datasource.Add(PropComm.NA);
                Value = datasource[0];
                DataSource = datasource;
            }
        }

        public class MussLauf : DataGridViewComboBoxCell
        {
            public static string ValueIfTrue = "Prisilno Aktiven";
            public static string ValueIfFalse = "Avtomatsko";

            string[] datasource = { PropComm.NA, ValueIfTrue, ValueIfFalse };

            public MussLauf()
            {
                Value = datasource[0];
                DataSource = datasource;
            }
        }

        public class CheckBox : DataGridViewCheckBoxCell
        {                        
            public CheckBox()
            {
                Value = false;                
            }
        }

        public class TempSet : DataGridViewButtonCell
        {
            public readonly List<string> Data = new List<string>();
            public Form SetTemps_form = new Form();
            DomainUpDown selectTemp = new DomainUpDown();
            Label label = new Label();
            Button OKbtn = new Button();
            Button Cancelbtn = new Button();


            public TempSet(int from, int to, int resolution)
            {

                if (from < 0)
                {
                    from = 0;
                }
                if (to <= from)
                {
                    to = from + 1;
                }
                if (resolution > (to - from))
                {
                    resolution = 1;
                }

                
                int from_old = from;
                while (Data.Count <= (to - from_old) / resolution)
                {
                    Data.Add(from.ToString() + ",0°C");
                    from += resolution;
                }
                Data.Add(PropComm.NA);
                Data.Reverse();                
                Value = Data[0];


                // form init

                SetTemps_form.ControlBox = false;

                foreach (var item in Data)
                {
                    selectTemp.Items.Add(item);
                }
                SetTemps_form.Controls.Add(selectTemp);

                selectTemp.Top = 40;
                selectTemp.Left = 20;                
                selectTemp.Font = new System.Drawing.Font(new System.Drawing.FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20);
                

                label.Text = "Izberite novo temperaturo:";
                label.Top = 10;
                label.Left = 10;
                label.Height = 20;
                label.Width = 220;
                label.Font = new System.Drawing.Font(new System.Drawing.FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);


                OKbtn.Top = 100;
                OKbtn.Left = 10;
                OKbtn.Width = 100;
                OKbtn.Height = 50;
                OKbtn.Text = "OK";
                OKbtn.Font = label.Font;

                Cancelbtn.Top = OKbtn.Top;
                Cancelbtn.Left = OKbtn.Right + 20;
                Cancelbtn.Width = OKbtn.Width;
                Cancelbtn.Height = OKbtn.Height;
                Cancelbtn.Text = "Cancel";
                Cancelbtn.Font = new System.Drawing.Font(new System.Drawing.FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                SetTemps_form.Width = OKbtn.Left + OKbtn.Width + (Cancelbtn.Left - OKbtn.Right) + Cancelbtn.Width + OKbtn.Left + 20;
                SetTemps_form.Height = OKbtn.Bottom + 40;
                selectTemp.Width = SetTemps_form.Width - 60;
                                              

                SetTemps_form.Controls.Add(OKbtn);
                SetTemps_form.Controls.Add(Cancelbtn);
                SetTemps_form.Controls.Add(label);

                SetTemps_form.LostFocus += SetTemps_form_LostFocus;
                OKbtn.Click += OKbtn_Click;
                Cancelbtn.Click += Cancelbtn_Click;


            }

            private void OKbtn_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < Data.Count; i++)
                {
                    if (selectTemp.Text == Data[i] && selectTemp.Text != PropComm.NA)
                    {
                        Value = Data[i];
                        SetTemps_form.Hide();
                        return;
                    }
                }
                string allowed = "";
                foreach (var item in Data)
                {
                    if (item != PropComm.NA)
                    {
                        allowed += item + ", ";
                    }                    
                }

                MessageBox.Show("Error setting Value! Allowed values are: "+ allowed);
                Cancelbtn_Click(null,null);                
            }

            private void Cancelbtn_Click(object sender, EventArgs e)
            {
                SetTemps_form.Hide();
            }

            private void SetTemps_form_LostFocus(object sender, EventArgs e)
            {
                SetTemps_form.Focus();
            }

            public void ShowForm()
            {                              
                
                selectTemp.SelectedIndex = 0;
                for (int i = 0; i < Data.Count; i++)
                {
                    if (Data[i] == Value.ToString())
                    {
                        selectTemp.SelectedIndex = i;
                    }
                }

                Misc.ShowFormOnCenterOfActiveScreen(Form.ActiveForm, SetTemps_form);

            }

        }




        public class PwrSet : DataGridViewButtonCell
        {
            public readonly List<string> Data = new List<string>();
            public Form SetTemps_form = new Form();
            DomainUpDown selectTemp = new DomainUpDown();
            Label label = new Label();
            Button OKbtn = new Button();
            Button Cancelbtn = new Button();


            public PwrSet(int from, int to, int resolution)
            {

                if (from < 0)
                {
                    from = 0;
                }
                if (to <= from)
                {
                    to = from + 1;
                }
                if (resolution > (to - from))
                {
                    resolution = 1;
                }


                int from_old = from;
                while (Data.Count <= (to - from_old) / resolution)
                {
                    Data.Add(from.ToString() + "W");
                    from += resolution;
                }
                Data.Add(PropComm.NA);
                Data.Reverse();
                Value = Data[0];


                // form init

                SetTemps_form.ControlBox = false;

                foreach (var item in Data)
                {
                    selectTemp.Items.Add(item);
                }
                SetTemps_form.Controls.Add(selectTemp);

                selectTemp.Top = 40;
                selectTemp.Left = 20;
                selectTemp.Font = new System.Drawing.Font(new System.Drawing.FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20);


                label.Text = "Izberite novo moč:";
                label.Top = 10;
                label.Left = 10;
                label.Height = 20;
                label.Width = 220;
                label.Font = new System.Drawing.Font(new System.Drawing.FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);


                OKbtn.Top = 100;
                OKbtn.Left = 10;
                OKbtn.Width = 100;
                OKbtn.Height = 50;
                OKbtn.Text = "OK";
                OKbtn.Font = label.Font;

                Cancelbtn.Top = OKbtn.Top;
                Cancelbtn.Left = OKbtn.Right + 20;
                Cancelbtn.Width = OKbtn.Width;
                Cancelbtn.Height = OKbtn.Height;
                Cancelbtn.Text = "Cancel";
                Cancelbtn.Font = new System.Drawing.Font(new System.Drawing.FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                SetTemps_form.Width = OKbtn.Left + OKbtn.Width + (Cancelbtn.Left - OKbtn.Right) + Cancelbtn.Width + OKbtn.Left + 20;
                SetTemps_form.Height = OKbtn.Bottom + 40;
                selectTemp.Width = SetTemps_form.Width - 60;

                SetTemps_form.Controls.Add(OKbtn);
                SetTemps_form.Controls.Add(Cancelbtn);
                SetTemps_form.Controls.Add(label);

                SetTemps_form.LostFocus += SetTemps_form_LostFocus;
                OKbtn.Click += OKbtn_Click;
                Cancelbtn.Click += Cancelbtn_Click;


            }

            private void OKbtn_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < Data.Count; i++)
                {
                    if (selectTemp.Text == Data[i] && selectTemp.Text != PropComm.NA)
                    {
                        Value = Data[i];
                        SetTemps_form.Hide();
                        return;
                    }
                }
                string allowed = "";
                foreach (var item in Data)
                {
                    if (item != PropComm.NA)
                    {
                        allowed += item + ", ";
                    }
                }

                MessageBox.Show("Error setting Value! Allowed values are: " + allowed);
                Cancelbtn_Click(null, null);
            }

            private void Cancelbtn_Click(object sender, EventArgs e)
            {
                SetTemps_form.Hide();
            }

            private void SetTemps_form_LostFocus(object sender, EventArgs e)
            {
                SetTemps_form.Focus();
            }

            public void ShowForm()
            {

                selectTemp.SelectedIndex = 0;
                for (int i = 0; i < Data.Count; i++)
                {
                    if (Data[i] == Value.ToString())
                    {
                        selectTemp.SelectedIndex = i;
                    }
                }

                Misc.ShowFormOnCenterOfActiveScreen(Form.ActiveForm, SetTemps_form);

            }

        }




    }
}
