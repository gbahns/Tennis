using System;
using log4net;

namespace TennisObjects
{
	static public class Log
	{
		private static ILog log = LogManager.GetLogger("Default");

		public static void Info(string msg, params object[] args)
		{
			log.Info(string.Format(msg, args));
		}

		public static void Error(string msg, params object[] args)
		{
			log.Error(string.Format(msg, args));
		}

		public static void Fatal(string msg, params object[] args)
		{
			log.Fatal(string.Format(msg, args));
		}

		public static void Debug(string msg, params object[] args)
		{
			log.Debug(string.Format(msg, args));
		}

		public static void Warn(string msg, params object[] args)
		{
			log.Warn(string.Format(msg, args));
		}

	}
}
