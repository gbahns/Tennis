using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Bahns.Util
{
	public struct SmartEnum<T> : IConvertible where T : struct
	{
		T _value;

		#region Constructors

		public SmartEnum(T value)
		{
			_value = value;
		}

		//this constructor is used internally by FromObject
		//keep it private to avoid inadvertent attempts to contruct with wrong types
		private SmartEnum(object value)
		{
			_value = IsEnumNull(value) ? NullValue : (T)value;
		}

		//this constructor is used internally by FromObject
		//keep it private to avoid inadvertent attempts to contruct with wrong types
		private SmartEnum(string value)
		{
			try
			{
				//_isNull = string.IsNullOrEmpty(value);
				//_value = _isNull ? NullValue : (T)Enum.Parse(typeof(T), value);
				_value = string.IsNullOrEmpty(value) ? NullValue : (T)Enum.Parse(typeof(T), value);
			}
			catch (FormatException)
			{
				//_isNull = true;
				_value = NullValue;
			}
		}
		#endregion

		#region Static Members

		public static T NullValue = (T)(object)(int.MinValue);

		static SmartEnum()
		{
		}

		public static bool IsEnumNull(T value)
		{
			return !Enum.IsDefined(typeof(T), value);
		}

		public static bool IsEnumNull(object value)
		{
			if (value == null || value == DBNull.Value)
				return true;

			return IsEnumNull((T)value);
		}

		public static implicit operator T(SmartEnum<T> e)
		{
			return e._value;
		}

		public static implicit operator SmartEnum<T>(T e)
		{
			return new SmartEnum<T>(e);
		}

		public static explicit operator int(SmartEnum<T> e)
		{
			return (int)(object)e._value;
		}

		public static SmartEnum<T> FromObject(object value)
		{
			return new SmartEnum<T>(value);
		}

		public static SmartEnum<T> FromString(string value)
		{
			return new SmartEnum<T>(value);
		}
		#endregion

		#region Properties
		public bool IsNull
		{
			get { return IsEnumNull(_value); }
			set { _value = NullValue ; }
		}

		public object Value
		{
			get { return IsNull ? null : (object)_value; }
		}

		public object DbValue
		{
			get { return IsNull ? DBNull.Value : (object)_value; }
		}

		public override string ToString()
		{
			return IsNull ? "" : _value.ToString();
		}
		#endregion

		#region IConvertible Members

		public ulong ToUInt64(IFormatProvider provider)
		{
			return (ulong)(object)_value;
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			return (sbyte)(object)_value;
		}

		public double ToDouble(IFormatProvider provider)
		{
			return (double)(object)_value;
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartEnum cannot be converted to DateTime");
		}

		public float ToSingle(IFormatProvider provider)
		{
			return (float)(object)_value;
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartEnum cannot be converted to Boolean");
		}

		public int ToInt32(IFormatProvider provider)
		{
			return (int)(object)_value;
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			return (ushort)(object)_value;
		}

		public short ToInt16(IFormatProvider provider)
		{
			return (short)(object)_value;
		}

		string System.IConvertible.ToString(IFormatProvider provider)
		{
			return ToString();
		}

		public byte ToByte(IFormatProvider provider)
		{
			return (byte)(object)_value;
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Char");
		}

		public long ToInt64(IFormatProvider provider)
		{
			return (long)(object)_value;
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			return (decimal)(object)_value;
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(_value, conversionType);
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			return (uint)(object)_value;
		}

		#endregion
	}

	/// <summary>
	/// SmartDate's purpose is to extend the behavior of DateTime to support the concept
	/// of "empty" or "null" date values in a seamless and intuitive fashion.  
	/// 
	/// A major goal is to allow for a SmartDate object to be used exactly is if it were 
	/// a regular DateTime object.  This goal is seriously hindered by the fact that 
	/// DateTime is sealed and therefore can't be inherited from.  For this reason we will 
	/// need to add pass-through methods for each DateTime method that we wish to support.
	/// Ideally we would simply add all of them, but that would be a bit time-consuming.
	/// As such, we'll just have to add them as we go.
	/// 
	/// We have achieved some consistency with the standard DateTime by declaring as a
	/// struct (i.e. a value type) and also by providing implicit conversion operators
	/// (which wouldn't be necessary if we could inherit from DateTime).
	/// </summary>
	[Serializable]
	[System.Diagnostics.DebuggerDisplay("{ToString()} ({_date})")]
	public struct SmartDate : IConvertible
	{
		private DateTime _date;

		#region Constructors

		public SmartDate(DateTime date)
		{
			_date = date;
		}

		//this constructor is used internally by FromObject
		//keep it private to avoid inadvertent attempts to contruct with wrong types
		private SmartDate(object date)
		{
			_date = IsDateNull(date) ? NullDate : (DateTime)date;
		}

		//this constructor is used internally by FromObject
		//keep it private to avoid inadvertent attempts to contruct with wrong types
		private SmartDate(string date)
		{
			try
			{
				_date = string.IsNullOrEmpty(date) ? NullDate : DateTime.Parse(date);
			}
			catch (FormatException)
			{
				_date = NullDate;
			}
		}

		#endregion

		#region Static Members

		public static DateTime NullDate = DateTime.MinValue;

		public static bool IsDateNull(DateTime date)
		{
			return (date == NullDate);
		}

		public static bool IsDateNull(object date)
		{
			if (date == null || date == DBNull.Value)
				return true;

			return IsDateNull((DateTime)date);
		}

		public static implicit operator DateTime(SmartDate d)
		{
			return d._date;
		}

		public static implicit operator SmartDate(DateTime d)
		{
			return new SmartDate(d);
		}

		public static SmartDate FromObject(object date)
		{
			return new SmartDate(date);
		}

		public static SmartDate FromString(string date)
		{
			return new SmartDate(date);
		}

		public static SmartDate FromMonthYear(string s)
		{
			SmartDate date = new SmartDate();
			date.MonthYear = s;
			return date;
		}

		public static SmartDate FromYear(string s)
		{
			SmartDate date = new SmartDate();
			date.YearOnly = s;
			return date;
		}

		public static SmartDate FromYear(int year)
		{
			return new DateTime(year,1,1);
		}

		#endregion

		#region Properties
		public bool IsNull
		{
			get { return IsDateNull(_date); }
			set { _date = NullDate; }
		}

		public object Value
		{
			get { return IsNull ? null : (object)_date; }
		}

		public object DbValue
		{
			get { return IsNull ? DBNull.Value : (object)_date; }
		}

		public string MonthYear
		{
			get
			{
				return IsNull ? "" : String.Concat(Month.ToString(), "/", Year.ToString());
			}
			set
			{
				value = (value == null) ? "" : value.Trim();
				if (value == "")
					IsNull = true;
				else
				{
					string[] dateParts = value.Split(new char[] { '/', '-' });
					if (dateParts.Length != 2)
						throw new FormatException("The date must be in month/year format");
					_date = new DateTime(int.Parse(dateParts[1]), int.Parse(dateParts[0]), 1);
				}
			}
		}

		public string YearOnly
		{
			get
			{
				return IsNull ? "" : Year.ToString();
			}
			set
			{
				value = (value == null) ? "" : value.Trim();
				if (value == "")
					IsNull = true;
				else
					_date = new DateTime(int.Parse(value), 1, 1);
			}
		}

		public string ToString(string format)
		{
			//return IsNull ? "" : string.Format(format,_date);
			return IsNull ? "" : _date.ToString(format);
			//_date.ToString(format);
		}

		/// <summary>
		/// Gets or sets the date value.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This property can be used to set the date value by passing a
		/// text representation of the date. Any text date representation
		/// that can be parsed by the .NET runtime is valid.
		/// </para><para>
		/// When the date value is retrieved via this property, the text
		/// is formatted by using the format specified by the 
		/// <see cref="FormatString" /> property. The default is the
		/// short date format (d).
		/// </para>
		/// </remarks>
		public string Text
		{
			get { return ToString(); } // DateToString(this.Date, FormatString, _emptyValue); }
			set { this._date = FromString(value); }
		}
		#endregion

		public static bool ThrowWhenNull = false;

		/*private bool x()
		{
			Attribute.GetCustomAttribute(
		}*/

		private void CheckNull()
		{
			if (ThrowWhenNull && IsNull)
				throw new NullDateException();
		}

		#region Inherited Members
		//These members would be inherited from DateTime IF IT WASN'T SEALED
		//THANKS ALOT MICROSOFT
		//
		//On second thought, perhaps we need to override most/all of these anyway
		//to control what happens when the date is NULL

		public DateTime Date { get { return _date.Date; } }
		public int Day { get { return _date.Day; } }
		public DayOfWeek DayOfWeek { get { return _date.DayOfWeek; } }
		public int DayOfYear { get { return _date.DayOfYear; } }
		public int Hour { get { return _date.Hour; } }
		public DateTimeKind Kind { get { return _date.Kind; } }
		public int Millisecond { get { return _date.Millisecond; } }
		public int Minute { get { return _date.Minute; } }
		public int Month { get { return _date.Month; } }
		public int Second { get { return _date.Second; } }
		public long Ticks { get { return _date.Ticks; } }
		public TimeSpan TimeOfDay { get { return _date.TimeOfDay; } }
		public int Year { get { return _date.Year; } }

		public string ToShortDateString() { return IsNull ? "" : _date.ToShortDateString(); }
		public string ToShortTimeString() { return IsNull ? "" : _date.ToShortTimeString(); }
		public override string ToString() { return IsNull ? "" : _date.ToString(); }

		public DateTime Add(TimeSpan value) {return _date.Add( value);}
		public DateTime AddDays(double value) { return _date.AddDays(value); }
		public DateTime AddHours(double value) { return _date.AddHours(value); }
		public DateTime AddMilliseconds(double value) { return _date.AddMilliseconds(value); }
		public DateTime AddMinutes(double value) { return _date.AddMinutes(value); }
		public DateTime AddMonths(int value) { return _date.AddMonths(value); }
		public DateTime AddSeconds(double value) { return _date.AddSeconds(value); }
		public DateTime AddTicks(long value) { return _date.AddTicks(value); }
		public DateTime AddYears(int value) { return _date.AddYears(value); }
		public int CompareTo(DateTime value) { return _date.CompareTo(value); }
		public bool Equals(DateTime value) { return _date.Equals(value); }
		public override bool Equals(object value) { return _date.Equals(value); }
		public override int GetHashCode() { return _date.GetHashCode(); }

		#endregion

		#region IConvertible Members

		public ulong ToUInt64(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to UInt64");
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to SByte");
		}

		public double ToDouble(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Double");
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			return _date;
		}

		public float ToSingle(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Single");
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Boolean");
		}

		public int ToInt32(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Int32");
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to UInt16");
		}

		public short ToInt16(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Int16");
		}

		string System.IConvertible.ToString(IFormatProvider provider)
		{
			return ToString();
		}

		public byte ToByte(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Byte");
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Char");
		}

		public long ToInt64(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Int64");
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.DateTime;
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to Decimal");
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(_date, conversionType);
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			throw new InvalidCastException("SmartDate cannot be converted to UInt32");
		}

		#endregion
	}

	[Serializable]
	public class NullDateException : Exception
	{
		public NullDateException()
			: base("An invalid attempt was made to retrieve a NULL date value.")
		{
		}

		public NullDateException(string message)
			: base(message)
		{
		}

		public NullDateException(string message, Exception inner)
			: base(message, inner)
		{
		}

		// This constructor is needed for serialization.
		protected NullDateException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter)]
	public class ThrowExceptionOnNullAttribute : Attribute
	{
		private bool _throwOnNull;

		public ThrowExceptionOnNullAttribute()
		{
			_throwOnNull = true;
		}

		public ThrowExceptionOnNullAttribute(bool throwOnNull)
		{
			_throwOnNull = throwOnNull;
		}

		public bool ThrowOnNull
		{
			get { return _throwOnNull; }
			set { _throwOnNull = value; }
		}
	}
}
