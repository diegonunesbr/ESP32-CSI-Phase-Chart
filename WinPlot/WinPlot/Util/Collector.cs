using System;
using System.Collections.Generic;


namespace WinPlot {
	public class Collector {

		const double FrequencyIncrement = 312500.0;
		const int MaxSamples = 10;

		const int SubMin = -26;
		const int SubMax = 26;

		public List<Sample> Samples;


		public Collector() {
			Samples = new List<Sample>();
		}

		public void AddSampleLine(string line) {
			if(!line.StartsWith("[[[\t") || !line.EndsWith("\t]]]")) {
				return;
			}
			//line = line.Substring(5);
			int[] iValues = new int[128];
			string[] sValues = line.Split('\t');
			if(sValues.Length < 131) {
				return;
			}

			int wifiChannel = Convert.ToInt32(sValues[1]);
			if(wifiChannel > 14) {
				wifiChannel = 0;
			}

			for(int i = 0; i < 128; i++) {
				iValues[i] = Convert.ToInt32(sValues[i + 2]);
			}

			// remove old samples
			if(Samples.Count >= MaxSamples) {
				Samples.RemoveRange(0, Samples.Count - MaxSamples + 1);
			}

			Sample sa = new Sample();
			Samples.Add(sa);

			for(int i = SubMin; i < 0; i++) {
				Point p = new Point();
				p.SubCarrier = i;
				p.Imaginary = iValues[i * 2 + 128];
				p.Real = iValues[i * 2 + 128 + 1];
				sa.Points.Add(p);
			}
			for(int i = 0; i <= SubMax; i++) {
				Point p = new Point();
				p.SubCarrier = i;
				p.Imaginary = iValues[i * 2];
				p.Real = iValues[i * 2 + 1];
				sa.Points.Add(p);
			}

			sa.CalculateAmplitudePhase(WifiChannelList[wifiChannel], FrequencyIncrement);
			sa.NormalizePhase();
			sa.CentralizePhase();
		}

		static double[] WifiChannelList = new double[] {
			0,
			2412000000.0,
			2417000000.0,
			2422000000.0,
			2427000000.0,
			2432000000.0,
			2437000000.0,
			2442000000.0,
			2447000000.0,
			2452000000.0,
			2457000000.0,
			2462000000.0,
			2467000000.0,
			2472000000.0,
			2484000000.0
		};
	}
}
