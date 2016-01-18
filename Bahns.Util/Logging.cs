using System;
using System.Collections.Generic;
using System.Text;
using Sfg.Framework.Logging;
using System.Globalization;
using System.Diagnostics;
using Sfg.Framework.Logging.Configuration;

namespace Bahns.Logging
{
	#region EventId
	/// <summary>
	/// This enumeration defines the event id values that are valid for
	/// your specific application.  Below is an example used by SfgAsync.
	/// Place this enum outside your Log class so you don't need to type
	/// the class name each time.
	/// </summary>
	//public enum EventId
	//{
	//    Default = 39000,
	//    Configuration = 39001,
	//    Startup = 39002,
	//    Shutdown = 39003,
	//    Recovery = 39004,
	//    Processing = 39005,
	//    Retry = 39006,
	//    Failure = 39007
	//}
	#endregion

	public class Categories
	{
		public string Error = "Error";
		public string Warning = "Warning";
		public string Info = "Info";
		public string Instrumentation = "Instrumentation";
		public Categories() { }
		public Categories(string error, string warning, string info, string instrumentation)
		{
			Error = error;
			Warning = warning;
			Info = info;
			Instrumentation = instrumentation;
		}
		public void AddPrefix(string prefix)
		{
			Error = prefix + "." + Error;
			Warning = prefix + "." + Warning;
			Info = prefix + "." + Info;
			Instrumentation = prefix + "." + Instrumentation;
		}
	}

	[Obsolete("The Logger class was created as a way to use different configuration settings; use [Assembly: SfgLoggingComponent(\"...\")] instead.")]
	public class Logger
	{
		private int _defaultEventId = 0;
		private string _specificConfig;
		private Categories _categories = new Categories();

		#region Constructors
		/*public Log(int defaultEventId, string specificConfig, Categories categories) : this(
		{
			_defaultEventId = defaultEventId;
			_specificConfig = specificConfig;
			_categories = categories;
		}*/

		public Logger(int defaultEventId, string specificConfig)
		{
			_defaultEventId = defaultEventId;
			_specificConfig = specificConfig;
			if (string.IsNullOrEmpty(_specificConfig))
				_specificConfig = SfgLogger.GetDefaultLoggingSettings().Name;
			if (!string.IsNullOrEmpty(_specificConfig))
				_categories.AddPrefix(_specificConfig);
		}

		public Logger(int defaultEventId) : this(defaultEventId, null) { }
		public Logger(string specificConfig) : this(0, specificConfig) { }
		public Logger() : this(0, null) { }
		#endregion

		#region Categories
		public Categories Categories
		{
			get { return _categories; }
		}
		#endregion

		#region Constants
		/// <summary>
		/// Not currently using this for SfgAsync; I had the idea that it might be
		/// useful to use tracers around startup, shutdown, processing, maybe 
		/// abandoned request recovery... but for now I'm not sure how useful that
		/// would be.
		/// </summary>
		//private static class LoggingOperation
		//{
		//    const string Startup = "Startup";
		//    const string ProcessingRequest = "Processing Request";
		//}

		#endregion

		#region Helpers
		private static string Format(string format, params object[] args)
		{
			return Log.Format(format, args);
		}
		#endregion

		#region Methods that use EventId.Default
		/// <summary>
		/// Logs an error message.  This should be used for events that should always
		/// be logged.  Typically, this is for errors that are preventing the system
		/// from working, or for unexpected errors whose impact is unknown.  The latter
		/// type should typically be investigated to see if they can be caught appropriately
		/// and recovered from, in which case they should be logged as warnings instead.
		/// </summary>
		public void Error(string format, params object[] args)
		{
			Error(_defaultEventId, format, args);
		}

		/// <summary>
		/// Logs a warning message.  This should be used for events the application is
		/// able to recover from, but that may indicate a problem that should be addressed.
		/// If warning messages are researched and determined to not be a problem for the
		/// application, then they should be loagged as Info (or perhaps Trace) instead.
		/// </summary>
		public void Warning(string format, params object[] args)
		{
			Warning(_defaultEventId, format, args);
		}

		/// <summary>
		/// Logs an informational message.  Use this for messages that represent important
		/// events in the execution of the application.  During normal application operation,
		/// Info messages (and higher) should be kept to a minimum; they should be used only
		/// for important events in the applications lifecycle, such as startup and shutdown,
		/// and perhaps occasional messages that indicate the health of the system and/or what
		/// it is doing at a macro-scale.
		/// </summary>
		public void Info(string format, params object[] args)
		{
			Info(_defaultEventId, format, args);
		}

		/// <summary>
		/// Logs a trace message.  Use this for messages that may be useful at times
		/// in diagnosing certain issues, but that may be too detailed or too numerous
		/// to be appropriate for everyday inclusion in the logs.  An application should log a 
		/// sufficient amount trace messages in order to make it possible for development and 
		/// support personnel to troubleshoot production issues as they arise.  These messages 
		/// should not be overly numerous and should not occur in code that is repeated often 
		/// (e.g. inside a loop).
		/// </summary>
		public void Trace(string format, params object[] args)
		{
			Trace(_defaultEventId, format, args);
		}

		/// <summary>
		/// Logs a debug message.  Use this for messages that would truly be information-
		/// overload in most situations, but that might come in handy when troubleshooting
		/// unexpected issues as they arise.
		/// </summary>
		public void Debug(string format, params object[] args)
		{
			Debug(_defaultEventId, format, args);
		}

		public void Exception(Exception ex)
		{
			Exception(_defaultEventId, ex);
		}
		#endregion

		#region Methods where the event ID is specified
		/// <summary>
		/// Logs an error message.  This should be used for events that should always
		/// be logged.  Typically, this is for errors that are preventing the system
		/// from working, or for unexpected errors whose impact is unknown.  The latter
		/// type should typically be investigated to see if they can be caught appropriately
		/// and recovered from, in which case they should be logged as warnings instead.
		/// </summary>
		public void Error(int eventId, string format, params object[] args)
		{
			SfgLogger.WriteSpecificConfig(_specificConfig, Format(format, args), Categories.Error, (int)eventId, PriorityLevel.Error, TraceEventType.Error);
		}

		/// <summary>
		/// Logs a warning message.  This should be used for events the application is
		/// able to recover from, but that may indicate a problem that should be addressed.
		/// If warning messages are researched and determined to not be a problem for the
		/// application, then they should be loagged as Info (or perhaps Trace) instead.
		/// </summary>
		public void Warning(int eventId, string format, params object[] args)
		{
			SfgLogger.WriteSpecificConfig(_specificConfig, Format(format, args), Categories.Info, (int)eventId, PriorityLevel.Warning, TraceEventType.Warning);
		}

		/// <summary>
		/// Logs an informational message.  Use this for messages that represent important
		/// events in the execution of the application.  During normal application operation,
		/// Info messages (and higher) should be kept to a minimum; they should be used only
		/// for important events in the applications lifecycle, such as startup and shutdown,
		/// and perhaps occasional messages that indicate the health of the system and/or what
		/// it is doing at a macro-scale.
		/// </summary>
		public void Info(int eventId, string format, params object[] args)
		{
			SfgLogger.WriteSpecificConfig(_specificConfig, Format(format, args), Categories.Info, (int)eventId, PriorityLevel.Info, TraceEventType.Information);
		}

		/// <summary>
		/// Logs a trace message.  Use this for messages that may be useful at times
		/// in diagnosing certain issues, but that may be too detailed or too numerous
		/// to be appropriate for everyday inclusion in the logs.  An application should log a 
		/// sufficient amount trace messages in order to make it possible for development and 
		/// support personnel to troubleshoot production issues as they arise.  These messages 
		/// should not be overly numerous and should not occur in code that is repeated often 
		/// (e.g. inside a loop).
		/// </summary>
		public void Trace(int eventId, string format, params object[] args)
		{
			SfgLogger.WriteSpecificConfig(_specificConfig, Format(format, args), Categories.Info, (int)eventId, PriorityLevel.Verbose, TraceEventType.Verbose);
		}

		/// <summary>
		/// Logs a debug message.  Use this for messages that would truly be information-
		/// overload in most situations, but that might come in handy when troubleshooting
		/// unexpected issues as they arise.
		/// </summary>
		public void Debug(int eventId, string format, params object[] args)
		{
			SfgLogger.WriteSpecificConfig(_specificConfig, Format(format, args), Categories.Info, (int)eventId, PriorityLevel.Testing, TraceEventType.Verbose);
		}

		public void Exception(int eventId, Exception ex)
		{
			SfgLogger.WriteExceptionSpecificConfig(_specificConfig, ex, (int)eventId);
		}
		#endregion

	}

	public static class Log
	{
		#region Categories
		private static Categories _categories = new Categories();
		public static Categories Categories
		{
			get { return _categories; }
		}
		#endregion

		#region Helpers
		internal static string Format(string format, params object[] args)
		{
			try
			{
				return string.Format(CultureInfo.InvariantCulture, format, args);
			}
			catch (FormatException ex)
			{
				Warning("format exception: " + ex.ToString());
				return format;
			}
		}
		#endregion

		#region Static Interface
		#region Methods that use EventId.Default
		public static ApplicationLoggingSettingsData Defaults = SfgLogger.GetDefaultLoggingSettings();

		/// <summary>
		/// Logs an error message.  This should be used for events that should always
		/// be logged.  Typically, this is for errors that are preventing the system
		/// from working, or for unexpected errors whose impact is unknown.  The latter
		/// type should typically be investigated to see if they can be caught appropriately
		/// and recovered from, in which case they should be logged as warnings instead.
		/// </summary>
		public static void Error(string format, params object[] args)
		{
			Error(Defaults.DefaultEventId, format, args);
		}

		/// <summary>
		/// Logs a warning message.  This should be used for events the application is
		/// able to recover from, but that may indicate a problem that should be addressed.
		/// If warning messages are researched and determined to not be a problem for the
		/// application, then they should be loagged as Info (or perhaps Trace) instead.
		/// </summary>
		public static void Warning(string format, params object[] args)
		{
			Warning(Defaults.DefaultEventId, format, args);
		}

		/// <summary>
		/// Logs an informational message.  Use this for messages that represent important
		/// events in the execution of the application.  During normal application operation,
		/// Info messages (and higher) should be kept to a minimum; they should be used only
		/// for important events in the applications lifecycle, such as startup and shutdown,
		/// and perhaps occasional messages that indicate the health of the system and/or what
		/// it is doing at a macro-scale.
		/// </summary>
		public static void Info(string format, params object[] args)
		{
			Info(Defaults.DefaultEventId, format, args);
		}

		/// <summary>
		/// Logs a trace message.  Use this for messages that may be useful at times
		/// in diagnosing certain issues, but that may be too detailed or too numerous
		/// to be appropriate for everyday inclusion in the logs.  An application should log a 
		/// sufficient amount trace messages in order to make it possible for development and 
		/// support personnel to troubleshoot production issues as they arise.  These messages 
		/// should not be overly numerous and should not occur in code that is repeated often 
		/// (e.g. inside a loop).
		/// </summary>
		public static void Trace(string format, params object[] args)
		{
			Trace(Defaults.DefaultEventId, format, args);
		}

		/// <summary>
		/// Logs a debug message.  Use this for messages that would truly be information-
		/// overload in most situations, but that might come in handy when troubleshooting
		/// unexpected issues as they arise.
		/// </summary>
		public static void Debug(string format, params object[] args)
		{
			Debug(Defaults.DefaultEventId, format, args);
		}

		public static void Exception(Exception ex)
		{
			Exception(Defaults.DefaultEventId, ex);
		}
		#endregion

		#region Methods where the eventId is specified
		/// <summary>
		/// Logs an error message.  This should be used for events that should always
		/// be logged.  Typically, this is for errors that are preventing the system
		/// from working, or for unexpected errors whose impact is unknown.  The latter
		/// type should typically be investigated to see if they can be caught appropriately
		/// and recovered from, in which case they should be logged as warnings instead.
		/// </summary>
		public static void Error(int eventId, string format, params object[] args)
		{
			SfgLogger.Write(Format(format, args), Categories.Error, eventId, PriorityLevel.Error, TraceEventType.Error);
		}

		/// <summary>
		/// Logs a warning message.  This should be used for events the application is
		/// able to recover from, but that may indicate a problem that should be addressed.
		/// If warning messages are researched and determined to not be a problem for the
		/// application, then they should be loagged as Info (or perhaps Trace) instead.
		/// </summary>
		public static void Warning(int eventId, string format, params object[] args)
		{
			SfgLogger.Write(Format(format, args), Categories.Warning, eventId, PriorityLevel.Warning, TraceEventType.Warning);
		}

		/// <summary>
		/// Logs an informational message.  Use this for messages that represent important
		/// events in the execution of the application.  During normal application operation,
		/// Info messages (and higher) should be kept to a minimum; they should be used only
		/// for important events in the applications lifecycle, such as startup and shutdown,
		/// and perhaps occasional messages that indicate the health of the system and/or what
		/// it is doing at a macro-scale.
		/// </summary>
		public static void Info(int eventId, string format, params object[] args)
		{
			SfgLogger.Write(Format(format, args), Categories.Info, eventId, PriorityLevel.Info, TraceEventType.Information);
		}

		/// <summary>
		/// Logs a trace message.  Use this for messages that may be useful at times
		/// in diagnosing certain issues, but that may be too detailed or too numerous
		/// to be appropriate for everyday inclusion in the logs.  An application should log a 
		/// sufficient amount trace messages in order to make it possible for development and 
		/// support personnel to troubleshoot production issues as they arise.  These messages 
		/// should not be overly numerous and should not occur in code that is repeated often 
		/// (e.g. inside a loop).
		/// </summary>
		public static void Trace(int eventId, string format, params object[] args)
		{
			SfgLogger.Write(Format(format, args), Categories.Info, eventId, PriorityLevel.Verbose, TraceEventType.Verbose);
		}

		/// <summary>
		/// Logs a debug message.  Use this for messages that would truly be information-
		/// overload in most situations, but that might come in handy when troubleshooting
		/// unexpected issues as they arise.
		/// </summary>
		public static void Debug(int eventId, string format, params object[] args)
		{
			SfgLogger.Write(Format(format, args), Categories.Info, eventId, PriorityLevel.Testing, TraceEventType.Verbose);
		}

		public static void Exception(int eventId, Exception ex)
		{
			SfgLogger.WriteException(ex, eventId);
		}
		#endregion
		#endregion
	}
}
