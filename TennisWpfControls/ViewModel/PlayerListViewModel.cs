using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisObjects;
using System.Collections.ObjectModel;

namespace TennisWpfControls.ViewModel
{
	class PlayerListViewModel : ViewModelBase
	{
		//ObservableCollection<Player> _list;

		public PlayerListViewModel()
        {
			DisplayName = "Players";
			List = new ObservableCollection<Player>(Player.GetList(DataAccess.GetAllPlayers()));
        }

		public ObservableCollection<Player> List {get; private set;}

		//public int ID { get { return _player.ID; } }
		//public string FirstName { get { return _player.FirstName; } set { _player.FirstName = value; } }
		//public string LastName { get { return _player.LastName; } set { _player.LastName = value; } }

	}
}
