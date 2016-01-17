using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;

namespace TennisWpfControls.ViewModel
{
	class PlayerEditViewModel : ViewModelBusinessBase<Player>
	{
		public PlayerEditViewModel()
		{
			Initialize(Player.Create());
		}

		public PlayerEditViewModel(string initialName)
		{
			Initialize(Player.Create(initialName));
		}

		public PlayerEditViewModel(int id)
		{
			Initialize(Player.Get(DataAccess.GetPlayer(id)));
		}

		public PlayerEditViewModel(Player item)
		{
			Initialize(item);
		}

		private void Initialize(Player item)
		{
			DisplayName = item.IsNew ? "New Player" : "Edit Player";
			Item = item;
		}

		public int ID { get { return Item.ID; } }
		public string FirstName { get { return Item.FirstName; } set { Item.FirstName = value; } }
		public string LastName { get { return Item.LastName; } set { Item.LastName = value; } }

	}
}
