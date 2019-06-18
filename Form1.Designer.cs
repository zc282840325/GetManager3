namespace GetManager
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_zhou = new System.Windows.Forms.ComboBox();
            this.cmb_COUNTRY = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Province = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Port = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ct = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ct)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "州";
            // 
            // cmb_zhou
            // 
            this.cmb_zhou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_zhou.FormattingEnabled = true;
            this.cmb_zhou.Items.AddRange(new object[] {
            "==请选择==",
            "亚洲",
            "欧洲",
            "南美洲",
            "南极洲",
            "非洲",
            "大洋洲",
            "北美洲"});
            this.cmb_zhou.Location = new System.Drawing.Point(64, 33);
            this.cmb_zhou.Name = "cmb_zhou";
            this.cmb_zhou.Size = new System.Drawing.Size(121, 20);
            this.cmb_zhou.TabIndex = 2;
            this.cmb_zhou.SelectionChangeCommitted += new System.EventHandler(this.Cmb_zhou_SelectionChangeCommitted);
            // 
            // cmb_COUNTRY
            // 
            this.cmb_COUNTRY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_COUNTRY.FormattingEnabled = true;
            this.cmb_COUNTRY.Location = new System.Drawing.Point(253, 33);
            this.cmb_COUNTRY.Name = "cmb_COUNTRY";
            this.cmb_COUNTRY.Size = new System.Drawing.Size(121, 20);
            this.cmb_COUNTRY.TabIndex = 4;
            this.cmb_COUNTRY.SelectionChangeCommitted += new System.EventHandler(this.Cmb_COUNTRY_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "国家";
            // 
            // cmb_Province
            // 
            this.cmb_Province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Province.FormattingEnabled = true;
            this.cmb_Province.Location = new System.Drawing.Point(449, 33);
            this.cmb_Province.Name = "cmb_Province";
            this.cmb_Province.Size = new System.Drawing.Size(121, 20);
            this.cmb_Province.TabIndex = 6;
            this.cmb_Province.SelectionChangeCommitted += new System.EventHandler(this.Cmb_Province_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "省份";
            // 
            // cmb_Port
            // 
            this.cmb_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Port.FormattingEnabled = true;
            this.cmb_Port.Location = new System.Drawing.Point(638, 33);
            this.cmb_Port.Name = "cmb_Port";
            this.cmb_Port.Size = new System.Drawing.Size(121, 20);
            this.cmb_Port.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(603, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "港口";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(779, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "日期";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(814, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(941, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 37);
            this.button1.TabIndex = 11;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ct
            // 
            chartArea1.Name = "ChartArea1";
            this.ct.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ct.Legends.Add(legend1);
            this.ct.Location = new System.Drawing.Point(43, 74);
            this.ct.Name = "ct";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ct.Series.Add(series1);
            this.ct.Size = new System.Drawing.Size(548, 259);
            this.ct.TabIndex = 12;
            this.ct.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(596, 74);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(475, 259);
            this.textBox1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 360);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ct);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_Port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_Province);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_COUNTRY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_zhou);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询【潮汐表】";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_zhou;
        private System.Windows.Forms.ComboBox cmb_COUNTRY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Province;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ct;
        private System.Windows.Forms.TextBox textBox1;
    }
}

