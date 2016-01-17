using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using System.Collections.ObjectModel;

namespace TennisWpfControls.ViewModel
{
	class TennisEventListViewModel : ViewModelBase
	{
		public TennisEventListViewModel()
        {
			List = new ObservableCollection<TennisEvent>(TennisEvent.GetList(DataAccess.GetAllEvents()));
        }

		public ObservableCollection<TennisEvent> List { get; private set; }
	}
}
