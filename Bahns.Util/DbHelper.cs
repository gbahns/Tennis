using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Globalization;
using log4net;

namespace Bahns.Data
{
	public class Param
	{
		#region Private Data Members
		private string name;
		private DbType type;
		//private int size;
		private object value;
		private ParameterDirection direction;
		#endregion

		#region Public Properties
		public string Name
		{
			get { return name; }
		}

		public DbType Type
		{
			get { return type; }
		}

		/*public int Size
		{
			get { return size; }
		}*/

		public object Value
		{
			get { return this.value; }
		}

		public ParameterDirection Direction
		{
			get { return direction; }
		}
		#endregion

		#region Constructors
		private Param(string name, DbType type, object value, ParameterDirection direction)
		{
			this.name = name;
			this.type = type;
			this.value = value;
			this.direction = direction;
		}

		/*private Param(string name, DbType type, int size, object value, ParameterDirection direction)
		{
			this.name = name;
			this.type = type;
			this.size = size;
			this.value = value;
			this.direction = direction;
		}*/
		#endregion

		#region DbNull
		public static Param In(string name, DbType type)
		{
			return new Param(name, type, DBNull.Value, ParameterDirection.Input);
		}
		#endregion

		#region Int32
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Justification = "The type of the parameter is used to overload this method in lieu of using a switch statement.")]
		private static DbType GetDbType(Int32 value) { return DbType.Int32; }
		//private static int GetDbSize(Int32 v) { return sizeof(Int32); }

		public static Param In(string name, Int32 value)
		{
			return new Param(name, GetDbType(value), value, ParameterDirection.Input);
		}

		public static Param Out(string name, Int32 value)
		{
			return new Param(name, GetDbType(value), DBNull.Value, ParameterDirection.Output);
		}

		public static Param ID(string name, int ID, bool IsNew)
		{
			if (IsNew)
			{
				return Param.Out(name, ID);// DBNull.Value;
			}
			else
			{
				return Param.In(name, ID);
			}
		}

		#endregion

		#region Decimal
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Justification = "The type of the parameter is used to overload this method in lieu of using a switch statement.")]
		private static DbType GetDbType(Decimal value) { return DbType.Decimal; }
		//private static int GetDbSize(Int32 v) { return sizeof(Int32); }

		public static Param In(string name, Decimal value)
		{
			return new Param(name, GetDbType(value), value, ParameterDirection.Input);
		}

		public static Param Out(string name, Decimal value)
		{
			return new Param(name, GetDbType(value), DBNull.Value, ParameterDirection.Output);
		}
		#endregion

		#region String
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Justification = "The type of the parameter is used to overload this method in lieu of using a switch statement.")]
		private static DbType GetDbType(String value) { return DbType.String; }

		public static Param In(string name, String value)
		{
			return new Param(name, GetDbType(value), value, ParameterDirection.Input);
		}

		public static Param Out(string name, String value)
		{
			return new Param(name, GetDbType(value), DBNull.Value, ParameterDirection.Output);
		}
		#endregion

		#region DateTime
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Justification = "The type of the parameter is used to overload this method in lieu of using a switch statement.")]
		private static DbType GetDbType(DateTime value) { return DbType.DateTime; }

		public static Param In(string name, DateTime value)
		{
			return new Param(name, GetDbType(value), value, ParameterDirection.Input);
		}

		public static Param Out(string name, DateTime value)
		{
			return new Param(name, GetDbType(value), DBNull.Value, ParameterDirection.Output);
		}
		#endregion

		internal void AddTo(Database db, DbCommand cmd)
		{
			switch (direction)
			{
				case ParameterDirection.Input:
					db.AddInParameter(cmd, name, type, value);
					break;

				case ParameterDirection.Output:
					db.AddOutParameter(cmd, name, type, 0);
					break;
			}
		}
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Db is used as an abbreviation for Database by the .NET Framework")]
	[Serializable]
	public class DbResultsDictionary : Dictionary<string, object>
	{
		internal DbResultsDictionary(DbCommand cmd)
			: base()
		{
			foreach (DbParameter param in cmd.Parameters)
			{
				if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
				{
					base[param.ParameterName] = param.Value;
				}
			}
		}

		protected DbResultsDictionary(System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{
		}
	}

	internal class Base
	{
		private static ILog log = LogManager.GetLogger(typeof(Base).ToString());

		/// <summary>
		/// This helper method will contruct a DbCommand object given the Database object, command text, 
		/// and parameter array.
		/// </summary>
		/// <param name="db">The database object representing the database connection that the command will run in.</param>
		/// <param name="commandTextOrSqlText">The name of the stored procedure or the SQL statement to be executed.</param>
		/// <param name="parameters">An array of parameters to pass to the stored procedure or SQL statement.</param>
		/// <returns>A Db</returns>
		/// <remarks>If the commandText contains a space, it is assumed to be SQL statments; otherwise it
		/// is assumed to be a stored procedure name.</remarks>
		internal static DbCommand BuildCommand(Database db, string commandText, Param[] parameters)
		{
			DbCommand cmd = commandText.Contains(" ")
				? db.GetSqlStringCommand(commandText)
				: db.GetStoredProcCommand(commandText);

			foreach (Param param in parameters)
			{
				param.AddTo(db, cmd);
			}
			return cmd;
		}

		internal static DbCommand BuildCommand(Database db, string commandText, object[] parameters)
		{
			if (commandText.Contains(" "))
				throw new DataException("Parameter discovery only works for stored procedures.");

			return db.GetStoredProcCommand(commandText, parameters);
		}

		/// <summary>
		/// Generates a string representation of the DbCommand object, including the command text and
		/// a string representation of all of the arguments.  This is used for logging.
		/// </summary>
		/// <param name="cmd">The DbCommand object for which to generate a string representation.</param>
		/// <returns></returns>
		internal static string GetCommandString(DbCommand cmd)
		{
			StringBuilder s = new StringBuilder();
			foreach (DbParameter p in cmd.Parameters)
			{
				if (p.Value == null)
					s.Append(p.ParameterName);
				else
					s.Append(p.Value.ToString());
				s.Append("; ");
			}
			return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", cmd.CommandText, s);
		}

		internal static DbResultsDictionary ExecuteNonQuery(Database db, DbCommand cmd, int commandTimeout)
		{
			using (cmd)
			{
				if (commandTimeout >= 0)
					cmd.CommandTimeout = commandTimeout;
				//if (writeLog)
				log.Info("stored proc: " + GetCommandString(cmd));
				db.ExecuteNonQuery(cmd);
				log.Info("stored proc: " + cmd.CommandText + " done.");
				return new DbResultsDictionary(cmd);
			}
		}

		internal static SafeDataReader ExecuteReader(Database db, DbCommand cmd, int commandTimeout)
		{
			using (cmd)
			{
				if (commandTimeout >= 0)
					cmd.CommandTimeout = commandTimeout;
				//if (writeLog)
				log.Info("stored proc: " + GetCommandString(cmd));
				SafeDataReader dr = new SafeDataReader(db.ExecuteReader(cmd));
				log.Info("stored proc: " + cmd.CommandText + " done.");
				return dr;
			}
		}

		internal static object ExecuteScalar(Database db, DbCommand cmd, int commandTimeout)
		{
			using (cmd)
			{
				if (commandTimeout >= 0)
					cmd.CommandTimeout = commandTimeout;
				/*if (writeLog)
					Log.Info("stored proc: " + GetCommandString(cmd));*/
				return db.ExecuteScalar(cmd);
			}
		}
		#region Logging
		static int _loggingEnabled;

		static public bool LoggingEnabled
		{
			get { return _loggingEnabled > 0; }
			set { _loggingEnabled += value ? 1 : -1; }
		}

		public class TempLogging : IDisposable
		{
			TempLogging()
			{
				LoggingEnabled = true;
			}

			public void Dispose()
			{
				LoggingEnabled = false;
			}
		}
		#endregion
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Db is used as an abbreviation for Database by the .NET Framework")]
	public static class DbHelper
	{
		#region ExecuteNonQuery
		private static DbResultsDictionary ExecuteNonQuery(Database db, string commandText, int commandTimeout, params object[] parameters)
		{
			return Base.ExecuteNonQuery(db, Base.BuildCommand(db, commandText, parameters), commandTimeout);
		}

		public static DbResultsDictionary ExecuteNonQuery(string commandText, params object[] parameters)
		{
			return ExecuteNonQuery(DatabaseFactory.CreateDatabase(), commandText, int.MinValue, parameters);
		}

		//public static DbResultsDictionary ExecuteNonQuery(string commandText, int commandTimeout, params object[] parameters)
		//{
		//    return ExecuteNonQuery(DatabaseFactory.CreateDatabase(), commandText, commandTimeout, parameters);
		//}

		//public static DbResultsDictionary ExecuteNonQuery(string dbName, string commandText, params object[] parameters)
		//{
		//    return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbName), commandText, int.MinValue, parameters);
		//}

		//public static DbResultsDictionary ExecuteNonQuery(string dbName, string commandText, int commandTimeout, params object[] parameters)
		//{
		//    return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbName), commandText, commandTimeout, parameters);
		//}
		#endregion

		#region ExecuteReader
		private static SafeDataReader ExecuteReader(Database db, string commandText, int commandTimeout, object[] parameters)
		{
			return Base.ExecuteReader(db, Base.BuildCommand(db, commandText, parameters), commandTimeout);
		}

		public static SafeDataReader ExecuteReader(string commandText, params object[] parameters)
		{
			return ExecuteReader(DatabaseFactory.CreateDatabase(), commandText, int.MinValue, parameters);
		}

		//public static SafeDataReader ExecuteReader(string commandText, int commandTimeout, params object[] parameters)
		//{
		//    return ExecuteReader(DatabaseFactory.CreateDatabase(), commandText, commandTimeout, parameters);
		//}

		//public static SafeDataReader ExecuteReader(string dbName, string commandText, params object[] parameters)
		//{
		//    return ExecuteReader(DatabaseFactory.CreateDatabase(dbName), commandText, int.MinValue, parameters);
		//}

		//public static SafeDataReader ExecuteReader(string dbName, string commandText, int commandTimeout, params object[] parameters)
		//{
		//    return ExecuteReader(DatabaseFactory.CreateDatabase(dbName), commandText, commandTimeout, parameters);
		//}

		/*
						string commandText,						params object[] parameters)
		string dbName,	string commandText,						params object[] parameters)

		 * 
		 * 
		 * 
		 *				string commandText, int commandTimeout, params object[] parameters)
		string dbName,	string commandText, int commandTimeout, params object[] parameters)
		 * */
		#endregion
	}

	namespace Manual
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Db is used as an abbreviation for Database by the .NET Framework")]
		public static class DbHelper
		{

			#region ExecuteNonQuery
			private static DbResultsDictionary ExecuteNonQuery(Database db, string commandText, int commandTimeout, params Param[] parameters)
			{
				return Base.ExecuteNonQuery(db, Base.BuildCommand(db, commandText, parameters), commandTimeout);
			}

			public static DbResultsDictionary ExecuteNonQuery(string commandText, params Param[] parameters)
			{
				return ExecuteNonQuery(DatabaseFactory.CreateDatabase(), commandText, int.MinValue, parameters);
			}

			public static DbResultsDictionary ExecuteNonQuery(string commandText, int commandTimeout, params Param[] parameters)
			{
				return ExecuteNonQuery(DatabaseFactory.CreateDatabase(), commandText, commandTimeout, parameters);
			}

			public static DbResultsDictionary ExecuteNonQuery(string dbName, string commandText, params Param[] parameters)
			{
				return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbName), commandText, int.MinValue, parameters);
			}

			public static DbResultsDictionary ExecuteNonQuery(string dbName, string commandText, int commandTimeout, params Param[] parameters)
			{
				return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbName), commandText, commandTimeout, parameters);
			}
			#endregion

			#region ExecuteReader
			private static SafeDataReader ExecuteReader(Database db, string commandText, int commandTimeout, Param[] parameters)
			{
				return Base.ExecuteReader(db, Base.BuildCommand(db, commandText, parameters), commandTimeout);
			}

			public static SafeDataReader ExecuteReader(string commandText, params Param[] parameters)
			{
				return ExecuteReader(DatabaseFactory.CreateDatabase(), commandText, int.MinValue, parameters);
			}

			public static SafeDataReader ExecuteReader(string commandText, int commandTimeout, params Param[] parameters)
			{
				return ExecuteReader(DatabaseFactory.CreateDatabase(), commandText, commandTimeout, parameters);
			}

			public static SafeDataReader ExecuteReader(string dbName, string commandText, params Param[] parameters)
			{
				return ExecuteReader(DatabaseFactory.CreateDatabase(dbName), commandText, int.MinValue, parameters);
			}

			public static SafeDataReader ExecuteReader(string dbName, string commandText, int commandTimeout, params Param[] parameters)
			{
				return ExecuteReader(DatabaseFactory.CreateDatabase(dbName), commandText, commandTimeout, parameters);
			}
			#endregion

			#region ExecuteScalar
			private static object ExecuteScalar(Database db, string commandText, int commandTimeout, params Param[] parameters)
			{
				return Base.ExecuteScalar(db, Base.BuildCommand(db, commandText, parameters), commandTimeout);
			}

			public static object ExecuteScalar(string commandText, params Param[] parameters)
			{
				return ExecuteScalar(DatabaseFactory.CreateDatabase(), commandText, int.MinValue, parameters);
			}

			public static object ExecuteScalar(string commandText, int commandTimeout, params Param[] parameters)
			{
				return ExecuteScalar(DatabaseFactory.CreateDatabase(), commandText, commandTimeout, parameters);
			}

			public static object ExecuteScalar(string dbName, string commandText, params Param[] parameters)
			{
				return ExecuteScalar(DatabaseFactory.CreateDatabase(dbName), commandText, int.MinValue, parameters);
			}

			public static object ExecuteScalar(string dbName, string commandText, int commandTimeout, params Param[] parameters)
			{
				return ExecuteScalar(DatabaseFactory.CreateDatabase(dbName), commandText, commandTimeout, parameters);
			}
			#endregion

		}
	}

	//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Db is used as an abbreviation for Database by the .NET Framework")]
	//public static class DbHelperSafe
	//{
	//    internal static bool ExecuteNonQuery(Database db, string commandText, bool writeLog, params Param[] parameters)
	//    {
	//        Exception exception;
	//        try
	//        {
	//            DbHelper.ExecuteNonQuery(db, commandText, int.MinValue, writeLog, parameters);
	//            return true;
	//        }
	//        catch (DbException ex)
	//        {
	//            exception = ex;
	//        }
	//        catch (InvalidOperationException ex)
	//        {
	//            //InvalidOperationException sometimes occurs when sql connection times out
	//            exception = ex;
	//        }
	//        //Log.Info("stored proc {0} failed: {1} ", commandText, exception.Message);
	//        return false;
	//    }

	//    internal static IDataReader ExecuteReader(Database db, string commandText, bool writeLog, params Param[] parameters)
	//    {
	//        Exception exception;
	//        try
	//        {
	//            return DbHelper.ExecuteReader(db, commandText, int.MinValue, writeLog, parameters);
	//        }
	//        catch (DbException ex)
	//        {
	//            exception = ex;
	//        }
	//        catch (InvalidOperationException ex)
	//        {
	//            //InvalidOperationException sometimes occurs when sql connection times out
	//            exception = ex;
	//        }
	//        //Log.Info("stored proc {0} failed: {1} ", commandText, exception.Message);
	//        return null;
	//    }

	//    public static bool ExecuteNonQuery(string dbName, string commandText, params Param[] parameters)
	//    {
	//        return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbName), commandText, true, parameters);
	//    }

	//    public static IDataReader ExecuteReader(string dbName, string commandText, params Param[] parameters)
	//    {
	//        return ExecuteReader(DatabaseFactory.CreateDatabase(dbName), commandText, true, parameters);
	//    }

	//    public static bool ExecuteNonQuery(string dbName, string commandText, bool writeLog, params Param[] parameters)
	//    {
	//        return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbName), commandText, writeLog, parameters);
	//    }

	//    public static IDataReader ExecuteReader(string dbName, string commandText, bool writeLog, params Param[] parameters)
	//    {
	//        return ExecuteReader(DatabaseFactory.CreateDatabase(dbName), commandText, writeLog, parameters);
	//    }
	//}
}
