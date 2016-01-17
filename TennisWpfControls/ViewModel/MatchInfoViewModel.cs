using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using Bahns.Util;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace TennisWpfControls.ViewModel
{
	class MatchInfoViewModel : ViewModelBase
	{
		#region Constructors
		TennisObjects.Info.Match Item;

		public MatchInfoViewModel(int matchID)
		{
			Item = TennisObjects.Info.Match.Get(DataAccess.GetMatch(matchID));
			DisplayName = "Match ";
			PlayerList = new ObservableCollection<Player>(Player.GetList(DataAccess.GetAllPlayers()));
			EventList = new ObservableCollection<TennisEvent>(TennisEvent.GetList(DataAccess.GetAllEvents()));

			EditItemCommand = new RelayCommand(param => OnEditRequested());
		}
		#endregion

		#region Properties
		public int ID { get { return Item.ID; } }
		public Int32 EventID { get { return Item.EventID; } }
		public string MatchDate { get { return Item.MatchDate.ToShortDateString() + " " + Item.MatchDate.ToShortTimeString(); }  }
		public Int32 WinnerID { get { return Item.WinnerID; }  }
		public Int32 LoserID { get { return Item.LoserID; }  }
		public string Score { get { return Item.Score.ToString(true); } }

		public string EventName { get { return EventList.Single(item => item.ID == EventID).Name; } }
		public string WinnerName { get { return PlayerList.Single(item => item.ID == WinnerID).FullName; } }
		public string LoserName { get { return PlayerList.Single(item => item.ID == LoserID).FullName; } }

		public ObservableCollection<Player> PlayerList { get; private set; }
		public ObservableCollection<TennisEvent> EventList { get; private set; }
		#endregion

		#region Events and Commands
		public ICommand EditItemCommand { get; set; }

		public delegate void EditRequestedEventHandler(Match item);
		public event EditRequestedEventHandler EditRequested;
		
		protected virtual void OnEditRequested()
        {
			if (EditRequested != null)
            {
				EditRequested(Match.FromInfo(Item));
            }
        }
		#endregion
	}
}
