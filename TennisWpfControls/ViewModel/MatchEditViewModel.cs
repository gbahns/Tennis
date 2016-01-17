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
using System.ComponentModel;

namespace TennisWpfControls.ViewModel
{
	class MatchEditViewModel : ViewModelBusinessBase<Match>
	{
		#region Constructors
		public MatchEditViewModel()
		{
			Initialize(Match.Create());
		}

		public MatchEditViewModel(int matchID)
		{
			Initialize(Match.Get(DataAccess.GetMatch(matchID)));
		}

		public MatchEditViewModel(Match item)
		{
			Initialize(item);
		}

		public void Initialize(Match item)
		{
			Item = item;
			DisplayName = item.IsNew ? "New Match" : "Edit Match";
			PlayerList = new ObservableCollection<Player>(Player.GetList(DataAccess.GetAllPlayers()));
			EventList = new ObservableCollection<TennisEvent>(TennisEvent.GetList(DataAccess.GetAllEvents()));

			for (int i = 0; i < 5; i++)
			{
				_sets[i] = new MatchSetViewModel(Item.Score.Sets[i]);
				_sets[i].PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MatchViewModel_PropertyChanged);
			}

			SaveItemCommand = new RelayCommand(param => SaveItem());
			CancelCommand = new RelayCommand(param => Cancel());
		}
 		#endregion

		#region Events and Commands
		void SaveItem()
		{
			if (!Item.IsSavable)
			{
				MessageBox.Show(((IDataErrorInfo)Item).Error);
				return;
			}

			Item.Save();
			OnEditCompleted();
		}

		void Cancel()
		{
			OnEditCompleted();
		}

		void MatchViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			OnPropertyChanged("Score");
		}

		protected override void ItemPropertyChanged(string propertyName)
		{
			Debug.WriteLine(string.Format("MatchEditViewModel Property Changed: {0}", propertyName));
			if (string.IsNullOrEmpty(propertyName))
			{
				OnPropertyChanged(null);
				OnPropertyChanged("MatchScore");
				return;
			}

			OnPropertyChanged(propertyName);

			switch (propertyName)
			{
				case "EventID":
					OnPropertyChanged("EventName");
					break;

				case "WinnerID":
					OnPropertyChanged("WinnerName");
					break;

				case "LoserID":
					OnPropertyChanged("LoserName");
					break;
			}
		}

		public ICommand SaveItemCommand { get; set; }
		public ICommand CancelCommand { get; set; }

		public delegate void EditCompletedEventHandler(Match item);
		public event EditCompletedEventHandler EditCompleted;

		protected virtual void OnEditCompleted()
		{
			if (EditCompleted != null)
			{
				EditCompleted(Item);
			}
		}

		//public delegate void EditCancelledEventHandler(Match item);
		//public event EditCancelledEventHandler EditCancelled;
		#endregion

		#region Properties
		public int ID { get { return Item.ID; } }
		public Int32 EventID { get { return Item.EventID; } set { Item.EventID = value; } }
		public string MatchDateStr { get { return Item.MatchDate.Text; } set { Item.MatchDate = SmartDate.FromString(value); } }
		public DateTime MatchDate
		{
			get { return Item.MatchDate; }
			set 
			{
				//SmartDate time = SmartDate.FromString(MatchTime);
				//Item.MatchDate = value;
				Item.MatchDate = SmartDate.FromString(value.ToShortDateString() + " " + MatchTime);
				OnPropertyChanged("MatchTime"); 
			}
		}
		public string MatchTime
		{
			get { return Item.MatchDate.ToShortTimeString(); }
			set 
			{
				SmartDate date = SmartDate.FromString(Item.MatchDate.ToShortDateString());
				SmartDate time = SmartDate.FromString(value);
				Item.MatchDate = SmartDate.FromString(Item.MatchDate.ToShortDateString() + " " + value);
				OnPropertyChanged("MatchTime");
			}
		}

		public Int32 WinnerID { get { return Item.WinnerID; } set { Item.WinnerID = value; } }
		public Int32 LoserID { get { return Item.LoserID; } set { Item.LoserID = value; } }
		public string Score { get { return Item.Score.ToString(true); } }

		MatchSetViewModel[] _sets = new MatchSetViewModel[5];
		public MatchSetViewModel Set1 { get { return _sets[0]; } }
		public MatchSetViewModel Set2 { get { return _sets[1]; } }
		public MatchSetViewModel Set3 { get { return _sets[2]; } }
		public MatchSetViewModel Set4 { get { return _sets[3]; } }
		public MatchSetViewModel Set5 { get { return _sets[4]; } }

		public string EventName { get { return EventList.Single(item => item.ID == EventID).Name; } }
		public string WinnerName { get { return PlayerList.Single(item => item.ID == WinnerID).FullName; } }
		public string LoserName { get { return PlayerList.Single(item => item.ID == LoserID).FullName; } }

		public ObservableCollection<Player> PlayerList { get; private set; }
		public ObservableCollection<TennisEvent> EventList { get; private set; }

		public string Error { get { return Item.BrokenRulesCollection.ToString(); } }
		public Visibility ErrorIconVisibility { get { return Item.BrokenRulesCollection.Count > 0 ? Visibility.Visible : Visibility.Hidden; } }
 		#endregion
	}
}
