namespace WinPlot {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series31 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series32 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series33 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series34 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series35 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.btnStart = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnStop = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea4.AxisX.Interval = 3D;
			chartArea4.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea4);
			legend4.Name = "Legend1";
			this.chart1.Legends.Add(legend4);
			this.chart1.Location = new System.Drawing.Point(119, 12);
			this.chart1.Name = "chart1";
			series31.ChartArea = "ChartArea1";
			series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series31.Legend = "Legend1";
			series31.Name = "Series1";
			series32.ChartArea = "ChartArea1";
			series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series32.Legend = "Legend1";
			series32.Name = "Series2";
			series33.ChartArea = "ChartArea1";
			series33.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series33.Legend = "Legend1";
			series33.Name = "Series3";
			series34.ChartArea = "ChartArea1";
			series34.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series34.Legend = "Legend1";
			series34.Name = "Series4";
			series35.ChartArea = "ChartArea1";
			series35.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series35.Legend = "Legend1";
			series35.Name = "Series5";
			series36.ChartArea = "ChartArea1";
			series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series36.Legend = "Legend1";
			series36.Name = "Series6";
			series37.ChartArea = "ChartArea1";
			series37.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series37.Legend = "Legend1";
			series37.Name = "Series7";
			series38.ChartArea = "ChartArea1";
			series38.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series38.Legend = "Legend1";
			series38.Name = "Series8";
			series39.ChartArea = "ChartArea1";
			series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series39.Legend = "Legend1";
			series39.Name = "Series9";
			series40.ChartArea = "ChartArea1";
			series40.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series40.Legend = "Legend1";
			series40.Name = "Series10";
			this.chart1.Series.Add(series31);
			this.chart1.Series.Add(series32);
			this.chart1.Series.Add(series33);
			this.chart1.Series.Add(series34);
			this.chart1.Series.Add(series35);
			this.chart1.Series.Add(series36);
			this.chart1.Series.Add(series37);
			this.chart1.Series.Add(series38);
			this.chart1.Series.Add(series39);
			this.chart1.Series.Add(series40);
			this.chart1.Size = new System.Drawing.Size(669, 426);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// serialPort1
			// 
			this.serialPort1.BaudRate = 115200;
			this.serialPort1.PortName = "COM4";
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 57);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(101, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(101, 21);
			this.comboBox1.TabIndex = 2;
			// 
			// timer1
			// 
			this.timer1.Interval = 250;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(12, 107);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(101, 23);
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.chart1);
			this.Name = "Form1";
			this.Text = "CSI - Phase Chart Plot";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnStop;
	}
}

