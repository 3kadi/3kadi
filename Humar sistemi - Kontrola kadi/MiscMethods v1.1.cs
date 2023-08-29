using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;


namespace KontrolaKadi
{
    public class Misc
    {
        public static string Checkmark = "\u2713";
        public static string Crossmark = "X";

        /// <summary>
        ///  This is simple helper class for creating thread. USE LIKE THIS: 
        ///  var a = new Misc.SmartThread(() => Method());
        /// </summary>
        public class SmartThread
        {
            public bool CanelationPending = false; // Check manualy outside
            public bool IsBusy = false;
            private Thread Thread; 
            public ThreadStart ThreadStart; // Provide outside for thread creation
            
            public SmartThread(ThreadStart ThreadStart)
            {
                this.ThreadStart = ThreadStart;                
            }

            public void Start(string ThreadName, ApartmentState apartmentState, bool isBackground)
            {
                if (Thread == null || Thread.ThreadState == ThreadState.Stopped)
                {
                    Thread = new Thread(ThreadStart);
                }
                
                CanelationPending = false;
                IsBusy = true;
                if(Thread.ThreadState == ThreadState.Unstarted)
                {                             
                    Thread = new Thread(ThreadStart);
                }
                else
                {
                    if (Thread.ThreadState != ThreadState.Running)
                    {
                        Thread.SetApartmentState(apartmentState);
                        Thread.Name = ThreadName;
                    }                    
                }
                                   
                Thread.Start();
            }
            /// <summary>
            /// if parameter isBackground == false - Starts backgroud thread (thread will be terminated if application closes), 
            /// or if parameter isBackground == true -  Starts foreground thread (thread will finish job after application closes)
            /// Thread can be STA ("runs on one core") or MTA ("can run on different core")
            /// </summary>
            /// <param name="ThreadName"></param>
            /// <param name="isBackground"></param>
            public void Start(string ThreadName, ApartmentState apartmentState, ThreadPriority threadPriority, bool isBackground)
            {
                Start(ThreadName, apartmentState, isBackground);
                Thread.Priority = threadPriority;
            }

            /// <summary>
            /// if parameter isBackground == false - Starts backgroud thread (thread will be terminated if application closes), 
            /// or if parameter isBackground == true -  Starts foreground thread (thread will finish job after application closes)
            /// Thread will be STA ("runs on one core")
            /// </summary>
            /// <param name="ThreadName"></param>
            /// <param name="isBackground"></param>
            public void Start(string ThreadName, bool isBackground)
            {
                Start(ThreadName, ApartmentState.STA, isBackground);                
            }

            /// <summary>
            /// Starts backgroud thread (thread will be terminated if application closes)
            /// Thread will be STA ("runs on one core")
            /// </summary>
            /// <param name="ThreadName"></param>
            public void Start(string ThreadName)
            {
                Start(ThreadName, ApartmentState.STA, true);
            }

            // Tries to stop thread by setting CanelationPending bool you must use in your code, 
            //if that is not responsive thread is aborted after 20 attempts for 15ms
            public string Stop()
            {
                return Stop(20,  15);
            }

            public string Stop(int tryToCancel_howmanytimes, int sleepBetweenTries)
            {
                CanelationPending = true;
                var cnt = 0;
                Thread.Sleep(50);
                IsBusy = false;
                while (Thread.ThreadState == ThreadState.Running)
                {
                    if (cnt >= tryToCancel_howmanytimes)
                    {
                        Thread.Abort();
                        CanelationPending = false;
                        return "Thread " + Thread.Name + " does not respond to stop command and will be closed by force.";
                    }
                    Thread.Sleep(sleepBetweenTries);
                    Application.DoEvents();
                    cnt++;
                }

                return "Thread " + Thread.Name + " canceled successfully.";

            }

            public void SetPriority(ThreadPriority threadPriority)
            {
                Thread.Priority = threadPriority;
            }
            public void CancelAsync()
            {
                Stop();
            }
            /// <summary>
            /// Runs MTA thread in background or foreground
            /// </summary>
            public void RunWorkerAsync(bool isBackground)
            {
                Start("Thread", ApartmentState.MTA, isBackground);
            }

            /// <summary>
            /// Runs MTA thread in background
            /// </summary>
            public void RunWorkerAsync()
            {
                Start("Thread", ApartmentState.MTA, true);
            }
        }
            

        // Brightenes colors
        public static Color ColorBrightener(Color color, decimal multiplyR, decimal multiplyG, decimal multiplyB)
        {
            var Rd = Convert.ToDecimal(color.R) * multiplyR; if (Rd > 255) { Rd = 255; }
            var Gd = Convert.ToDecimal(color.G) * multiplyG; if (Gd > 255) { Gd = 255; }
            var Bd = Convert.ToDecimal(color.B) * multiplyB; if (Bd > 255) { Bd = 255; }

            byte R = Convert.ToByte(Rd);
            byte G = Convert.ToByte(Gd);
            byte B = Convert.ToByte(Bd);            
            return Color.FromArgb(R, G, B);
        }

        // Calculates center of rectangle from all dimensions
        public static void CalculateCenter(float objA_X, float objA_Width, float objA_Y, float objA_Height, float objB_Width, float objB_Height, out float objB_X, out float objB_Y)
        {
            objB_X = (objA_X + objA_Width / 2) - (objB_Width/2);
            objB_Y = (objA_Y + objA_Height / 2) - (objB_Height / 2);
        }

        // Shows form on active display
        public static void ShowFormOnCenterOfActiveScreen(Form ActiveForm_Parent, Form SubformToShow )
        {

            SubformToShow.Show();
            SubformToShow.Location = new Point((ActiveForm_Parent.Left + ActiveForm_Parent.Width / 2) - SubformToShow.Width / 2, (ActiveForm_Parent.Top + ActiveForm_Parent.Height / 2) - SubformToShow.Height / 2);
            SubformToShow.TopMost = true;

        }

        // Calculates center of rectangle from rectangle
        public static Point RectangleGetCenter(Rectangle rectangle)
        {
            int xCenter = ToInt(rectangle.X + (rectangle.Width / 2));
            int yCenter = ToInt(rectangle.Y + (rectangle.Height / 2));
            return new Point(xCenter, yCenter);
        }

        // Returns rectangle from centerpoint
        public static Rectangle RectangleFromCenterPoint(float centerX, float centerY, float width, float height)
        {
            float buffX; float buffY; float buffW; float buffH;
            buffX = centerX - (width / 2);
            buffY = centerY - (height / 2);
            buffW = width;
            buffH = height;
            return new Rectangle(ToInt(buffX), ToInt(buffY), ToInt(buffW), ToInt(buffH));
        }

        // Returns rounded int number from float
        public static int ToInt(float float_)
        {
            return Convert.ToInt32(Math.Round(float_, 0));
        }

        // Returns rounded int number from double
        public static int ToInt(double double_)
        {
            return Convert.ToInt32(Math.Round(double_, 0));
        }

        // scale bitmap image
        public static Bitmap Scale(Bitmap bitmap, float height)
        {
            float ratio = (float)bitmap.Width / bitmap.Height;
            float new_Width = bitmap.Width / (bitmap.Height / height);
            Bitmap tmp = new Bitmap(bitmap, new Size(Convert.ToInt32(new_Width), Convert.ToInt32(height)));
            return tmp;
        }

        // Returns Font from different dimensions
        public static Font MeasureString(PaintEventArgs e, Rectangle rect, string text, float startSize, FontStyle fontstyle)
        {
            Font f = new Font(FontFamily.GenericSansSerif, startSize, fontstyle);
            var size = e.Graphics.MeasureString(text, f);

            while (size.Width > rect.Width)
            {
                startSize = startSize * 0.95F;
                f = new Font(FontFamily.GenericSansSerif, startSize, fontstyle);
                size = e.Graphics.MeasureString(text, f);
            }

            while (size.Height > rect.Height)
            {
                startSize = startSize * 0.95F;
                f = new Font(FontFamily.GenericSansSerif, startSize, fontstyle);
                size = e.Graphics.MeasureString(text, f);
            }


            return f;
        }

        public static void CheckAndKillAnotherInstance()
        {
            var p = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location));
            var cp = System.Diagnostics.Process.GetCurrentProcess();

            if (p.Length > 1)
            {
                try
                {

                    for (int i = 0; i < p.Length; i++)
                    {
                        if (p[i] != cp)
                        {
                            p[i].Kill();
                            return;
                        }

                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("There is another instance of this application running (possible in background)!" + e.Message);

                }

            }
        }

        public static void MessageBoxShowOnActiveMonitor(Form ActiveForm_Parent, string textToshow)
        {
            Form f = new Form();
            Label l = new Label();
            Button b = new Button();
            f.Controls.Add(l);
            f.Controls.Add(b);

            
            l.Text = textToshow;
            l.Location = new Point(10, 10);
            l.Width = 200;
            f.Width = 350;
            f.Height = 150;
            f.MinimizeBox = false;
            f.MaximizeBox = false;
            
            b.Text = "OK";
            b.Location = new Point(f.Width / 2 - b.Width/2, f.Height - 80);

            b.Click += (sender, e) => { F_FormClosed(f, null); };
            f.FormClosed += (sender,e) => { F_FormClosed(f, null); };  
            ShowFormOnCenterOfActiveScreen(ActiveForm_Parent, f);
            
        }

        private static void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Form f = (Form)sender;
                f.Dispose();
            }
            catch 
            {               
            }
            
        }
    }
}
