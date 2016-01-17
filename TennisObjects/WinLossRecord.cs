namespace TennisObjects
{
	public struct WinLossRecord
	{
		public int Won;
		public int Lost;
		public int Total
		{
			get { return Won + Lost; }
		}
		public double Pct
		{
			get { return (double)Won / (double)Total; }
		}
		public override string ToString()
		{
			return string.Format("{0}-{1}", Won, Lost);
		}
	}
}