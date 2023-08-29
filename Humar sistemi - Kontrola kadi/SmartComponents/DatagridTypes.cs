using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace KontrolaKadi
{
    public class DatagridTypes
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
            string[] datasource = { PropComm.NA, "1°C", "2°C", "3°C", "4°C", "5°C", "6°C", "7°C", "8°C", "9°C", "10°C" };

            public Delta()
            {
                Value = datasource[0];
                DataSource = datasource;
            }
        }

        public class Timeset : DataGridViewComboBoxCell
        {
            string[] datasource = { PropComm.NA, "1s", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "10s", "12s", "14s", "16s", "18s", "20s", "22s", "24s", "26s", "28s", "30s", "35s", "40s", "45s", "50s", "55s", "60s" };

            public Timeset()
            {
                Value = datasource[0];
                DataSource = datasource;
            }
        }

        public class PhSet : DataGridViewButtonCell
        {            
            public readonly List<string> Data = new List<string>();
            public Form SetTemps_form = new Form();
            DomainUpDown selectTemp = new DomainUpDown();
            Label label = new Label();
            Button OKbtn = new Button();
            Button Cancelbtn = new Button();


            public PhSet()
            {
                float from = 1;
                float to = 14;
                float resolution = 0.1F;

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


                float from_old = from;
                while (Data.Count <= (to - from_old) / resolution)
                {
                    Data.Add(from.ToString("F1") );
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


                label.Text = "Izberite nov Ph: ";
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

        public class TimeSelector : DataGridViewComboBoxCell
        {
            List<string> datasource = new List<string>();

            string[] mins = { "00", "15", "30", "45" };
            string[] hrs = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };

            public TimeSelector()
            {
                datasource.Add(PropComm.NA);
                foreach (var item in hrs)
                {
                    foreach (var it in mins)
                    {
                        datasource.Add(item + ":" + it);
                    }
                }
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


                label.Text = "Izberite novo temperaturo: ";
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


                label.Text = "Izberite novo moč: ";
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

        public class TimeDurationSec : DataGridViewButtonCell
        {
            public readonly List<string> Data = new List<string>();
            public Form SetTemps_form = new Form();            
            Label label = new Label();
            Button OKbtn = new Button();
            Button Cancelbtn = new Button();
            public TimeSpan dflttime = new TimeSpan(0, 0, 5);
            const string dflttimeFormat = @"mm\:ss";
            public TimeSpan _from;
            private TimeSpan _from_old;
            public TimeSpan _to;
            private readonly TimeSpan oneSec = new TimeSpan(0,0,1);
            private int buff1;
            private int buff2;

            public DateTimePicker dateTimePicker = new DateTimePicker();

            /// <summary>
            /// from: you can pass TimeDurationSec class for minimum value to be parsed out --- to: format must be: "59:59" string 
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <param name="resolution"></param>
            public TimeDurationSec(TimeDurationSec _from, string to)                
            {
                // from
                var from = GetStringFromTimeSpan(_from._from);
                // to
                _to = getTimespanFromString(to);

                Initialise();

            }

            /// <summary>
            /// from: format must be: "00:00" string --- to: you can pass TimeDurationSec class for maximum value to be parsed out
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <param name="resolution"></param>
            public TimeDurationSec(string from, TimeDurationSec _to)
            {
                // from
                _from = getTimespanFromString(from);
                // to
                var to = GetStringFromTimeSpan(_to._to);

                Initialise();

            }

            /// <summary>
            /// from: format must be: "00:00" string --- to: format must be: "59:59" string --- 
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <param name="resolution"></param>
            public TimeDurationSec(string from, string to)
            {
                // from
                _from = getTimespanFromString(from);
                // to
                _to = getTimespanFromString(to);                                

                Initialise();

            }

            private void Initialise()
            {
                _from_old = _from;

                while (Data.Count <= (_to - _from).TotalSeconds)
                {
                    Data.Add(_from_old.ToString(dflttimeFormat));
                    _from_old = _from.Add(oneSec);
                }

                Data.Reverse();
                Value = Data[0];


                SetTemps_form.ControlBox = false;
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "mm:ss";
                dateTimePicker.Location = new Point(180, 68);
                dateTimePicker.Name = "dateTimePicker1";
                dateTimePicker.Size = new Size(69, 20);
                dateTimePicker.TabIndex = 0;
                dateTimePicker.ShowUpDown = true;


                dateTimePicker.Top = 40;
                dateTimePicker.Left = 20;
                dateTimePicker.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 20);
                dateTimePicker.Value = dateTimePicker.MinDate.Add(dflttime);

                label.Text = "Izberite nov čas za opomnik: ";
                label.Top = 10;
                label.Left = 10;
                label.Height = 20;
                label.Width = 220;
                label.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

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
                Cancelbtn.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10);

                SetTemps_form.Width = OKbtn.Left + OKbtn.Width + (Cancelbtn.Left - OKbtn.Right) + Cancelbtn.Width + OKbtn.Left + 20;
                SetTemps_form.Height = OKbtn.Bottom + 40;
                dateTimePicker.Width = SetTemps_form.Width - 60;

                SetTemps_form.Controls.Add(OKbtn);
                SetTemps_form.Controls.Add(Cancelbtn);
                SetTemps_form.Controls.Add(label);
                SetTemps_form.Controls.Add(dateTimePicker);

                SetTemps_form.LostFocus += SetTemps_form_LostFocus;
                OKbtn.Click += OKbtn_Click;
                Cancelbtn.Click += Cancelbtn_Click;
            }

            private TimeSpan getTimespanFromString(string from_or_to)
            {
                try
                {
                    if (from_or_to.Length == 5)
                    {
                        if (from_or_to[2] == ':')
                        {
                            buff1 = Convert.ToInt16(from_or_to[0].ToString() + from_or_to[1].ToString());
                            buff2 = Convert.ToInt16(from_or_to[3].ToString() + from_or_to[4].ToString());
                            if (buff1 > 59 || buff1 < 0 || buff2 > 59 || buff2 < 0)
                            {
                                throw new Exception("from parameter in method TimeDurationSec(string, string) is to big or to small value. Must be between 00:00 and 59:59");
                            }
                            else
                            {
                                try
                                {
                                    return new TimeSpan(0, buff1, buff2);
                                }
                                catch (Exception ex)
                                {

                                    throw new Exception("Can not convert from string to Timespan object in method TimeDurationSec(string, string). Error message folows: " + ex.Message);
                                }

                            }

                        }
                        else throw new Exception("from parameter in method TimeDurationSec(string, string) is in wrong format. format must be 00:00 and 5 characters long");
                    }
                    else throw new Exception("Length of from parameter in method TimeDurationSec(string, string) is wrong. Length must be 5 characters (00:00)");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private static string GetStringFromTimeSpan(TimeSpan timeSpan)
            {
                return timeSpan.ToString(dflttimeFormat);
            }

            private void OKbtn_Click(object sender, EventArgs e)
            {
                Value = dateTimePicker.Value.ToString(dflttimeFormat);                
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
                Misc.ShowFormOnCenterOfActiveScreen(Form.ActiveForm, SetTemps_form);
            }

        }







    }
}
