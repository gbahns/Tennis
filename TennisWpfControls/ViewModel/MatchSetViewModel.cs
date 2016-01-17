using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using Bahns.Util;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace TennisWpfControls.ViewModel
{
	class MatchSetViewModel : ViewModelBusinessBase<MatchScore.MatchSet>
	{
		public MatchSetViewModel(MatchScore.MatchSet item)
		{
			Item = item;
			if (Item.PreviousSet != null)
				Item.PreviousSet.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PreviousSet_PropertyChanged);
		}

		void PreviousSet_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			OnPropertyChanged("SetVisibility");
		}

		protected override void ItemPropertyChanged(string propertyName)
		{
			switch (propertyName)
			{
				case "WGames":
				case "LGames":
					OnPropertyChanged("TiebreakVisibility");
					break;
			}
		}

		public int SetNumber { get { return Item.SetNumber; } }
		public byte WGames { get { return Item.WGames; } set { Item.WGames = value; } }
		public byte LGames { get { return Item.LGames; } set { Item.LGames = value; } }
		public byte WTiebreak { get { return Item.WTiebreak; } set { Item.WTiebreak = value; } }
		public byte LTiebreak { get { return Item.LTiebreak; } set { Item.LTiebreak = value; } }

		public Visibility SetVisibility { get { return Item.SetNumber == 1 || Item.PreviousSet.SetPlayed ? Visibility.Visible : Visibility.Collapsed; } }
		public Visibility TiebreakVisibility { get { return Math.Abs(WGames - LGames) == 1 ? Visibility.Visible : Visibility.Hidden; } }
	}
}
