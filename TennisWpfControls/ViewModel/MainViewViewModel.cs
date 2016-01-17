using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using TennisObjects;
using System.Windows;

namespace TennisWpfControls.ViewModel
{
	class MainViewViewModel : ViewModelBase
	{
		#region Constructors
		public MainViewViewModel()
		{
			Log.Info("MainViewViewModel() starting");

			DisplayName = "I am the Tennis Master!!!";
			//base.DisplayName = Strings.MainWindowViewModel_DisplayName;

			//_customerRepository = new CustomerRepository(customerDataFile);

			//_activeViewModel = new MatchHistoryViewModel();
			//ViewAllMatches();

			//ViewPlayerCommand = new RelayCommand(param => ActiveViewModel = new PlayerViewModel());
			//ViewAllPlayersCommand = new RelayCommand(param => ActiveViewModel = new PlayerListViewModel());
			//ViewTennisEventCommand = new RelayCommand(param => ActiveViewModel = new TennisEventViewModel());
			//ViewAllTennisEventsCommand = new RelayCommand(param => ActiveViewModel = new TennisEventListViewModel(), param => true);
			//ViewAllMatchesCommand = new RelayCommand(param => ViewAllMatches());
			//ViewMatchCommand = new RelayCommand(param => ActiveViewModel = new MatchViewModel());
			NewMatchCommand = new RelayCommand(param => ItemDetailViewModel = new MatchEditViewModel());
			NewPlayerCommand = new RelayCommand(param => ItemDetailViewModel = new PlayerEditViewModel());
			//NewEventCommand = new RelayCommand(param => ItemDetailViewModel = new TennisEventEditViewModel());

			Log.Info("MainViewViewModel() creating MatchEditViewModel");
			ItemDetailViewModel = new MatchEditViewModel();

			Log.Info("MainViewViewModel() creating NewMatchHistoryViewModel");
			MatchHistoryViewModel = NewMatchHistoryViewModel();

			Log.Info("MainViewViewModel() creating NewOpponentSummaryViewModel");
			SummaryViewModel = NewOpponentSummaryViewModel();

			//MatchHistoryViewModel.

			EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
			Log.Info("MainViewViewModel() done");
		}
		#endregion

		#region Event Handlers
		void PlayerViewModel_EditRequested(Player item)
		{
			ItemDetailViewModel = new PlayerEditViewModel(item);
		}

		void MatchViewModel_EditRequested(Match item)
		{
			var vm = new MatchEditViewModel(item);
			vm.EditCompleted += new MatchEditViewModel.EditCompletedEventHandler(MatchViewModel_EditCompleted);
			ItemDetailViewModel = vm;
		}

		void MatchViewModel_EditCompleted(Match item)
		{
			//switch the edit view back to read-only mode
			//todo: add a MatchViewModel constructor that takes an existing Match object
			var vm = new MatchInfoViewModel(item.ID);
			vm.EditRequested += new MatchInfoViewModel.EditRequestedEventHandler(MatchViewModel_EditRequested);
			ItemDetailViewModel = vm;

			//Update the list
		}

		void SelectedPlayerChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count == 0)
				return;
			var item = (TennisObjects.Info.MatchSummary)e.AddedItems[0];
			var vm = new PlayerInfoViewModel(item.ID);
			vm.EditRequested += new PlayerInfoViewModel.EditRequestedEventHandler(PlayerViewModel_EditRequested);

			//right here
			MatchHistoryViewModel.FilterByOpponent(item.ID);

			//vm.EditRequested += new MatchViewModel.EditRequestedEventHandler(MatchViewModel_EditRequested);
			ItemDetailViewModel = vm;
		}

		void MatchHistoryViewModel_ViewTennisEventRequested(int TennisEventID)
		{
			var vm = new TennisEventInfoViewModel(TennisEventID);
			ItemDetailViewModel = vm;
		}

		void SelectedMatchChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count == 0)
				return;
			var match = (PlayerMatchViewModel)e.AddedItems[0];
			var vm = new MatchInfoViewModel(match.ID);
			vm.EditRequested += new MatchInfoViewModel.EditRequestedEventHandler(MatchViewModel_EditRequested);
			ItemDetailViewModel = vm;
		}

		private void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			(sender as TextBox).SelectAll();
		}
		#endregion

		#region ViewModel Creation
		ViewModelBase NewOpponentSummaryViewModel()
		{
			var vm = new PlayerOpponentSummaryViewModel();
			vm.SelectedItemChanged += new SelectionChangedEventHandler(SelectedPlayerChanged);
			return vm;
		}

		MatchHistoryViewModel NewMatchHistoryViewModel()
		{
			var vm = new MatchHistoryViewModel();
			vm.SelectedItemChanged += new SelectionChangedEventHandler(SelectedMatchChanged);
			//vm.ViewTennisEventRequested += new MatchHistoryViewModel.ViewTennisEventRequestedEventHandler(;
			vm.ViewTennisEventRequested += new MatchHistoryViewModel.ViewTennisEventRequestedEventHandler(MatchHistoryViewModel_ViewTennisEventRequested);
			return vm;
		}
		#endregion

		#region Properties
		public string ItemDetailHeight
		{
			get
			{
				switch (ItemDetailViewModel.DisplayName)
				{
					case "New Match":
					case "Edit Match":
						return "auto";
					
					default:
						return "180";
				}
			}
		}
		#endregion

		//private ViewModelBase _activeViewModel;
		private ViewModelBase _itemDetailViewModel;
		public ViewModelBase ItemDetailViewModel
		{
			get { return _itemDetailViewModel; }
			private set
			{
				_itemDetailViewModel = value;
				OnPropertyChanged("ItemDetailViewModel");
				OnPropertyChanged("ItemDetailHeight");
			}
		}
							
		public ViewModelBase SummaryViewModel { get; set; }
		public MatchHistoryViewModel MatchHistoryViewModel { get; set; }

		//public ViewModelBase ActiveViewModel
		//{
		//    get { return _activeViewModel; }
		//    set
		//    {
		//        if (_activeViewModel == value)
		//            return;
		//        _activeViewModel = value;
		//        OnPropertyChanged("ActiveViewModel");
		//    }
		//}

		//public ICommand ViewPlayerCommand { get; set; }
		public ICommand ViewAllPlayersCommand { get; set; }
		public ICommand ViewTennisEventCommand { get; set; }
		public ICommand ViewAllTennisEventsCommand { get; set; }
		public ICommand ViewAllMatchesCommand { get; set; }
		public ICommand NewMatchCommand { get; set; }
		public ICommand NewPlayerCommand { get; set; }
		public ICommand NewTennisEventCommand { get; set; }
		//public ICommand ViewMatchCommand { get; set; }
	}
}
