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
	class PlayerOpponentSummaryViewModel : ViewModelBase
	{
		public PlayerOpponentSummaryViewModel()
		{
			DisplayName = "Opponent Statistics";

			MethodInvoker LoadData = delegate
			{
				//List = new ObservableCollection<PlayerMatch>(PlayerMatch.GetList(DataAccess.GetAllMatches()));
				Log.Info("PlayerOpponentSummaryViewModel() retrieving player list");
				//List = PlayerMatchViewModel.GetList(PlayerMatch.GetList(DataAccess.GetAllMatches()));
				List = new ObservableCollection<MatchSummary>(MatchSummary.GetList(DataAccess.GetPlayerOpponentSummary(1)));
				//List = PlayerMatchViewModel.GetList(PlayerMatch.GetList(DataAccess.GetAllMatches()));
				Log.Info("PlayerOpponentSummaryViewModel() retrieved player list");
				OnPropertyChanged("List");
			};

			LoadData.BeginInvoke(null,null);

			ChangeSelectedItemCommand = new RelayCommand(param => OnSelectedItemChanged((SelectionChangedEventArgs)param));
		}

		public ObservableCollection<MatchSummary> List { get; private set; }

		public ICommand ChangeSelectedItemCommand { get; set; }

		public event SelectionChangedEventHandler SelectedItemChanged;

		void OnSelectedItemChanged(SelectionChangedEventArgs e)
		{
			if (SelectedItemChanged != null)				
				SelectedItemChanged(this, e);
		}
	}
}
