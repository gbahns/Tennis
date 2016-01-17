using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using Bahns.Util;

namespace TennisWpfControls.ViewModel
{
	class TennisEventEditViewModel : ViewModelBusinessBase<TennisEvent>
	{
		public TennisEventEditViewModel()
		{
			Initialize(TennisEvent.Create());
		}

		public TennisEventEditViewModel(string initialName)
		{
			Initialize(TennisEvent.Create(initialName));
		}

		public TennisEventEditViewModel(int id)
		{
			Initialize(TennisEvent.Get(DataAccess.GetEvent(id)));
		}

		public TennisEventEditViewModel(TennisEvent item)
		{
			Initialize(item);
		}

		private void Initialize(TennisEvent item)
		{
			DisplayName = item.IsNew ? "New Event" : "Edit Event";
			Item = item;
		}

		public int ID { get { return Item.ID; } }
		public string Name { get { return Item.Name; } set { Item.Name = value; } }
		public int ClassificationID { get { return Item.ClassificationID; } set { Item.ClassificationID = value; } }
		public SmartDate BeginDate { get { return Item.BeginDate; } set { Item.BeginDate = value; } }
		public SmartDate EndDate { get { return Item.EndDate; } set { Item.EndDate = value; } }
		public bool IsLeague { get { return Item.IsLeague; } set { Item.IsLeague = value; } }
		public bool IsTournament { get { return Item.IsTournament; } set { Item.IsTournament = value; } }
		public bool TeamPlay { get { return Item.TeamPlay; } set { Item.TeamPlay = value; } }

	}
}
