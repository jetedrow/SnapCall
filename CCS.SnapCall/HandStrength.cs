using Humanizer;
using SnapCall.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCall
{
	public class HandStrength : IComparable<HandStrength>
	{
		public HandRanking HandRanking { get; set; }

		//public int? Primary { get; set; }

		//public int? Secondary { get; set; }

		public List<int> Kickers { get; set; }

		public int CompareTo(HandStrength other)
		{
			if (this.HandRanking > other.HandRanking) return 1;
			else if (this.HandRanking < other.HandRanking) return -1;

			//if ((this?.Primary ?? -1) > (other?.Primary ?? -1)) return 1;
			//else if ((this?.Primary ?? -1) < (other?.Primary ?? -1)) return 1;

			//if ((this?.Secondary ?? -1) > (other?.Secondary ?? -1)) return 1;
			//else if ((this?.Secondary ?? -1) < (other?.Secondary ?? -1)) return 1;

			for (var i = 0; i < this.Kickers.Count; i++)
			{
				if (this.Kickers[i] > other.Kickers[i]) return 1;
				if (this.Kickers[i] < other.Kickers[i]) return -1;
			}

			return 0;
		}

		public override string ToString()
		{
			switch (HandRanking)
			{
				case HandRanking.StraightFlush:
				case HandRanking.Straight:
				case HandRanking.Flush:
					return $"{HandRanking.Humanize()}, {((Rank)Kickers[0]).Humanize()} high.";
				case HandRanking.FourOfAKind:
				case HandRanking.ThreeOfAKind:
					return $"{HandRanking.Humanize()}, {((Rank)Kickers[0]).Humanize()}s.";
				case HandRanking.FullHouse:
					return $"{HandRanking.Humanize()}, {((Rank)Kickers[0]).Humanize()}s over {((Rank)Kickers[1]).Humanize()}s.";
				case HandRanking.Pair:
					return $"{HandRanking.Humanize()} of {((Rank)Kickers[0]).Humanize()}s.";
				case HandRanking.HighCard:
					return $"{HandRanking.Humanize()}, {((Rank)Kickers[0]).Humanize()}.";
				default:
					return "Unknown";
			}
		}
	}
}
