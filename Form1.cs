using FSharp.Charting;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace GetManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            ct.ChartAreas.Add(new ChartArea() { Name = "ca1" }); //背景框
            ct.ChartAreas[0].Axes[0].MajorGrid.Enabled = false; //X轴上网格
            ct.ChartAreas[0].Axes[1].MajorGrid.Enabled = false; //y轴上网格
            ct.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Solid; //网格类型 短横线
            ct.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            ct.ChartAreas[0].Axes[0].MajorTickMark.Enabled = true; // x轴上突出的小点
            ct.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false; //
            ct.ChartAreas[0].Axes[1].IsInterlaced = true; //显示交错带 
            ct.ChartAreas[0].Axes[0].LabelStyle.Format = "#时"; //设置X轴显示样式
            ct.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            ct.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Blue;
            ct.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 3;

            cmb_zhou.SelectedIndex = 0;
        }
      
        //选择州
        private void Cmb_zhou_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_zhou.SelectedItem!= "==请选择==")
            {
                var data = Tools.HttpPost(Tools.GetUrl("http://www.chinaports.com/getCountryList"), "parentcode="+ cmb_zhou .SelectedItem+ "");
                List<item> list = JsonConvert.DeserializeObject<List<item>>(data);
                list.Insert(0,new item("==请选择==", "==请选择=="));
                cmb_COUNTRY.DataSource = list;
                cmb_COUNTRY.DisplayMember = "COUNTRY";
                cmb_COUNTRY.ValueMember = "ID";
            }
            else
            {
                cmb_COUNTRY.DataSource = null;
                cmb_Province.DataSource = null;
                cmb_Port.DataSource = null;
            }
        }
       //选择国家
        private void Cmb_COUNTRY_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_COUNTRY.SelectedItem !="==请选择==")
            {
                if (cmb_COUNTRY.SelectedValue.ToString()=="中国")
                {
                    cmb_Province.DataSource = null;
                    var data = Tools.HttpPost(Tools.GetUrl("http://www.chinaports.com/getProvinceList"), "parentcode=" + cmb_COUNTRY.SelectedValue + "");
                    List<Province> list = JsonConvert.DeserializeObject<List<Province>>(data);
                    list.Insert(0, new Province("==请选择==", "==请选择=="));
                    cmb_Province.DataSource = list;
                    cmb_Province.DisplayMember = "PROVINCE";
                    cmb_Province.ValueMember = "ID";
                    cmb_Port.DataSource = null;
                }
                else
                {
                    cmb_Province.DataSource = null;
                    var data = Tools.HttpPost(Tools.GetUrl("http://www.chinaports.com/getPortByCountry"), "parentcode=" + cmb_COUNTRY.SelectedValue + "");
                    List<Country> list = JsonConvert.DeserializeObject<List<Country>>(data);
                    list.Insert(0, new Country("==请选择==", "==请选择=="));
                    cmb_Port.DataSource = list;
                    cmb_Port.DisplayMember = "NAME";
                    cmb_Port.ValueMember = "AREA_ID";
                }
            }
            else
            {
                cmb_Province.DataSource = null;
                cmb_Port.DataSource = null;
            }
        }
        //选择省
        private void Cmb_Province_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_Province.SelectedItem != "==请选择==")
            {
                var data = Tools.HttpPost(Tools.GetUrl("http://www.chinaports.com/getPortByProvince"), "parentcode=" + cmb_Province.SelectedValue + "");
                List<Country> list = JsonConvert.DeserializeObject<List<Country>>(data);
                list.Insert(0, new Country("==请选择==", "==请选择=="));
                cmb_Port.DataSource = list;
                cmb_Port.DisplayMember = "NAME";
                cmb_Port.ValueMember = "AREA_ID";
            }
            else
            {
                cmb_Port.DataSource = null;
            }
        }
        //查询
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmb_Port.Text))
            {
                if (cmb_Port.Text != "==请选择==")
                {
                    List<string> txData2 = new List<string>();
                    List<string> tyData2 = new List<string>();
                    //拼接请求接口（样：http://www.chinaports.com/tidal/2019/6/17/133）
                    string url = "http://www.chinaports.com/tidal/" + dateTimePicker1.Text + "/" + cmb_Port.SelectedValue + "";
                    //请求url返回请求结果到msg
                    string msg = Tools.HttpGet(Tools.GetUrl(url), "");
                    //声明对象
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    //网页字符串加载到doc对象中
                    doc.LoadHtml(msg);
                    //(xpath获取港口名称)
                    HtmlNode hrefList = doc.DocumentNode.SelectSingleNode("/html/body/section/div/div[2]/table/tr[1]/th[2]");
                    string gkname = "港口名称：" + hrefList.InnerText + "\r\n";
                    //(xpath获取潮时)
                    HtmlNodeCollection hrefList2 = doc.DocumentNode.SelectNodes("/html/body/section/div/div[2]/table/tr[2]/td");
                    foreach (HtmlNode item in hrefList2)
                    {
                        gkname += item.InnerText + ",";
                    }
                    gkname += "\r\n";
                    //(xpath获取潮高)
                    HtmlNodeCollection hrefList3 = doc.DocumentNode.SelectNodes("/html/body/section/div/div[2]/table/tr[3]/td");
                    foreach (HtmlNode item in hrefList3)
                    {
                        gkname += item.InnerText + ",";
                    }
                    gkname += "\r\n";
                    //从网页中解析list数据
                    GetTitleContent(msg, ref gkname,ref txData2, ref tyData2);
                    textBox1.AppendText(gkname);
                    //数据录入到本地的txt
                    WriteTxt(gkname);
                   //展示折线图
                    ShowManager(txData2, tyData2);
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("请选择港口！");
            }
          
        }
        //展示折线图
        private void ShowManager(List<string> txData2, List<string> tyData2)
        {
            //添加的两组Test数据
            ct.Series.Add(new Series()); //添加一个图表序列
                                         // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            ct.Series[0].Label = "#VAL"; //设置显示X Y的值 
            ct.Series[0].ToolTip = "#VALX年\r#VAL"; //鼠标移动到对应点显示数值
            ct.Series[0].ChartArea = ct.ChartAreas[0].Name; //设置图表背景框ChartArea 
            ct.Series[0].ChartType = SeriesChartType.Line; //图类型(折线)
            ct.Series[0].Points.DataBindXY(txData2, tyData2); //添加数据
                                                              //折线段配置
            ct.Series[0].Color = Color.Blue; //线条颜色
            ct.Series[0].BorderWidth = 3; //线条粗细
            ct.Series[0].MarkerBorderColor = Color.Red; //标记点边框颜色
            ct.Series[0].MarkerBorderWidth = 3; //标记点边框大小
            ct.Series[0].MarkerColor = Color.Red; //标记点中心颜色
            ct.Series[0].MarkerSize = 5; //标记点大小
            ct.Series[0].MarkerStyle = MarkerStyle.Circle; //标记点类型
        }

        #region 录入数据到本地的txt中
        public void WriteTxt(string gkname)
        {
            string path4 = System.AppDomain.CurrentDomain.BaseDirectory;
            string strFile = path4 + DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss") + ".txt";

            using (FileStream fs = new FileStream(strFile, FileMode.CreateNew))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(gkname);
                }
            }
        }
        #endregion

        #region 读取网页中的list
        public void GetTitleContent(string str, ref string gkname, ref List<string> txData2, ref List<string> tyData2)
        {
            gkname += "数据:" + "\r\n";
            List<string> list1 = new List<string>();
            MatchCollection match = Regex.Matches(str, "(\"tide_height\").*?(\\d+(\\.\\d+)?\")");
            foreach (Match item in match)
            {
                string value = item.Value.ToString().Replace("tide_height", "潮高").Replace("\"", "").Replace("\"", "");
                list1.Add(value);
                tyData2.Add(value.Split(':')[1]);
            }
            List<string> list2 = new List<string>();
            MatchCollection match2 = Regex.Matches(str, "(\"tide_time\").*?((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)");
            foreach (Match item in match2)
            {
                string value = item.Value.ToString().Replace("tide_height", "潮高").Replace("\"", "").Replace("\"", "");
                list2.Add(value);
                txData2.Add(value.Split(':')[1]+":"+ value.Split(':')[2]);
            }
            for (int i = 0; i < list1.Count; i++)
            {
                gkname += list2[i] + "," + list1[i] + ",datetime:" + dateTimePicker1.Text + "\r\n";
            }

        }
        #endregion

        public class Province
        {

            public Province(string v1, string v2)
            {
                this.ID = v1;
                this.PROVINCE = v2;
            }

            public string ID { get; set; }
            public string PROVINCE { get; set; }

        }
        public class Country
        {
            private string v1;
            private string v2;

            public Country(string v1, string v2)
            {
                this.AREA_ID = v1;
                this.NAME = v2;
            }

            public string AREA_ID { get; set; }
            public string NAME { get; set; }

        }
        public class item
        {
            public item(string v1, string v2)
            {
                this.COUNTRY = v1;
                this.ID = v2;
            }

            public string COUNTRY { get; set; }
            public string ID { get; set; }
        }
    }
}
