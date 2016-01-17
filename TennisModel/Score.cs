using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
	public struct Score
	{
		public byte W;
		public byte L;
		public bool Played { get { return W > 0 || L > 0; } }
	}
}
