using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;

namespace Bahns.Data
{
	[Serializable]
	public class RecordNotFoundException : Exception
	{
		
		public RecordNotFoundException(long id)
			: base(string.Format(CultureInfo.CurrentCulture, "Specified record not found (ID {0})", id))
		{
		}
		
		public RecordNotFoundException()
			: base()
		{
		}

		public RecordNotFoundException(string message)
			: base(message)
		{
		}

		public RecordNotFoundException(string message, Exception inner)
			: base(message,inner)
		{
		}

		// This constructor is needed for serialization.
		protected RecordNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info,context)
		{
		}
	}
}
