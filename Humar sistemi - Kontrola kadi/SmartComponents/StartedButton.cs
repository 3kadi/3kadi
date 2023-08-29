using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace KontrolaKadi
{
    public class StartedButton : Button
    {
        
        public int ID { get;}
        public string Showname { get; set; }
        public int StartedStatus { get; set; }
        int refreshOriginalVal = 500;
        private Bitmap startedIcon;
        private Bitmap stoppedIcon; 
        private Bitmap disabledIcon;
        private int connstatcnt = 0;

        public StartedButton(int ID, int Height, int Width, int Top)
        {            
            this.ID = ID;
            this.Height = Height;
            this.Width = Width;
            this.Top = Top;
            
            StartedStatus = (int)StatedStatus.Disabled;
            Enabled = false;

            stoppedIcon = Properties.Resources.Stop;
            startedIcon = Properties.Resources.Start;
            disabledIcon = Properties.Resources.disconnected;
            
            stoppedIcon = Misc.Scale(stoppedIcon, this.Height*0.75F);
            startedIcon = Misc.Scale(startedIcon, this.Height * 0.75F);
            disabledIcon = Misc.Scale(disabledIcon, this.Height * 0.75F);
            this.BackgroundImageLayout = ImageLayout.Center;
            BackColor = Color.Transparent;
            BackgroundImage = disabledIcon;

            // object own status retriever
            BackgroundWorker updater = new BackgroundWorker();
            updater.DoWork += new DoWorkEventHandler(Updater);
            updater.RunWorkerAsync();

            // on click
            this.Click += Clicked;
            
        }

        public enum StatedStatus : int
        {
            Started = 0,
            Stopped = -1,
            Disabled = -2
        }
        

        private void Clicked(object sender, EventArgs e)
        {
            
            if (StartedStatus == (int)StatedStatus.Started)
            {
                Stop();                
            }
            else if (StartedStatus == (int)StatedStatus.Stopped)
            {
                Start();                
            }
            else 
            {
                StartedStatus = (int)StatedStatus.Disabled;
            }
            
        }

        public void Start()
        {   
            if (FormControl.identify.GetPermision(5))
            {
                if (ID == 1) // elox
                {                                        
                    FormControl.bt1.Prop1.StartNetElox.Value = true;
                    FormControl.bt1.Prop1.StopNetElox.Value = false;

                }

                else if (ID == 2) // elox
                {                    
                    FormControl.bt1.Prop1.StartNetBarve.Value = true;
                    FormControl.bt1.Prop1.StopNetBarve.Value = false;
                }
            }
            else
            {
                FormControl.identify.ShowPermissionError();
            }
        }

        public void Stop()
        {
            if (FormControl.identify.GetPermision(5))
            {
                if (ID == 1) // elox
                {
                    FormControl.bt1.Prop1.StartNetElox.Value = false;
                    FormControl.bt1.Prop1.StopNetElox.Value = true;
                }

                else if (ID == 2) // elox
                {
                    FormControl.bt1.Prop1.StartNetBarve.Value = false;
                    FormControl.bt1.Prop1.StopNetBarve.Value = true;
                }
            }
            else
            {
                FormControl.identify.ShowPermissionError();
            }
        }

        public void UpdateConnectionStatus()
        {
            bool en = Enabled;

            if (StartedStatus == (int)StatedStatus.Started)
            {
                if (connstatcnt >= 3)
                {
                    BackgroundImage = startedIcon; en = true;
                }
                connstatcnt++;                
            }

            else if (StartedStatus == (int)StatedStatus.Stopped)
            {
                if (connstatcnt >= 3)
                {
                    BackgroundImage = stoppedIcon; en = true;                    
                }
                connstatcnt++;               
            }

            else if (StartedStatus == (int)StatedStatus.Disabled)
            {
                BackgroundImage = disabledIcon; en = false;
                connstatcnt = 0;
            }

            if (en != Enabled)
            {
                Invoke(new MethodInvoker(delegate { Enabled = en; }));
            }
        }
               

        public void RetrieveConnectionStatus()
        {
            if (AreThereAllConnected(ID))
            {
                
                if (ID == 1) // elox
                {
                    if (FormControl.bt1.Prop1.EloxConnected.Value == true)
                    {
                        StartedStatus = (int)StatedStatus.Started;
                    }
                    else
                    {
                        StartedStatus = (int)StatedStatus.Stopped;
                    }
                }
                else if (ID == 2) // barve
                {
                    if (FormControl.bt1.Prop1.BarveConnected.Value == true)
                    {
                        StartedStatus = (int)StatedStatus.Started;
                    }
                    else
                    {
                        StartedStatus = (int)StatedStatus.Stopped;
                    }
                }
            }
            else
            {
                StartedStatus = (int)StatedStatus.Disabled;
            }
        }

        public void Updater(object sender, DoWorkEventArgs e)
        {            
            DateTime t1;           
            while (true)
            {
                try
                {
                    t1 = DateTime.Now.AddMilliseconds(refreshOriginalVal/2);
                    RetrieveConnectionStatus();
                    UpdateConnectionStatus();
                    while (DateTime.Now < t1)
                    {                        
                        //Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }
                }
                catch 
                {
                    
                }
                
                
            }
            
        }

        private bool AreThereAllConnected(int ID)
        {
            if (FormControl.Form_gui[ID] != null)
            {
                for (int i = 1; i < FormControl.Form_gui[ID].btnConnected.Length; i++)
                {
                    if (FormControl.Form_gui[ID].btnConnected[i] != null)
                    {
                        if (FormControl.Form_gui[ID].btnConnected[i].ConnectionStatus == (int)Connection.Status.Connected)
                        {
                            // it is OK.. do nothing
                        }
                        else
                        {
                            return false; // not all connected
                        }
                    }

                }
                return true; // all OK
            }
            else
            {
                return false; // not connected
            }
            
        }
        
    }
}
