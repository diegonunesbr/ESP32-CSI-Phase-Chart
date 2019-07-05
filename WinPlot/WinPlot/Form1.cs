using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinPlot {
	public partial class Form1: Form {
		string m_buffer;
		Collector m_colletor;

		public Form1() {
			InitializeComponent();

			m_buffer = string.Empty;
			m_colletor = new Collector();
		}

		private void Form1_Load(object sender, EventArgs e) {
			comboBox1.Items.Clear();
			string[] ports = System.IO.Ports.SerialPort.GetPortNames();
			comboBox1.Items.AddRange(ports);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			CloseSerialPort();
		}

		private void btnStart_Click(object sender, EventArgs e) {
			OpenSerialPort();
		}

		private void btnStop_Click(object sender, EventArgs e) {
			CloseSerialPort();
		}

		private void timer1_Tick(object sender, EventArgs e) {
			RedrawChart();
		}

		private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
			try {
				m_buffer += serialPort1.ReadExisting();
				int pos;
				while((pos = m_buffer.IndexOf('\n')) >= 0) {
					string line = m_buffer.Substring(0, pos);
					m_colletor.AddSampleLine(line);
					//m_changes = true;
					m_buffer = m_buffer.Substring(pos + 1);
				}
			} catch {
				CloseSerialPort();
			}
		}

		void OpenSerialPort() {
			btnStart.Enabled = false;
			try {
				serialPort1.PortName = comboBox1.Text;
				serialPort1.Open();
				timer1.Enabled = true;
				btnStop.Enabled = true;
			} catch {
				CloseSerialPort();
			}
		}

		void CloseSerialPort() {
			btnStop.Enabled = false;
			try {
				timer1.Enabled = false;
				serialPort1.Close();
			} catch {
			}
			btnStart.Enabled = true;
		}

		void RedrawChart() {
			try {
				for(int i = 0; i < m_colletor.Samples.Count; i++) {
					Series se = chart1.Series[i];
					se.Points.Clear();

					for(int j = 0; j < m_colletor.Samples[i].Points.Count; j++) {
						Point p = m_colletor.Samples[i].Points[j];
						DataPoint dp = new DataPoint();
						dp.XValue = p.SubCarrier;
						dp.YValues = new double[] { p.Phase2 };
						se.Points.Add(dp);
					}
				}
			} catch {
			}
		}
	}
}
