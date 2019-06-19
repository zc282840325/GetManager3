# GetManager3
### 这是一个窗口小工具
### 主要功能：
> 重写了中国港口的潮汐表
>> 客户端（C# Winform）
![image](https://github.com/zc282840325/GetManager3/blob/master/image/1.png)
>> PC端
www.chinaports.com/tidal
### 核心代码
 if (!string.IsNullOrEmpty(cmb_Port.Text))
            {
                if (cmb_Port.Text != "==请选择==")
                {
                    textBox1.Text = "";
                    ct.Series.RemoveAt(0);
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
