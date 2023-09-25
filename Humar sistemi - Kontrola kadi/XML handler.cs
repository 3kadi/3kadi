using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KontrolaKadi
{
    public class XML_handler
    {
        public static string Path { get; private set; }
        public static XDocument settingsXML;
        private static  Thread TrySaveThread;


        public XML_handler()
        {
            LoadXml();
            Path = Properties.Settings.Default.PathXML;            
        }

        public void Save()
        {
            settingsXML.Save(Path);
        }

        public static void SaveXML()
        {
            if (TrySaveThread != null)
            {
                while (TrySaveThread.ThreadState != ThreadState.Stopped)
                {                   
                    Thread.Sleep(100); // wait for last thread to finish
                }
            }           

            TrySaveThread = new Thread(save);
            TrySaveThread.SetApartmentState(ApartmentState.MTA);         
            TrySaveThread.Start();

        }

        private static void save()
        {
            int i;
            Exception exceptionBuffer = new Exception("Cant save XML settings file after 30 tries.");

            for (i = 0; i < 30; i++)
            {
                // try to save for 30 seconds
                if (!IsFileLocked(new FileInfo(Properties.Settings.Default.PathXML)))
                {
                    try
                    {
                        settingsXML.Save(Properties.Settings.Default.PathXML);
                        return;
                    }
                    catch (Exception e)
                    {
                        exceptionBuffer = new Exception(exceptionBuffer.Message + " Reason: " + e.Message);
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }

            MessageBox.Show(exceptionBuffer.Message);

        }

        protected static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Write, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private static void LoadXml()
        {
            try
            {

                if (File.Exists(Properties.Settings.Default.PathXML))
                {
                    settingsXML = XDocument.Load(Properties.Settings.Default.PathXML);
                }
                else
                {
                    MessageBox.Show("Application needs valid xml file to load settings from, please provide valid file now.");
                    OpenFileDialog d1 = new OpenFileDialog()
                    {
                        Title = "Select XML configuration file",
                        Filter = "XML files (*.xml)|*.xml"

                    };


                    if (d1.ShowDialog() == DialogResult.OK)
                    {
                        if (d1.CheckFileExists)
                        {
                            settingsXML = XDocument.Load(d1.FileName);                            
                            Properties.Settings.Default.PathXML = d1.FileName;
                            Properties.Settings.Default.Save();
                            d1.Dispose();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                
            }
            catch (Exception e)
            {
                MessageBox.Show("XML file is not valid at path: " + Properties.Settings.Default.PathXML + " Application will now close." + Environment.NewLine + " Error mesage: " + e.Message);
                Environment.Exit(0);
            }
        }
    }
}
