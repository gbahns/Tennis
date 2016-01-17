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
using TennisObjects.Info;

namespace TennisWpfControls.ViewModel
{
	class PlayerMatchViewModel : ViewModelBase
	{
		public static ObservableCollection<PlayerMatchViewModel> GetList(IEnumerable<PlayerMatch> list)
		{
			var viewlist = new ObservableCollection<PlayerMatchViewModel>();
			foreach (PlayerMatch item in list)
			{
				viewlist.Add(new PlayerMatchViewModel(item));
			}
			return viewlist;
		}

		public PlayerMatchViewModel(PlayerMatch item)
		{
			Item = item;

			EditItemCommand = new RelayCommand(param => OnEditRequested());
		}

		public PlayerMatch Item { get; private set; }

		public int ID { get { return Item.ID; } }
		public string EventName { get { return Item.EventName; } }
		public string MatchDate { get { return Item.MatchDate.ToShortDateString(); } }
		public string OpponentName { get { return Item.OpponentName; } }
		public string Result { get { return Item.Result; } }
		public string Score { get { return Item.Score.ToString(); } }

		#region EditMatchCommand
		public ICommand EditItemCommand { get; set; }

		public delegate void EditRequestedEventHandler(PlayerMatch item);
		public event EditRequestedEventHandler EditRequested;
		
		protected virtual void OnEditRequested()
        {
			if (EditRequested != null)
            {
				EditRequested(Item);
            }
        }
		
		#endregion
	}
}
