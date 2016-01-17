using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using TennisObjects.Info;

namespace TennisWpfControls.ViewModel
{
	class MatchHistoryViewModel : ViewModelBase
	{
		//ObservableCollection<Player> _list;

		public MatchHistoryViewModel()
		{
			Log.Info("MatchHistoryViewModel() starting");

			DisplayName = "Match History";

			MethodInvoker LoadData = delegate
			{
				//List = new ObservableCollection<PlayerMatch>(PlayerMatch.GetList(DataAccess.GetAllMatches()));
				Log.Info("MatchHistoryViewModel() retrieving match list");
				//List = PlayerMatchViewModel.GetList(PlayerMatch.GetList(DataAccess.GetAllMatches()));
				List = PlayerMatchViewModel.GetList(PlayerMatch.GetListMostRecent(DataAccess.GetAllMatches(), 20));
				Log.Info("MatchHistoryViewModel() retrieved match list");
			};

			LoadData.BeginInvoke(null, null);
 
			//SelectedMatchChanged = new RoutedEventHandler(OnSelectedMatchChanged);
			Log.Info("MatchHistoryViewModel() initializing commands");
			ChangeSelectedItemCommand = new RelayCommand(param => OnSelectedItemChanged((SelectionChangedEventArgs)param));
			SelectedTimespanChangedCommand = new RelayCommand(param => OnSelectedTimespanChanged((SelectionChangedEventArgs)param));
			ViewTennisEventCommand = new RelayCommand(param => OnViewTennisEventRequested());

			TennisObjects.Match.Created += new TennisObjects.Match.CreatedEventHandler(Match_Created);
			TennisObjects.Match.Updated += new TennisObjects.Match.UpdatedEventHandler(Match_Updated);

			Log.Info("MatchHistoryViewModel() done");
		}

		void Match_Updated(TennisObjects.Match obj)
		{
			Log.Info("match updated: {0}", obj);
			PlayerMatchViewModel item = List.First(delegate(PlayerMatchViewModel param) { return param.ID == obj.ID; });
			int index = List.IndexOf(item);
			List.RemoveAt(index);
			List.Insert(index, new PlayerMatchViewModel(PlayerMatch.FromMatch(obj, 1)));
			//List.Insert(0, new PlayerMatchViewModel(PlayerMatch.FromMatch(obj, 1)));
		}

		void Match_Created(TennisObjects.Match obj)
		{
			Log.Info("new match created: {0}", obj);
			List.Insert(0, new PlayerMatchViewModel(PlayerMatch.FromMatch(obj, 1)));
		}

		public ObservableCollection<PlayerMatchViewModel> List { get; private set; }
		public PlayerMatchViewModel SelectedItem { get; private set; }

		public ICommand ChangeSelectedItemCommand { get; set; }
		public ICommand SelectedTimespanChangedCommand { get; set; }
		public ICommand ViewTennisEventCommand { get; set; }

		public event SelectionChangedEventHandler SelectedItemChanged;

		public delegate void ViewTennisEventRequestedEventHandler(int TennisEventID);
		public event ViewTennisEventRequestedEventHandler ViewTennisEventRequested;

		void OnSelectedItemChanged(SelectionChangedEventArgs e)
		{
			SelectedItem = e.AddedItems.Count > 0 ? (PlayerMatchViewModel)e.AddedItems[0] : null;
			if (SelectedItemChanged != null)
				SelectedItemChanged(this, e);
		}

		void OnSelectedTimespanChanged(SelectionChangedEventArgs e)
		{
			//SelectedItem = e.AddedItems.Count > 0 ? (PlayerMatchViewModel)e.AddedItems[0] : null;
			//if (SelectedItemChanged != null)
			//	SelectedItemChanged(this, e);
			ComboBoxItem selected = e.AddedItems.Count > 0 ? (ComboBoxItem)e.AddedItems[0] : null;
			if (selected == null)
				return;
			//MessageBox.Show("You want " + selected.Content + "???");
			switch (selected.Content.ToString())
			{
				case "Last 20":
					List = PlayerMatchViewModel.GetList(PlayerMatch.GetListMostRecent(DataAccess.GetAllMatches(), 20));
					break;
				case "Last 50":
					List = PlayerMatchViewModel.GetList(PlayerMatch.GetListMostRecent(DataAccess.GetAllMatches(), 50));
					break;
				//case "Last 12 Months":
				//    List = PlayerMatchViewModel.GetList(PlayerMatch.GetListLastMonths(DataAccess.GetAllMatches(), 50));
				//    break;
				case "All":
					List = PlayerMatchViewModel.GetList(PlayerMatch.GetListAll(DataAccess.GetAllMatches()));
					break;
			}
			OnPropertyChanged("List");
		}

		void OnViewTennisEventRequested()
		{
			if (ViewTennisEventRequested != null)
				ViewTennisEventRequested(SelectedItem.Item.EventID);
		}


		internal void FilterByOpponent(int opponentID)
		{
			List<PlayerMatch> AllMatches = PlayerMatch.GetListAll(DataAccess.GetAllMatches());

			IEnumerable<PlayerMatch> query = from match in AllMatches
										where match.OpponentID == opponentID
										select match;

			List = PlayerMatchViewModel.GetList(query);
			OnPropertyChanged("List");
		}
	}
}
