using System;
using System.Data;
using Csla;

namespace Bahns.Data
{
	/// <summary> 
	/// This is a DataReader that 'fixes' any null values before 
	/// they are returned to our business code. 
	/// </summary> 
	public class SafeDataReader : IDataReader
	{
		private IDataReader _dataReader;

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
		/// Initializes the SafeDataReader object to use data from 
		/// the provided DataReader object. 
		/// </summary> 
		/// <param name="dataReader">The source DataReader object containing the data.</param> 
		public SafeDataReader(IDataReader dataReader)
		{
			_dataReader = dataReader;
		}

		/// <summary> 
		/// Gets a string value from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns empty string for null. 
		/// </remarks> 
		public string GetString(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return "";
			}
			else
			{
				return _dataReader.GetString(i);
			}
		}

		/// <summary> 
		/// Gets a string value from the datareader. 
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
		/// Returns "" for null. 
		/// </remarks> 
		public string GetString(string Name)
		{
			return this.GetString(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a value of type <see cref="System.Object" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns Nothing for null. 
		/// </remarks> 
		public object GetValue(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return null;
			}
			else
			{
				return _dataReader.GetValue(i);
			}
		}

		/// <summary> 
		/// Gets a value of type <see cref="System.Object" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns Nothing for null. 
		/// </remarks> 
		public object GetValue()
		{
			return GetValue(_currentColumn);
		}

		/// <summary> 
		/// Gets a value of type <see cref="System.Object" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns Nothing for null. 
		/// </remarks> 
		public object GetValue(string Name)
		{
			return this.GetValue(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets an integer from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns 0 for null. 
		/// </remarks> 
		public int GetInt32(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetInt32(i);
			}
		}

		/// <summary> 
		/// Gets an integer from the datareader. 
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
		public int GetInt32(string Name)
		{
			return this.GetInt32(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a double from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns 0 for null. 
		/// </remarks> 
		public double GetDouble(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetDouble(i);
			}
		}

		/// <summary> 
		/// Gets a double from the datareader. 
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
		public double GetDouble(string Name)
		{
			return this.GetDouble(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a <see cref="T:CSLA.SmartDate" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// A null is converted into either the min or max possible date 
		/// depending on the MinIsEmpty parameter. See Chapter 5 for more 
		/// details on the SmartDate class. 
		/// </remarks> 
		/// <param name="i">The column number within the datareader.</param> 
		/// <param name="MinIsEmpty">A flag indicating whether the min or max value of a data means an empty date.</param> 
		public SmartDate GetSmartDate(int i, bool MinIsEmpty)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return new SmartDate(MinIsEmpty);
			}
			else
			{
				return new SmartDate(_dataReader.GetDateTime(i), MinIsEmpty);
			}
		}

		/// <summary> 
		/// Gets a <see cref="T:CSLA.SmartDate" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// A null is converted into the min possible date 
		/// See Chapter 5 for more details on the SmartDate class. 
		/// </remarks> 
		/// <param name="i">The column number within the datareader.</param> 
		public SmartDate GetSmartDate(int i)
		{
			return GetSmartDate(i, true);
		}

		/// <summary> 
		/// Gets a <see cref="T:CSLA.SmartDate" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// A null is converted into the min possible date 
		/// See Chapter 5 for more details on the SmartDate class. 
		/// </remarks> 
		public SmartDate GetSmartDate()
		{
			return GetSmartDate(_currentColumn);
		}

		/// <summary> 
		/// Gets a <see cref="T:CSLA.SmartDate" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// A null is converted into either the min or max possible date 
		/// depending on the MinIsEmpty parameter. See Chapter 5 for more 
		/// details on the SmartDate class. 
		/// </remarks> 
		/// <param name="MinIsEmpty">A flag indicating whether the min or max value of a data means an empty date.</param> 
		public SmartDate GetSmartDate(bool MinIsEmpty)
		{
			return GetSmartDate(_currentColumn, MinIsEmpty);
		}

		/// <summary> 
		/// Gets a <see cref="T:CSLA.SmartDate" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// A null is converted into min possible date 
		/// See Chapter 5 for more details on the SmartDate class. 
		/// </remarks> 
		public SmartDate GetSmartDate(string Name)
		{
			return this.GetSmartDate(this.GetOrdinal(Name), true);
		}

		/// <summary> 
		/// Gets a <see cref="T:CSLA.SmartDate" /> from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// A null is converted into either the min or max possible date 
		/// depending on the MinIsEmpty parameter. See Chapter 5 for more 
		/// details on the SmartDate class. 
		/// </remarks> 
		/// <param name="MinIsEmpty">A flag indicating whether the min or max value of a data means an empty date.</param> 
		public SmartDate GetSmartDate(string Name, bool MinIsEmpty)
		{
			return this.GetSmartDate(this.GetOrdinal(Name), MinIsEmpty);
		}

		/// <summary> 
		/// Gets a Guid value from the datareader. 
		/// </summary> 
		public Guid GetGuid(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return Guid.Empty;
			}
			else
			{
				return _dataReader.GetGuid(i);
			}
		}

		/// <summary> 
		/// Gets a Guid value from the datareader. 
		/// </summary> 
		public Guid GetGuid()
		{
			return GetGuid(_currentColumn);
		}

		/// <summary> 
		/// Gets a Guid value from the datareader. 
		/// </summary> 
		public Guid GetGuid(string Name)
		{
			_currentColumn = this.GetOrdinal(Name);
			return this.GetGuid(_currentColumn);
		}

		/// <summary> 
		/// Reads the next row of data from the datareader. Resets the built-in column indexer 
		/// to zero. 
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

		/// <summary> 
		/// Returns the depth property value from the datareader. 
		/// </summary> 
		public int Depth
		{
			get { return _dataReader.Depth; }
		}

		/// <summary> 
		/// Calls the Dispose method on the underlying datareader. 
		/// </summary> 
		public void Dispose()
		{
			_dataReader.Dispose();
		}

		/// <summary> 
		/// Returns the FieldCount property from the datareader. 
		/// </summary> 
		public int FieldCount
		{
			get { return _dataReader.FieldCount; }
		}

		/// <summary> 
		/// Gets a boolean value from the datareader. 
		/// </summary> 
		public bool GetBoolean(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return false;
			}
			else
			{
				if (_dataReader.GetValue(i) is string)
				{
					return _dataReader.GetString(i) == "Y";
				}
				return _dataReader.GetBoolean(i);
			}
		}

		/// <summary> 
		/// Gets a boolean value from the datareader. 
		/// </summary> 
		public bool GetBoolean()
		{
			return GetBoolean(_currentColumn);
		}

		/// <summary> 
		/// Gets a boolean value from the datareader. 
		/// </summary> 
		public bool GetBoolean(string Name)
		{
			return GetBoolean(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a boolean value from the datareader. 
		/// </summary> 
		public string GetLookupValue(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return "";
			}
			else
			{
				if (_dataReader.GetValue(i) is string)
					return _dataReader.GetString(i);
				Int32 value = _dataReader.GetInt32(i);
				if (value == -1)
					return "";
				return value.ToString();
			}
		}

		/// <summary> 
		/// Gets a boolean value from the datareader. 
		/// </summary> 
		public string GetLookupValue()
		{
			return GetLookupValue(_currentColumn);
		}

		/// <summary> 
		/// Gets a boolean value from the datareader. 
		/// </summary> 
		public string GetLookupValue(string Name)
		{
			return GetLookupValue(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a byte value from the datareader. 
		/// </summary> 
		public byte GetByte(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetByte(i);
			}
		}

		/// <summary> 
		/// Gets a byte value from the datareader. 
		/// </summary> 
		public byte GetByte()
		{
			return GetByte(_currentColumn);
		}

		/// <summary> 
		/// Gets a byte value from the datareader. 
		/// </summary> 
		public byte GetByte(string Name)
		{
			return this.GetByte(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Invokes the GetBytes method of the underlying datareader. 
		/// </summary> 
		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
			}
		}

		/// <summary> 
		/// Invokes the GetBytes method of the underlying datareader. 
		/// </summary> 
		public long GetBytes(long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return GetBytes(_currentColumn, fieldOffset, buffer, bufferoffset, length);
		}

		/// <summary> 
		/// Invokes the GetBytes method of the underlying datareader. 
		/// </summary> 
		public long GetBytes(string Name, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return this.GetBytes(this.GetOrdinal(Name), fieldOffset, buffer, bufferoffset, length);
		}

		/// <summary> 
		/// Gets a char value from the datareader. 
		/// </summary> 
		public char GetChar(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return char.MinValue;
			}
			else
			{
				return _dataReader.GetChar(i);
			}
		}

		/// <summary> 
		/// Gets a char value from the datareader. 
		/// </summary> 
		public char GetChar()
		{
			return _dataReader.GetChar(_currentColumn);
		}

		/// <summary> 
		/// Gets a char value from the datareader. 
		/// </summary> 
		public char GetChar(string Name)
		{
			return this.GetChar(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Invokes the GetChars method of the underlying datareader. 
		/// </summary> 
		public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
			}
		}

		/// <summary> 
		/// Invokes the GetChars method of the underlying datareader. 
		/// </summary> 
		public long GetChars(long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return GetChars(_currentColumn, fieldoffset, buffer, bufferoffset, length);
		}

		/// <summary> 
		/// Invokes the GetChars method of the underlying datareader. 
		/// </summary> 
		public long GetChars(string Name, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return this.GetChars(this.GetOrdinal(Name), fieldoffset, buffer, bufferoffset, length);
		}

		/// <summary> 
		/// Invokes the GetData method of the underlying datareader. 
		/// </summary> 
		public System.Data.IDataReader GetData(int i)
		{
			_currentColumn = i + 1;
			return _dataReader.GetData(i);
		}

		/// <summary> 
		/// Invokes the GetData method of the underlying datareader. 
		/// </summary> 
		public System.Data.IDataReader GetData()
		{
			return this.GetData(_currentColumn);
		}

		/// <summary> 
		/// Invokes the GetData method of the underlying datareader. 
		/// </summary> 
		public System.Data.IDataReader GetData(string Name)
		{
			return this.GetData(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Invokes the GetDataTypeName method of the underlying datareader. 
		/// </summary> 
		public string GetDataTypeName(int i)
		{
			return _dataReader.GetDataTypeName(i);
		}

		/// <summary> 
		/// Invokes the GetDataTypeName method of the underlying datareader. 
		/// </summary> 
		public string GetDataTypeName(string Name)
		{
			_currentColumn = this.GetOrdinal(Name);
			return this.GetDataTypeName(_currentColumn);
		}

		/// <summary> 
		/// Gets a date value from the datareader. 
		/// </summary> 
		public System.DateTime GetDateTime(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return System.DateTime.MinValue;
			}
			else
			{
				return _dataReader.GetDateTime(i);
			}
		}

		/// <summary> 
		/// Invokes the GetData method of the underlying datareader. 
		/// </summary> 
		public System.DateTime GetDateTime()
		{
			return GetDateTime(_currentColumn);
		}

		/// <summary> 
		/// Gets a date value from the datareader. 
		/// </summary> 
		public System.DateTime GetDateTime(string Name)
		{
			return this.GetDateTime(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a decimal value from the datareader. 
		/// </summary> 
		public decimal GetDecimal(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetDecimal(i);
			}
		}

		/// <summary> 
		/// Gets a decimal value from the datareader. 
		/// </summary> 
		public decimal GetDecimal()
		{
			return this.GetDecimal(_currentColumn);
		}

		/// <summary> 
		/// Gets a decimal value from the datareader. 
		/// </summary> 
		public decimal GetDecimal(string Name)
		{
			return this.GetDecimal(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Invokes the GetFieldType method of the underlying datareader. 
		/// </summary> 
		public System.Type GetFieldType(int i)
		{
			return _dataReader.GetFieldType(i);
		}

		/// <summary> 
		/// Invokes the GetFieldType method of the underlying datareader. 
		/// </summary> 
		public System.Type GetFieldType(string Name)
		{
			_currentColumn = this.GetOrdinal(Name);
			return this.GetFieldType(_currentColumn);
		}

		/// <summary> 
		/// Gets a Single value from the datareader. 
		/// </summary> 
		public float GetFloat(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetFloat(i);
			}
		}

		/// <summary> 
		/// Gets a Single value from the datareader. 
		/// </summary> 
		public float GetFloat()
		{
			return this.GetFloat(_currentColumn);
		}

		/// <summary> 
		/// Gets a Single value from the datareader. 
		/// </summary> 
		public float GetFloat(string Name)
		{
			return this.GetFloat(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a Short value from the datareader. 
		/// </summary> 
		public short GetInt16(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetInt16(i);
			}
		}

		/// <summary> 
		/// Gets a Short value from the datareader. 
		/// </summary> 
		public short GetInt16()
		{
			return this.GetInt16(_currentColumn);
		}

		/// <summary> 
		/// Gets a Short value from the datareader. 
		/// </summary> 
		public short GetInt16(string Name)
		{
			return this.GetInt16(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Gets a Long value from the datareader. 
		/// </summary> 
		public long GetInt64(int i)
		{
			_currentColumn = i + 1;
			if (_dataReader.IsDBNull(i))
			{
				return 0;
			}
			else
			{
				return _dataReader.GetInt64(i);
			}
		}

		/// <summary> 
		/// Gets a Long value from the datareader. 
		/// </summary> 
		public long GetInt64()
		{
			return this.GetInt64(_currentColumn);
		}

		/// <summary> 
		/// Gets a Long value from the datareader. 
		/// </summary> 
		public long GetInt64(string Name)
		{
			return this.GetInt64(this.GetOrdinal(Name));
		}

		/// <summary> 
		/// Invokes the GetName method of the underlying datareader. 
		/// </summary> 
		public string GetName(int i)
		{
			return _dataReader.GetName(i);
		}

		/// <summary> 
		/// Gets an ordinal value from the datareader. 
		/// </summary> 
		public int GetOrdinal(string name)
		{
			return _dataReader.GetOrdinal(name);
		}

		/// <summary> 
		/// Invokes the GetSchemaTable method of the underlying datareader. 
		/// </summary> 
		public System.Data.DataTable GetSchemaTable()
		{
			return _dataReader.GetSchemaTable();
		}

		/// <summary> 
		/// Invokes the GetValues method of the underlying datareader. 
		/// </summary> 
		public int GetValues(object[] values)
		{
			return _dataReader.GetValues(values);
		}

		/// <summary> 
		/// Returns the IsClosed property value from the datareader. 
		/// </summary> 
		public bool IsClosed
		{
			get { return _dataReader.IsClosed; }
		}

		/// <summary> 
		/// Invokes the IsDBNull method of the underlying datareader. 
		/// </summary> 
		public bool IsDBNull(int i)
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
		/// Invokes the IsDBNull method of the underlying datareader. 
		/// </summary> 
		public bool IsDBNull(string Name)
		{
			_currentColumn = this.GetOrdinal(Name);
			return this.IsDBNull(_currentColumn);
		}

		/*/// <summary> 
		/// Returns a value from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns Nothing if the value is null. 
		/// </remarks> 
		public object Item
		{
			get
			{
				object value = _dataReader.Item(name);
				if (DBNull.Value.Equals(value))
				{
					return null;
				}
				else
				{
					return value;
				}
			}
		}

		/// <summary> 
		/// Returns a value from the datareader. 
		/// </summary> 
		/// <remarks> 
		/// Returns Nothing if the value is null. 
		/// </remarks> 
		public object Item
		{
			get
			{
				if (_dataReader.IsDBNull(i))
				{
					return null;
				}
				else
				{
					return _dataReader.Item(i);
				}
			}
		}*/

		/// <summary> 
		/// Returns the RecordsAffected property value from the underlying datareader. 
		/// </summary> 
		public int RecordsAffected
		{
			get { return _dataReader.RecordsAffected; }
		}

		#region Bahns Extensions
		private int _currentColumn = 0;
		private DataTable _schemaTable = null;

		public int CurrentColumn
		{
			get { return _currentColumn; }
		}

		public void SetCurrentColumn(int i)
		{
			_currentColumn = i;
		}

		public void SetCurrentColumn(string Name)
		{
			_currentColumn = this.GetOrdinal(Name);
		}

		private DataTable SchemaTable
		{
			get
			{
				if (_schemaTable == null)
				{
					_schemaTable = this.GetSchemaTable();
				}
				return _schemaTable;
			}
		}

		public int GetMaxLength(int i)
		{
			_currentColumn = i + 1;
			return (int)SchemaTable.Rows[i]["ColumnSize"];
		}

		public int GetMaxLength()
		{
			return this.GetMaxLength(_currentColumn);
		}

		public int GetMaxLength(string Name)
		{
			return this.GetMaxLength(this.GetOrdinal(Name));
		}
		#endregion

	}

}
