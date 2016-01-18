using System;
using System.Data;
using System.Diagnostics;

namespace Bahns.Data
{
	/// <summary>
	/// This is a DataReader that 'fixes' any null values before
	/// they are returned to our business code.
	/// </summary>
	public class SafeDataReader : IDataReader
	{
		#region Private Data
		private IDataReader _dataReader;
		private int _currentColumn = 0;
		private bool _autoTrim = true;
		#endregion

		#region Current Column
		public int CurrentColumn
		{
			get {return _currentColumn;}
		}

		public void SetCurrentColumn(int i)
		{
			_currentColumn = i;
		}

		public void SetCurrentColumn(string Name)
		{
			_currentColumn = this.GetOrdinal(Name);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Get a reference to the underlying data reader
		/// object that actually contains the data from
		/// the data source.
		/// </summary>
		protected IDataReader DataReader
		{
			get { return _dataReader; }
		}

		/// <summary>
		/// Returns the depth property value from the datareader.
		/// </summary>
		public int Depth
		{
			get
			{
				return _dataReader.Depth;
			}
		}

		/// <summary>
		/// Returns the FieldCount property from the datareader.
		/// </summary>
		public int FieldCount
		{
			get
			{
				return _dataReader.FieldCount;
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes the SafeDataReader object to use data from
		/// the provided DataReader object.
		/// </summary>
		/// <param name="dataReader">The source DataReader object containing the data.</param>
		public SafeDataReader(IDataReader dataReader)
		{
			_dataReader = dataReader;
		}
		#endregion

		#region Other Methods
		/// <summary>
		/// Reads the next row of data from the datareader.  Resets the built-in column 
		/// indexer to zero.
		/// </summary>
		public bool Read()
		{
			_currentColumn = 0;
			return _dataReader.Read();
		}

		/// <summary>
		/// Moves to the next result set in the datareader.
		/// </summary>
		public bool NextResult()
		{
			return _dataReader.NextResult();
		}

		/// <summary>
		/// Closes the datareader.
		/// </summary>
		public void Close()
		{
			_dataReader.Close();
		}
		#endregion

		#region Field Info
		#region GetDataTypeName
		
		/// <summary>
		/// Gets the name of the source data type. 
		/// </summary>
		/// <param name="name">Name of the column containing the value.</param>
		/// <remarks>Invokes the GetDataTypeName method of the underlying datareader.</remarks>
		public string GetDataTypeName(string name)
		{
			return GetDataTypeName(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets the name of the source data type. 
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		/// <remarks>Invokes the GetDataTypeName method of the underlying datareader.</remarks>
		public virtual string GetDataTypeName(int i)
		{
			return _dataReader.GetDataTypeName(i);
		}
		#endregion

		#region GetFieldType
		/// <summary>
		/// Gets the Type that is the data type of the object. 
		/// </summary>
		/// <param name="name">Name of the column containing the value.</param>
		/// <remarks>Invokes the GetFieldType method of the underlying datareader.</remarks>
		public Type GetFieldType(string name)
		{
			return GetFieldType(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets the Type that is the data type of the object. 
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		/// <remarks>Invokes the GetFieldType method of the underlying datareader.</remarks>
		public virtual Type GetFieldType(int i)
		{
			return _dataReader.GetFieldType(i);
		}
		#endregion
		#endregion

		#region Field Access

		#region GetBoolean
		/// <summary>
		/// Gets a boolean value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns <see langword="false" /> for null.
		/// </remarks>
		public bool GetBoolean()
		{
			return GetBoolean(_currentColumn);
		}

		/// <summary>
		/// Gets a boolean value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns <see langword="false" /> for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public bool GetBoolean(string name)
		{
			return GetBoolean(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a boolean value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns <see langword="false" /> for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual bool GetBoolean(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return false;
			else
				return _dataReader.GetBoolean(i);
		}
		#endregion

		#region GetAsBoolean
		/// <summary>
		/// Gets the value as a boolean for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns <see langword="false" /> for null.
		/// </remarks>
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		//[DebuggerHidden]
		public bool GetAsBoolean()
		{
			return GetAsBoolean(_currentColumn);
		}

		/// <summary>
		/// Gets the value as a boolean from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns <see langword="false" /> for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public bool GetAsBoolean(string name)
		{
			return GetAsBoolean(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets the value as a boolean from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns <see langword="false" /> for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual bool GetAsBoolean(int i)
		{
			//_currentColumn = i + 1; //GetValue does this
			//Type type = GetFieldType(i);
			object value = GetValue(i);

			if (value is bool)
			{
				return (bool)value;
			}

			if (value is Int16 || value is Int32 || value is Int64)
			{
				return Convert.ToInt64(value) != 0;
			}
			
			if (value is string)
			{
				string s = (string)value;
				return s == "Y" || s == "T";
			}

			//It shouldn't get here.  Since we already established above that the field is 
			//not a bool, calling GetBoolean should throw an exception, and that's what we 
			//want.
			return GetBoolean(i);
		}
		#endregion

		#region GetByte
		/// <summary>
		/// Gets a byte value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public byte GetByte()
		{
			return GetByte(_currentColumn);
		}

		/// <summary>
		/// Gets a byte value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public byte GetByte(string name)
		{
			return GetByte(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a byte value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual byte GetByte(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetByte(i);
		}
		#endregion

		#region GetBytes
		/// <summary>
		/// Invokes the GetBytes method for the next column of the underlying datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="buffer">Array containing the data.</param>
		/// <param name="bufferOffset">Offset position within the buffer.</param>
		/// <param name="fieldOffset">Offset position within the field.</param>
		/// <param name="length">Length of data to read.</param>
		public Int64 GetBytes(Int64 fieldoffset,
		  byte[] buffer, int bufferoffset, int length)
		{
			return GetBytes(_currentColumn, fieldoffset, buffer, bufferoffset, length);
		}

		/// <summary>
		/// Invokes the GetBytes method of the underlying datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		/// <param name="buffer">Array containing the data.</param>
		/// <param name="bufferOffset">Offset position within the buffer.</param>
		/// <param name="fieldOffset">Offset position within the field.</param>
		/// <param name="length">Length of data to read.</param>
		public Int64 GetBytes(string name, Int64 fieldoffset,
		  byte[] buffer, int bufferoffset, int length)
		{
			return GetBytes(_dataReader.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
		}

		/// <summary>
		/// Invokes the GetBytes method of the underlying datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		/// <param name="buffer">Array containing the data.</param>
		/// <param name="bufferOffset">Offset position within the buffer.</param>
		/// <param name="fieldOffset">Offset position within the field.</param>
		/// <param name="length">Length of data to read.</param>
		public virtual Int64 GetBytes(int i, Int64 fieldOffset,
		  byte[] buffer, int bufferoffset, int length)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
		}
		#endregion

		#region GetChar
		/// <summary>
		/// Gets a char value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns Char.MinValue for null.
		/// </remarks>
		public char GetChar()
		{
			return GetChar(_currentColumn);
		}

		/// <summary>
		/// Gets a char value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns Char.MinValue for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public char GetChar(string name)
		{
			return GetChar(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a char value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns Char.MinValue for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual char GetChar(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return char.MinValue;
			else
			{
				char[] myChar = new char[1];
				_dataReader.GetChars(i, 0, myChar, 0, 1);
				return myChar[0];
			}
		}
		#endregion

		#region GetChars
		/// <summary>
		/// Invokes the GetChars method for the next column of the underlying datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="buffer">Array containing the data.</param>
		/// <param name="bufferOffset">Offset position within the buffer.</param>
		/// <param name="fieldOffset">Offset position within the field.</param>
		/// <param name="length">Length of data to read.</param>
		public Int64 GetChars(Int64 fieldOffset,
		  char[] buffer, int bufferOffset, int length)
		{
			return GetChars(_currentColumn, fieldOffset, buffer, bufferOffset, length);
		}

		/// <summary>
		/// Invokes the GetChars method of the underlying datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		/// <param name="buffer">Array containing the data.</param>
		/// <param name="bufferOffset">Offset position within the buffer.</param>
		/// <param name="fieldOffset">Offset position within the field.</param>
		/// <param name="length">Length of data to read.</param>
		public Int64 GetChars(string name, Int64 fieldOffset,
		  char[] buffer, int bufferOffset, int length)
		{
			return GetChars(_dataReader.GetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
		}

		/// <summary>
		/// Invokes the GetChars method of the underlying datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		/// <param name="buffer">Array containing the data.</param>
		/// <param name="bufferOffset">Offset position within the buffer.</param>
		/// <param name="fieldOffset">Offset position within the field.</param>
		/// <param name="length">Length of data to read.</param>
		public virtual Int64 GetChars(int i, Int64 fieldoffset,
		  char[] buffer, int bufferoffset, int length)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
		}
		#endregion

		#region GetData
		/// <summary>
		/// Invokes the GetData method for the next column of the underlying datareader.
		/// </summary>
		public IDataReader GetData()
		{
			return GetData(_currentColumn);
		}

		/// <summary>
		/// Invokes the GetData method of the underlying datareader.
		/// </summary>
		/// <param name="name">Name of the column containing the value.</param>
		public IDataReader GetData(string name)
		{
			return GetData(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Invokes the GetData method of the underlying datareader.
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual IDataReader GetData(int i)
		{
			_currentColumn = i + 1;
			return _dataReader.GetData(i);
		}
		#endregion

		#region GetDateTime
		/// <summary>
		/// Gets a date value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns DateTime.MinValue for null.
		/// </remarks>
		public virtual DateTime GetDateTime()
		{
			return GetDateTime(_currentColumn);
		}

		/// <summary>
		/// Gets a date value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns DateTime.MinValue for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public virtual DateTime GetDateTime(string name)
		{
			return GetDateTime(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a date value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns DateTime.MinValue for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual DateTime GetDateTime(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return DateTime.MinValue;
			else
				return _dataReader.GetDateTime(i);
		}
		#endregion

		#region GetDecimal
		/// <summary>
		/// Gets a decimal value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public decimal GetDecimal()
		{
			return GetDecimal(_currentColumn);
		}

		/// <summary>
		/// Gets a decimal value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public decimal GetDecimal(string name)
		{
			return GetDecimal(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a decimal value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual decimal GetDecimal(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetDecimal(i);
		}
		#endregion

		#region GetDouble
		/// <summary>
		/// Gets a double for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public double GetDouble()
		{
			return GetDouble(_currentColumn);
		}

		/// <summary>
		/// Gets a double from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public double GetDouble(string name)
		{
			return GetDouble(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a double from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual double GetDouble(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetDouble(i);
		}
		#endregion

		#region GetEnum
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification="Explicit type specification is preferable to requiring a defaultValue argument")]
		public T GetEnum<T>()
		{
			return GetEnum<T>(_currentColumn);
		}

		//public generic methods that don't provide a type paremeter
		//violates rules CA1004.  Unfortunately adding a defaultValue
		//argument causes the GenEnum method to be different from the
		//Get methods for all other types.  For now I have decided that
		//it is more desirable to be consistent with the other methods,
		//so I have kept the defaultValue variations private and
		//supressed the CA1004 warning.
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification="Explicit type specification is preferable to requiring a defaultValue argument")]
		public T GetEnum<T>(string name)
		{
			return GetEnum<T>(_dataReader.GetOrdinal(name));
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification="Explicit type specification is preferable to requiring a defaultValue argument")]
		public T GetEnum<T>(int i)
		{
			return GetEnum(i, default(T));
		}

		/*private T GetEnum<T>(string name, T defaultValue)
		{
			return GetEnum<T>(_dataReader.GetOrdinal(name), defaultValue);
		}*/

		private T GetEnum<T>(int i, T defaultValue)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return defaultValue;
			else
				return (T)Enum.Parse(typeof(T), _dataReader.GetString(i));
		}
		#endregion

		#region GetFloat
		/// <summary>
		/// Gets a Single value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public float GetFloat()
		{
			return GetFloat(_currentColumn);
		}

		/// <summary>
		/// Gets a Single value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public float GetFloat(string name)
		{
			return GetFloat(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a Single value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual float GetFloat(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetFloat(i);
		}
		#endregion

		#region GetGuid
		/// <summary>
		/// Gets a Guid value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns Guid.Empty for null.
		/// </remarks>
		public System.Guid GetGuid()
		{
			return GetGuid(_currentColumn);
		}

		/// <summary>
		/// Gets a Guid value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns Guid.Empty for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public System.Guid GetGuid(string name)
		{
			return GetGuid(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a Guid value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns Guid.Empty for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual System.Guid GetGuid(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return Guid.Empty;
			else
				return _dataReader.GetGuid(i);
		}
		#endregion

		#region GetInt16
		/// <summary>
		/// Gets a Short value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public short GetInt16()
		{
			return GetInt16(_currentColumn);
		}

		/// <summary>
		/// Gets a Short value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public short GetInt16(string name)
		{
			return GetInt16(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a Short value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual short GetInt16(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetInt16(i);
		}
		#endregion

		#region GetInt32
		/// <summary>
		/// Gets the integer value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public int GetInt32()
		{
			return GetInt32(_currentColumn);
		}

		/// <summary>
		/// Gets an integer from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public int GetInt32(string name)
		{
			return GetInt32(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets an integer from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual int GetInt32(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetInt32(i);
		}
		#endregion

		#region GetInt64
		/// <summary>
		/// Gets a Long value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		public Int64 GetInt64()
		{
			return GetInt64(_currentColumn);
		}

		/// <summary>
		/// Gets a Long value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public Int64 GetInt64(string name)
		{
			return GetInt64(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a Long value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns 0 for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual Int64 GetInt64(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return 0;
			else
				return _dataReader.GetInt64(i);
		}
		#endregion

		#region GetString
		/// <summary>
		/// Gets the string value for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns empty string for null.
		/// </remarks>
		public string GetString()
		{
			return GetString(_currentColumn);
		}

		/// <summary>
		/// Gets a string value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns empty string for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public string GetString(string name)
		{
			return GetString(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a string value from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns empty string for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual string GetString(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return string.Empty;
			else
				return _autoTrim ? _dataReader.GetString(i).Trim() : _dataReader.GetString(i);
		}
		#endregion

		#region GetAsString
		/// <summary>
		/// Gets the value as a string for the next column from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns empty string for null.
		/// </remarks>
		//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		//[DebuggerHidden]
		public string GetAsString()
		{
			return GetAsString(_currentColumn);
		}

		/// <summary>
		/// Gets the value as a string  from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns empty string for null.
		/// </remarks>
		/// <param name="name">Name of the column containing the value.</param>
		public string GetAsString(string name)
		{
			return GetAsString(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets the value as a string from the datareader.
		/// </summary>
		/// <remarks>
		/// Returns empty string for null.
		/// </remarks>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual string GetAsString(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return string.Empty;
			else
				return _autoTrim ? _dataReader.GetValue(i).ToString().Trim() : _dataReader.GetValue(i).ToString();
		}
		#endregion

		#region GetValue
		/// <summary>
		/// Gets the value of type <see cref="System.Object" /> for the next column from the datareader.
		/// </summary>
		public object GetValue()
		{
			return GetValue(_currentColumn);
		}

		/// <summary>
		/// Gets a value of type <see cref="System.Object" /> from the datareader.
		/// </summary>
		/// <param name="name">Name of the column containing the value.</param>
		public object GetValue(string name)
		{
			return GetValue(_dataReader.GetOrdinal(name));
		}

		/// <summary>
		/// Gets a value of type <see cref="System.Object" /> from the datareader.
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual object GetValue(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
				return null;
			else
				return _dataReader.GetValue(i);
		}
		#endregion

		#endregion

		#region Others
		/// <summary>
		/// Invokes the GetName method of the underlying datareader.
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual string GetName(int i)
		{
			return _dataReader.GetName(i);
		}

		/// <summary>
		/// Gets an ordinal value from the datareader.
		/// </summary>
		/// <param name="name">Name of the column containing the value.</param>
		public int GetOrdinal(string name)
		{
			return _dataReader.GetOrdinal(name);
		}

		/// <summary>
		/// Invokes the GetSchemaTable method of the underlying datareader.
		/// </summary>
		public DataTable GetSchemaTable()
		{
			return _dataReader.GetSchemaTable();
		}

		/// <summary>
		/// Invokes the GetValues method of the underlying datareader.
		/// </summary>
		/// <param name="values">An array of System.Object to
		/// copy the values into.</param>
		public int GetValues(object[] values)
		{
			return _dataReader.GetValues(values);
		}

		/// <summary>
		/// Returns the IsClosed property value from the datareader.
		/// </summary>
		public bool IsClosed
		{
			get
			{
				return _dataReader.IsClosed;
			}
		}

		/// <summary>
		/// Invokes the IsDBNull method of the underlying datareader.
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual bool IsDBNull(int i)
		{
			return _dataReader.IsDBNull(i);
		}

		/// <summary>
		/// Returns a value from the datareader.
		/// </summary>
		/// <param name="name">Name of the column containing the value.</param>
		public object this[string name]
		{
			get
			{
				object val = _dataReader[name];
				if (DBNull.Value.Equals(val))
					return null;
				else
					return val;
			}
		}

		/// <summary>
		/// Returns a value from the datareader.
		/// </summary>
		/// <param name="i">Ordinal column position of the value.</param>
		public virtual object this[int i]
		{
			get
			{
				if (_dataReader.IsDBNull(i))
					return null;
				else
					return _dataReader[i];
			}
		}
		/// <summary>
		/// Gets the number of rows changed, inserted, or deleted by execution
		/// of the SQL statement.
		/// </summary>
		public int RecordsAffected
		{
			get
			{
				return _dataReader.RecordsAffected;
			}
		}
		#endregion

		#region IDisposable Support

		private bool _disposedValue; // To detect redundant calls

		/// <summary>
		/// Disposes the object.
		/// </summary>
		/// <param name="disposing">True if called by
		/// the public Dispose method.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					// free unmanaged resources when explicitly called
					_dataReader.Dispose();
				}

				// free shared unmanaged resources
			}
			_disposedValue = true;
		}

		/// <summary>
		/// Disposes the object.
		/// </summary>
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Object finalizer.
		/// </summary>
		~SafeDataReader()
		{
			Dispose(false);
		}
		#endregion

	}
}