using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KontrolaKadi
{
    public class GetValueForOutDatagrid
    {
        public SmartDatagrid Datagrid { get; set; }                               
        private int ID { get { return Datagrid.ID; } }
        private Gui MotherForm { get { return Datagrid._MotherForm; } }

        private string[] prefix = new string[6 + 1];
        private string[] value = new string[6 + 1];
        private string[] postfix = new string[6 + 1];

        private int[] line = new int[6 + 1];

        public string[] postResult = new string[6 + 1];


        private Thread UpdateValuesForOuterDatagrid;

        // values in xml for out datagrid composition:
        //    prefix    (fixed string)
        //    value     (get from datagrid)
        //    postfix   (fixed string)
        //    line1     (indicates which line of inner datagrid will be represented at outer datagrid at index 1)
        //    line2     (indicates which line of inner datagrid will be represented at outer datagrid at index 2)
        //    line3     (indicates which line of inner datagrid will be represented at outer datagrid at index 3)
        //    line4     (indicates which line of inner datagrid will be represented at outer datagrid at index 4)
        //    line5     (indicates which line of inner datagrid will be represented at outer datagrid at index 5)
        //    line6     (indicates which line of inner datagrid will be represented at outer datagrid at index 6)


        public GetValueForOutDatagrid()
        {
               
            UpdateValuesForOuterDatagrid = new Thread(Updater_ValuesForOuterDatagrid);
            UpdateValuesForOuterDatagrid.Start();
                        
        }

        private void Updater_ValuesForOuterDatagrid()
        {
            int seqnum = 0;
            SmartDatagrid sd;

            // wait for other threads to do their work
            while (Datagrid == null || MotherForm.kadi == null || !FormControl.bt1.InitialisationComplete)
            {                   
                Thread.Sleep(100);
            }

                        

            //init forloop
            for (int i = 1; i <= 6; i++)
            {
                
                try
                {
                    prefix[i] = XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("OutDatagridPrefixAtLine" + i).Value;
                    postfix[i] = XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("OutDatagridPostfixAtLine" + i).Value;
                    line[i] = int.Parse(XML_handler.settingsXML.Element("root").Element("GUI" + MotherForm.GuiID).Element("Kad" + ID).Element("GetTextAtLine" + i).Value);
                }
                catch 
                {
                    prefix[i] = "";
                    value[i] = PropComm.NA;
                    postfix[i] = "";
                    line[i] = 0;
                }

            }


            while (true)
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (line[i] == 0)
                    {
                        value[i] = "";
                    }
                    else
                    {


                        if (MotherForm.GuiID == 1)
                        {
                            switch (ID)
                            {
                                case 1: seqnum = 1; break;
                                case 2: seqnum = 2; break;
                                case 3: seqnum = 3; break;
                                case 4: seqnum = 4; break;
                                case 5: seqnum = 5; break;
                                case 6: seqnum = 6; break;
                                case 7: seqnum = 7; break;
                                case 8: seqnum = 8; break;
                                case 9: seqnum = 9; break;
                                default:
                                    break;
                            }
                        }

                        if (MotherForm.GuiID == 2)
                        {
                            switch (ID)
                            {
                                case 10: seqnum = 1; break;
                                case 11: seqnum = 2; break;
                                case 12: seqnum = 3; break;
                                case 13: seqnum = 4; break;
                                case 14: seqnum = 5; break;
                                case 15: seqnum = 6; break;
                                case 16: seqnum = 7; break;
                                case 17: seqnum = 8; break;
                                case 18: seqnum = 9; break;
                                case 19: seqnum = 10; break;

                                default:
                                    break;
                            }
                        }

                        try
                        {
                            sd = MotherForm.kadi[seqnum].Main_datagrid;
                            if (seqnum > 0 && sd.RowCount >= i)
                            {
                                value[i] = sd[1, line[i] - 1].Value.ToString();
                            }                            
                        }
                        catch 
                        {
                        }
                        

                    }                 
                    
                    postResult[i] = prefix[i] + value[i] + postfix[i];

                    
                }
                Thread.Sleep(250);
            }            
        }        
    }
}
