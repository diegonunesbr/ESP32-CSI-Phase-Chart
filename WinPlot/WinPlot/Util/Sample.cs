using System;
using System.Collections.Generic;
using System.Linq;


namespace WinPlot {
	public class Sample {

		const int SubMin = -26;
		const int SubMax = 26;

		const double factor2 = 1000000000.0;

		public List<Point> Points;


		public Sample() {
			Points = new List<Point>();
		}

		public void CalculateAmplitudePhase(double frequencyBase, double frequencyInrement) {
			foreach(Point p in Points) {
				p.Frequency = frequencyBase + p.SubCarrier * frequencyInrement;
				p.Amplitude = Math.Sqrt(p.Imaginary * p.Imaginary + p.Real * p.Real);
				p.Phase = Math.Atan2(p.Imaginary, p.Real);
			}
		}

		public void NormalizePhase() {
			const double deltaPI = Math.PI * 0.9;
			const double doublePI = 2.0 * Math.PI;

			Point p_1 = Points.Find(x => x.SubCarrier == -1);
			Point p0 = Points.Find(x => x.SubCarrier == 0);
			Point p1 = Points.Find(x => x.SubCarrier == 1);
			Point p2 = Points.Find(x => x.SubCarrier == 2);

			if(p_1 == null || p0 == null || p1 == null || p2 == null) {
				return;
			}

			p0.Phase = p_1.Phase;
			p1.Phase = p2.Phase;

			double acc = 0;
			double lastVal = Math.PI;
			for(int sc = SubMin; sc <= SubMax; sc++) {
				Point p = Points.Find(x => x.SubCarrier == sc);

				while(p.Phase >= lastVal + deltaPI) {
					lastVal += doublePI;
					acc -= doublePI;
				}

				while(p.Phase <= lastVal - deltaPI) {
					lastVal -= doublePI;
					acc += doublePI;
				}
				p.Phase2 = acc + p.Phase;
				lastVal = p.Phase;
			}

			double delta = (p2.Phase2 - p_1.Phase2) / 3.0;
			p0.Phase2 = p_1.Phase2 + delta;
			p1.Phase2 = p_1.Phase2 + delta + delta;
		}

		public void CentralizePhase() {
			Point p0 = Points.Find(x => x.SubCarrier == 0);
			double central = p0.Phase2;
			for(int sc = SubMin; sc <= SubMax; sc++) {
				Point p = Points.Find(x => x.SubCarrier == sc);
				p.Phase2 -= central;
			}
		}
	}
}
