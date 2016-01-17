using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
    public class Player
	{
        public Player()
        {
            FirstName = "";
            LastName = "";
        }

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[NotMapped]
		public string FullName
		{
			get { return (FirstName + " " + LastName).Trim(); }
			set
			{
				string[] array = value.Split(" ".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length > 0)
				{
					FirstName = array[0];
					if (array.Length > 1)
					{
						LastName = array[1];
					}
				}
			}
		}
    }
}
