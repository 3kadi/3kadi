using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace KontrolaKadi
{
    public partial class Kad : Panel
    {
        public Chart ChartOfTemperature;
        DataForChart dataForChart;
        public ShowChartRange showChartRange;

        private ComboBox cb_chartX_rangeMin = new ComboBox();
        private ComboBox cb_chartX_rangeMax = new ComboBox();
        private Label lbl_chartX_rangeMin = new Label();
        private Label lbl_chartX_rangeMax = new Label();

        public ComboBox cbChartRange = new ComboBox();

        public GroupBox gbChartControls = new GroupBox();

        ChartArea chartArea1 = new ChartArea();


        private void InitialiseCharts()
        {
            dataForChart = new DataForChart();
                        
            Timer timer1s = new Timer();
            timer1s.Tick += Timer1s_Tick;
            timer1s.Interval = 1000; // set interval Y
            timer1s.Start();

            now = DateTime.Now;
            target = now.AddMilliseconds(timer1s.Interval);
          
            Legend legend1 = new Legend();
            Series series1 = new Series();
            Series series2 = new Series();
            ChartOfTemperature = new Chart();
            ((ISupportInitialize)(ChartOfTemperature)).BeginInit();

            ChartOfTemperature.BackColor = Color.LightGray;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisY.Maximum = 70;
            chartArea1.AxisY.Minimum = 10;
            chartArea1.AxisY.Interval = 5;
            chartArea1.AxisX.Interval = 12;

            ChartOfTemperature.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            ChartOfTemperature.Legends.Add(legend1);
            ChartOfTemperature.Location = new Point(0, 690);
            ChartOfTemperature.Name = "ChartOfTemperature";            
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Spline;
            series1.Color = Color.FromArgb(192, 0, 0);
            series1.Legend = "Legend1";
            series1.Name = "T1 [°C]";
            series1.IsXValueIndexed = true;
            ChartOfTemperature.Series.Add(series1);
            series1["LineTension"] = "0.05";            

            ChartOfTemperature.Size = new Size(MotherForm.Width, 300);
            ChartOfTemperature.TabIndex = 0;
            ChartOfTemperature.Text = "chart1";
            ChartOfTemperature.Legends["Legend1"].Docking = Docking.Left;

            ChartOfTemperature.DataSource = dataForChart;
            ChartOfTemperature.Series[0].XValueMember = "X";
            ChartOfTemperature.Series[0].YValueMembers = "Y";
            ChartOfTemperature.Series[0].XValueType = ChartValueType.DateTime;

            if (hasChart > 1)
            {
                series2.BorderWidth = 2;
                series2.ChartArea = "ChartArea1";
                series2.ChartType = SeriesChartType.Spline;
                series2.Color = Color.Navy;
                series2.Legend = "Legend1";
                series2.Name = "T2 [°C]";
                series2.IsXValueIndexed = true;
                ChartOfTemperature.Series.Add(series2);
                series2["LineTension"] = "0.05";
                
                ChartOfTemperature.Series[1].XValueMember = ChartOfTemperature.Series[0].XValueMember;
                ChartOfTemperature.Series[1].YValueMembers = "Y";
                ChartOfTemperature.Series[1].XValueType = ChartValueType.DateTime;
            }
                                    
            
            Controls.Add(ChartOfTemperature);
                        
            ChartOfTemperature.DataBind();

            cb_chartX_rangeMin.DataSource = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80 };
            cb_chartX_rangeMin.Location = new Point(10,40);
            cb_chartX_rangeMin.DropDownStyle = ComboBoxStyle.DropDownList;

            cb_chartX_rangeMax.DataSource = new List<int> { 0, 10, 20, 30, 40, 50, 60, 70, 80 };
            cb_chartX_rangeMax.Location = new Point(10,70);
            cb_chartX_rangeMax.DropDownStyle = ComboBoxStyle.DropDownList;

            cbChartRange.DataSource = new List<string> { "Zadnji dan", "Zadnja ura", "Zadnja minuta",  "Zadnji teden" };
            cbChartRange.Location = new Point(10, 10);
            cbChartRange.DropDownStyle = ComboBoxStyle.DropDownList;

            gbChartControls.Location = new Point(ChartOfTemperature.Left + 10, ChartOfTemperature.Top + 60);
            gbChartControls.Width = 180;


            cbChartRange.SelectedValueChanged += CbChartRange_SelectedValueChanged;

            lbl_chartX_rangeMin.Text = "Skala Y od:";
            lbl_chartX_rangeMax.Text = "Skala Y do:";

            gbChartControls.Controls.Add(cbChartRange);
            gbChartControls.Controls.Add(cb_chartX_rangeMin);
            gbChartControls.Controls.Add(cb_chartX_rangeMax);
            gbChartControls.Controls.Add(lbl_chartX_rangeMin);
            gbChartControls.Controls.Add(lbl_chartX_rangeMax);
            this.Controls.Add(gbChartControls);           

        }

        private void Cb_chartX_rangeMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("ChartYto").Value = cb_chartX_rangeMax.SelectedValue.ToString();
            XML_handler.SaveXML();

            chartArea1.AxisY.Maximum = Convert.ToInt32(cb_chartX_rangeMax.SelectedValue);
            chartArea1.AxisY.Minimum = Convert.ToInt32(cb_chartX_rangeMin.SelectedValue);
        }

        private void Cb_chartX_rangeMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            XML_handler.settingsXML.Element("root").Element("GUI" + BelongsToGUI_ID).Element("Kad" + ID).Element("ChartYfrom").Value = cb_chartX_rangeMin.SelectedValue.ToString();
            XML_handler.SaveXML();

            chartArea1.AxisY.Maximum = Convert.ToInt32(cb_chartX_rangeMax.SelectedValue);
            chartArea1.AxisY.Minimum = Convert.ToInt32(cb_chartX_rangeMin.SelectedValue);
        }

        private void CbChartRange_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbChartRange.SelectedIndex == (int)ShowChartRange.minutelyView)
            {
                showChartRange = ShowChartRange.minutelyView;
            }

            if (cbChartRange.SelectedIndex == (int)ShowChartRange.hourlyView)
            {
                showChartRange = ShowChartRange.hourlyView;
            }

            if (cbChartRange.SelectedIndex == (int)ShowChartRange.daylyView)
            {
                showChartRange = ShowChartRange.daylyView;
            }

            if (cbChartRange.SelectedIndex == (int)ShowChartRange.weeklyView)
            {
                showChartRange = ShowChartRange.weeklyView;
            }
        }

        public enum ShowChartRange
        {

            daylyView = 0,
            hourlyView = 1,
            minutelyView = 2,
            weeklyView = 3,
        }


        private void Timer1s_Tick(object sender, EventArgs e)
        {
            var tmp = FormControl.bt1;
            try
            {                
                switch (ID)
                {
                    case 1: AddValuesToChart(tmp.Prop2.Temperatura11.Value, tmp.Prop2.Temperatura21.Value);  break;
                    case 2: AddValuesToChart(tmp.Prop2.Temperatura12.Value, tmp.Prop2.Temperatura22.Value); break;
                    case 6: AddValuesToChart(tmp.Prop3.Temperatura16.Value, tmp.Prop3.Temperatura26.Value); break;
                    case 7: AddValuesToChart(tmp.Prop4.Temperatura17.Value, tmp.Prop4.Temperatura27.Value); break;
                    case 9: AddValuesToChart(tmp.Prop5.Temperatura19.Value, tmp.Prop5.Temperatura29.Value); break;
                    case 11: AddValuesToChart(tmp.Prop8.Temperatura111.Value, null); break;
                    case 12: AddValuesToChart(tmp.Prop6.Temperatura112.Value, tmp.Prop6.Temperatura212.Value); break;
                    case 14: AddValuesToChart(tmp.Prop6.Temperatura114.Value, tmp.Prop6.Temperatura214.Value); break;
                    case 15: AddValuesToChart(tmp.Prop7.Temperatura115.Value, tmp.Prop7.Temperatura215.Value); break;
                    case 17: AddValuesToChart(tmp.Prop7.Temperatura117.Value, tmp.Prop7.Temperatura217.Value); break;                    
                    case 19: AddValuesToChart(tmp.Prop8.Temperatura119.Value, tmp.Prop8.Temperatura219.Value); break;
                    default:
                        break;
                }               
            }
            catch
            {
                
            }
        }

        private void AddValuesToChart(string Val1, string Val2)
        {
            if (Val1 != null && Val2 != null)
            {
                if (Val1 != PropComm.NA && Val2 != PropComm.NA)
                {
                    dataForChart.AddData(DateTime.Now, Convert.ToDecimal(Val1), Convert.ToDecimal(Val2));

                    if (hasChart > 0)
                    {
                        UpdateChart();
                    }
                }
            }
            else if (Val1 != null && Val2 == null)
            {
                if (Val1 != PropComm.NA && Val2 != PropComm.NA)
                {
                    dataForChart.AddData(DateTime.Now, Convert.ToDecimal(Val1));

                    if (hasChart > 0)
                    {
                        UpdateChart();
                    }
                }
            }

        }
        

        private void UpdateChart()
        {
            // Populate series data
            
            if (showChartRange == ShowChartRange.minutelyView)
            {
                if (dataForChart.Dataview_minuteview.Count > 0)
                {
                    ChartOfTemperature.Series[0].Points.DataBindXY(dataForChart.Dataview_minuteview, "Time", dataForChart.Dataview_minuteview, "Value1");
                    if (hasChart > 1)
                    {
                        ChartOfTemperature.Series[1].Points.DataBindXY(dataForChart.Dataview_minuteview, "Time", dataForChart.Dataview_minuteview, "Value2");
                    }                   
                    ChartOfTemperature.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "HH:mm:ss";
                }
            }

            else if (showChartRange == ShowChartRange.hourlyView)
            {
                if (dataForChart.Dataview_hourview.Count > 0)
                {
                    ChartOfTemperature.Series[0].Points.DataBindXY(dataForChart.Dataview_hourview, "Time", dataForChart.Dataview_hourview, "Value1");
                    ChartOfTemperature.Series[1].Points.DataBindXY(dataForChart.Dataview_hourview, "Time", dataForChart.Dataview_hourview, "Value2");
                    ChartOfTemperature.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "HH:mm:(dd.MM)";
                }
            }

            else if(showChartRange == ShowChartRange.daylyView)
            {
                if (dataForChart.Dataview_dayview.Count > 0)
                {
                    ChartOfTemperature.Series[0].Points.DataBindXY(dataForChart.Dataview_dayview, "Time", dataForChart.Dataview_dayview, "Value1");
                    if (hasChart > 1)
                    {
                        ChartOfTemperature.Series[1].Points.DataBindXY(dataForChart.Dataview_dayview, "Time", dataForChart.Dataview_dayview, "Value2");
                    }
                    ChartOfTemperature.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "HH:mm(dd.MM.yy)";
                }
            }

            else if(showChartRange == ShowChartRange.weeklyView)
            {
                if (dataForChart.Dataview_weekview.Count > 0)
                {
                    ChartOfTemperature.Series[0].Points.DataBindXY(dataForChart.Dataview_weekview, "Time", dataForChart.Dataview_weekview, "Value1");
                    if (hasChart > 1)
                    {
                        ChartOfTemperature.Series[1].Points.DataBindXY(dataForChart.Dataview_weekview, "Time", dataForChart.Dataview_weekview, "Value2");
                    }
                    ChartOfTemperature.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "HH:mm(dd.MM.yy)";
                }
            }

            else
            {
                showChartRange = ShowChartRange.minutelyView;                
            }
                        
        }

        public class DataForChart
        {
            public DataTable Datatable_minuteview;
            public DataTable Datatable_hourview;
            public DataTable Datatable_dayview;
            public DataTable Datatable_weekview;

            public DataView Dataview_minuteview;
            public DataView Dataview_hourview;
            public DataView Dataview_dayview;
            public DataView Dataview_weekview;

            private int cnt_hrly = 5;
            private int cnt_dayly = 24;

            
            public DataForChart()
            {
                Datatable_minuteview = new DataTable();
                Datatable_hourview = new DataTable();
                Datatable_dayview = new DataTable();
                Datatable_weekview = new DataTable();

                Datatable_minuteview.Columns.Add("Time", typeof(DateTime));
                Datatable_minuteview.Columns.Add("Value1", typeof(decimal));
                Datatable_minuteview.Columns.Add("Value2", typeof(decimal));
                Dataview_minuteview = Datatable_minuteview.DefaultView;

                Datatable_hourview.Columns.Add("Time", typeof(DateTime));
                Datatable_hourview.Columns.Add("Value1", typeof(decimal));
                Datatable_hourview.Columns.Add("Value2", typeof(decimal));
                Dataview_hourview = Datatable_hourview.DefaultView;

                Datatable_dayview.Columns.Add("Time", typeof(DateTime));
                Datatable_dayview.Columns.Add("Value1", typeof(decimal));
                Datatable_dayview.Columns.Add("Value2", typeof(decimal));
                Dataview_dayview = Datatable_dayview.DefaultView;

                Datatable_weekview.Columns.Add("Time", typeof(DateTime));
                Datatable_weekview.Columns.Add("Value1", typeof(decimal));
                Datatable_weekview.Columns.Add("Value2", typeof(decimal));
                Dataview_weekview = Datatable_weekview.DefaultView;

            }

            public void AddData(DateTime now, decimal DataForChart1, decimal DataForChart2)
            {
                Datatable_minuteview.Rows.Add(now, DataForChart1, DataForChart2);

                if (Datatable_minuteview.Rows.Count >= 60) // 1minute view (60 steps)
                {
                    Datatable_minuteview.Rows.RemoveAt(0); // adds row to Datatable_minuteview: [DateTime.Now, CurrentValue]                    
                }

                if (cnt_hrly >= 5) // every 4 measurements adds row to Datatable_hourview: [DateTime.Now, CurrentValue] - (720 steps)
                {
                    Datatable_hourview.Rows.Add(now, DataForChart1, DataForChart2);                    
                    cnt_hrly = 0;

                    if (cnt_dayly >= 24)
                    {
                        Datatable_dayview.Rows.Add(now, DataForChart1, DataForChart2);
                        cnt_dayly = 0;
                    }
                    cnt_dayly++;
                }                

                if (Datatable_hourview.Rows.Count >= 720) // 1hour view (720 steps)
                {
                    Datatable_hourview.Rows.RemoveAt(0);                   
                }

                if (Datatable_dayview.Rows.Count >= 720) // 1day view (720 steps)
                {
                    Datatable_dayview.Rows.RemoveAt(0);
                }
                                                
                cnt_hrly++;
                
            }

            public void AddData(DateTime now, decimal DataForChart1)
            {
                Datatable_minuteview.Rows.Add(now, DataForChart1);

                if (Datatable_minuteview.Rows.Count >= 60) // 1minute view (60 steps)
                {
                    Datatable_minuteview.Rows.RemoveAt(0); // adds row to Datatable_minuteview: [DateTime.Now, CurrentValue]                    
                }

                if (cnt_hrly >= 5) // every 4 measurements adds row to Datatable_hourview: [DateTime.Now, CurrentValue] - (720 steps)
                {
                    Datatable_hourview.Rows.Add(now, DataForChart1);
                    cnt_hrly = 0;

                    if (cnt_dayly >= 24)
                    {
                        Datatable_dayview.Rows.Add(now, DataForChart1);
                        cnt_dayly = 0;
                    }
                    cnt_dayly++;
                }

                if (Datatable_hourview.Rows.Count >= 720) // 1hour view (720 steps)
                {
                    Datatable_hourview.Rows.RemoveAt(0);
                }

                if (Datatable_dayview.Rows.Count >= 720) // 1day view (720 steps)
                {
                    Datatable_dayview.Rows.RemoveAt(0);
                }

                cnt_hrly++;

            }
        }
    }
}
