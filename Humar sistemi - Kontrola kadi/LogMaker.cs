using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace KontrolaKadi
{
    class LogMaker
    {
        public class SarzaOrientedLog
        {
            public string SarzaID { get; set; }
            public string TimeStart { get; set; }
            public string TimeEnd { get; set; }
            public string TimeDuration { get; set; }

            public Int64 StartUserID { get; set; }
            public Int64 StopUserID { get; set; }

            public enum logType : byte
            {
                Datetime,
                Temperature1,
                Temperature2,
                Ph,
                AlarmTemperature,
                AlarmDeltaTemperature,
                AlarmNivo
            }

            Dictionary<logType, List<string>> LogDictionary = new Dictionary<logType, List<string>> { };

            List<string> List_Time = new List<string>();
            List<string> List_T1 = new List<string>();
            List<string> List_T2 = new List<string>();
            List<string> List_Ph = new List<string>();
            List<string> List_AlTemp = new List<string>();
            List<string> List_AlDeltaT = new List<string>();
            List<string> List_AlNivo = new List<string>();


            private DateTime dt;

            const string dflttime = "0:00:00";
            const string dflttimeFormat = @"h\:mm\:ss";

            public string SarzaLogFolder { get; set; }

            StreamWriter LogWriter;

            public SarzaOrientedLog()
            {
                SarzaID = "UNKNOWN ID";
                TimeStart = "ERR";
                TimeEnd = "ERR";
                TimeDuration = dflttime;
                SarzaLogFolder = XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SarzaLogFolderPath").Value;

                // Streamwriter

                doesPathExsist(SarzaLogFolder);

                LogDictionary.Add(logType.Datetime, List_Time);
                LogDictionary.Add(logType.Temperature1, List_T1);
                LogDictionary.Add(logType.Temperature2, List_T2);
                LogDictionary.Add(logType.Ph, List_Ph);
                LogDictionary.Add(logType.AlarmTemperature, List_AlTemp);
                LogDictionary.Add(logType.AlarmDeltaTemperature, List_AlDeltaT);
                LogDictionary.Add(logType.AlarmNivo, List_AlNivo);

            }

            public void addValues(string T1, string T2, string Ph, string AlarmTemperature, string AlarmDeltaTemperature, string AlarmNivo)
            {
                LogDictionary[logType.Datetime].Add(DateTime.Now.ToString(dflttimeFormat));

                if (T1 != null) { LogDictionary[logType.Temperature1].Add(T1); } else { LogDictionary[logType.Temperature1].Add(PropComm.NA); }
                if (T2 != null) { LogDictionary[logType.Temperature2].Add(T2); } else { LogDictionary[logType.Temperature2].Add(PropComm.NA); }
                if (Ph != null) { LogDictionary[logType.Ph].Add(Ph); } else { LogDictionary[logType.Ph].Add(PropComm.NA); }
                if (AlarmTemperature != null) { LogDictionary[logType.AlarmTemperature].Add(AlarmTemperature); } else { LogDictionary[logType.AlarmTemperature].Add(PropComm.NA); }
                if (AlarmDeltaTemperature != null) { LogDictionary[logType.AlarmDeltaTemperature].Add(AlarmDeltaTemperature); } else { LogDictionary[logType.AlarmDeltaTemperature].Add(PropComm.NA); }
                if (AlarmNivo != null) { LogDictionary[logType.AlarmNivo].Add(AlarmNivo); } else { LogDictionary[logType.AlarmNivo].Add(PropComm.NA); }

            }

            public void createLogFileForPrevious(Int64 StartUserID, Int64 StopUserID, string KadID, string SarzaID, DateTime TimeStart, DateTime TimeEnd, string TimeDuration, string TimeSetAlarm)
            {
                try
                {
                    dt = DateTime.Now;

                    string path1 = SarzaLogFolder + "\\";

                    string content =
                        dt.Year + "-" +
                        dt.Month + "-" +
                        dt.Day + " - " +
                        dt.Hour + "-" +
                        dt.Minute + "-" +
                        dt.Second + "-";

                    string content2 =
                       dt.ToString(@"yyyy.MM.dd - HH:mm:ss");

                                        
                    string info =
                        "Kad " + KadID +
                        " -Sarza " + SarzaID;

                    string path2 =
                        path1 +
                        content +
                        info +
                        ".csv";

                    LogWriter = new StreamWriter(path2, true, Encoding.UTF8);
                    LogWriter.Write(
                        "Kodiranje (Encoding: )" + LogWriter.Encoding.ToString() + Environment.NewLine +
                        "Dnevnik je bil ustvarjen: " + content2 + ";" + Environment.NewLine +
                        "Start čas: " + FormatTimeToStringForLog(TimeStart) + ";" + Environment.NewLine +
                        "Stop čas: " + FormatTimeToStringForLog(TimeEnd) + ";" + Environment.NewLine +
                        "Trajanje čas: " + TimeDuration + ";" + Environment.NewLine +
                        "Nastavljen čas: " + TimeSetAlarm + ";" + Environment.NewLine +
                        "Kad ID: " + KadID + ";" + Environment.NewLine +
                        "Sarža ID: " + SarzaID + ";" + Environment.NewLine +
                        "Start Uporabnik ID: " + StartUserID + "("+ Identify.GetUserFromID(StartUserID) + ")"+ Environment.NewLine +
                        "Stop Uporabnik ID: " + StopUserID + "(" + Identify.GetUserFromID(StopUserID) + ")" + Environment.NewLine +

                        RetrieveMeasureData() + Environment.NewLine +

                    "KONEC ZAPISA; " + Environment.NewLine
                        );
                    LogWriter.Flush();
                    LogWriter.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("Log File Was not created successfully error message folows: " + e.Message);
                }
                
                    
            }

            private string RetrieveMeasureData()
            {
                string buff1 = "ERR ", buff2 = "ERR ", buff3 = "ERR ", 
                    buff4 = "ERR ", buff5 = "ERR ", buff6 = "ERR ", 
                    buffMaster = "Trace: " + Environment.NewLine;
                                

                for (int i = 0; i < LogDictionary[logType.Datetime].Count; i++)
                {
                    try
                    {
                        buff1 = "T1: " + LogDictionary[logType.Temperature1].ElementAt(i) + ";";
                    }
                    catch (Exception ex)
                    {
                        buff1 = "T1: " + buff1 + ex.Message + ";";
                    }

                    try
                    {
                        buff2 = "T2: " + LogDictionary[logType.Temperature2].ElementAt(i) + ";";
                    }
                    catch (Exception ex)
                    {
                        buff2 = "T2: " + buff2 + ex.Message + ";";
                    }

                    try
                    {
                        buff3 = "Ph: " + LogDictionary[logType.Ph].ElementAt(i) + ";";                        
                    }
                    catch (Exception ex)
                    {
                        buff3 = "Ph: " + buff3 + ex.Message + ";";
                    }

                    try
                    {
                        buff4 = "AlarmTemperature: " + LogDictionary[logType.AlarmTemperature].ElementAt(i) + ";";
                    }
                    catch (Exception ex)
                    {
                        buff4 = "AlarmTemperature: " + buff4 + ex.Message + ";";
                    }

                    try
                    {
                        buff5 = "AlarmDeltaT: " + LogDictionary[logType.AlarmDeltaTemperature].ElementAt(i) + ";";
                    }
                    catch (Exception ex)
                    {
                        buff5 = "AlarmDeltaT: " + buff5 + ex.Message + ";";                       
                    }

                    try
                    {
                        buff6 = "Nivo: " + LogDictionary[logType.AlarmNivo].ElementAt(i) + ";";
                    }
                    catch (Exception ex)
                    {
                        buff6 = "Nivo: " + buff5 + ex.Message + ";";
                    }

                    //
                    try
                    {
                        buffMaster += LogDictionary[logType.Datetime].ElementAt(i) + ";" +
                        buff1 + buff2 + buff3 + buff4 + buff5 + Environment.NewLine;
                    }
                    catch
                    {
                        buffMaster += "DateTimeERR" + ";" +
                        buff1 + buff2 + buff3 + buff4 + buff5 + Environment.NewLine;
                    }                             
                }                

                return buffMaster;
            }


            private string FormatTimeToStringForLog(DateTime dt)
            {
                return dt.ToString(@"yyyy.MM.dd - HH:mm:ss");
                                
            }

            public static void doesPathExsist(string path)
            {
                if (Directory.Exists(path))
                {
                    return;
                }

                else
                {
                    MessageBox.Show("Application needs Path for saving Log files (\"Sarža\" Log Files). Folder provided does not exist. Please provide Path to folder now. Please select folder to save log files into.");
                    FolderBrowserDialog d1 = new FolderBrowserDialog();                    
                    
                    while(true)
                    {
                        if (d1.ShowDialog() == DialogResult.OK)
                        {
                            if (Directory.Exists(d1.SelectedPath))
                            {
                                XML_handler.settingsXML.Element("root").Element("GENERAL").Element("SarzaLogFolderPath").Value = d1.SelectedPath;
                                XML_handler.settingsXML.Save(Properties.Settings.Default.PathXML);
                                return;
                            }                            
                        }
                        else
                        {
                           throw new Exception("Application can not function properly without valid Log file Path. Application will now close.");                           
                        }
                    }                    
                }
            }
        }
    }
}
