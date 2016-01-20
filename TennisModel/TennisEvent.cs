using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TennisModel
{
	[Table("Events")]
	public class TennisEvent
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int? ClassificationID { get; set; }
		public DateTime? BeginDate { get; set; }
		public DateTime? EndDate { get; set; }
		public short Type { get; set; }
		public bool? TeamPlay { get; set; }
	}
}
