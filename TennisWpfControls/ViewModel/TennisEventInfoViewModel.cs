using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;

namespace TennisWpfControls.ViewModel
{
	class TennisEventInfoViewModel : ViewModelBase
	{
		TennisEvent _item;

		public TennisEventInfoViewModel()
        {
			_item = TennisEvent.Get(DataAccess.GetEvent(1));

			//_item = TennisEvent T.Get(TennisObjects.DataAccess.Player.GetPlayer(1));
        }

		public TennisEventInfoViewModel(int id)
		{
			_item = TennisEvent.Get(DataAccess.GetEvent(1));
		}

		public int ID { get { return _item.ID; } }
		public string BeginDate { get { return _item.BeginDateText; } set { _item.BeginDateText = value; } }
		public string EndDate { get { return _item.EndDateText; } set { _item.EndDateText = value; } }
		public int ClassificationID { get { return _item.ClassificationID; } set { _item.ClassificationID = value; } }
		public string Name { get { return _item.Name; } set { _item.Name = value; } }
		//public string FirstName { get { return _player.FirstName; } set { _player.FirstName = value; } }
		//public string LastName { get { return _player.LastName; } set { _player.LastName = value; } }

	}
}
