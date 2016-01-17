using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using System.Windows.Input;

namespace TennisWpfControls.ViewModel
{
	class PlayerInfoViewModel : ViewModelBusinessBase<Player>
	{
		#region Constructors
		public PlayerInfoViewModel(int id)
		{
			Initialize(Player.Get(DataAccess.GetPlayer(id)));
		}

		private void Initialize(Player item)
		{
			DisplayName = "Player Details";
			Item = item;

			EditItemCommand = new RelayCommand(param => OnEditRequested());
		}
		#endregion

		#region Properties
		public int ID { get { return Item.ID; } }
		public string FirstName { get { return Item.FirstName; } set { Item.FirstName = value; } }
		public string LastName { get { return Item.LastName; } set { Item.LastName = value; } }
		#endregion

		#region Events and Commands
		public ICommand EditItemCommand { get; set; }

		public delegate void EditRequestedEventHandler(Player item);
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
