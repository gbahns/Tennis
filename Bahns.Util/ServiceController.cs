using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Bahns.Util
{
	public class ServiceController : System.ServiceProcess.ServiceController, INotifyPropertyChanged
	{
		public class LookupList : KeyedCollection<string, ServiceController>
		{
			#region KeyedCollection Members
			protected override string GetKeyForItem(ServiceController item)
			{
				return item.FullName;
			}
			#endregion
		}

		//Timer refreshTimer = new Timer();

		#region Constructors
		public ServiceController() : base() { InitTimer(); }
		public ServiceController(string name) : base(name) { InitTimer(); }
		public ServiceController(string name, string machineName) : base(name, machineName) { InitTimer(); }
		#endregion

		#region Static Helpers
		private static T GetRegValue<T>(string serviceName, string name)
		{
			return (T)Registry.GetValue(string.Format(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\{0}", serviceName), name, default(T));
		}

		public static string GetExePath(string serviceName)
		{
			return GetRegValue<string>(serviceName, "ImagePath").Replace("\"","");

		}
		#endregion

		#region Extended Info
		private T GetRegValue<T>(string name)
		{
			return (T)Registry.GetValue(string.Format(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\{0}", ServiceName), name, default(T));
		}

		public string ExePath
		{
			get
			{
				return GetExePath(ServiceName); //GetRegValue<string>("ImagePath");
			}
		}
		#endregion

		public bool ServiceExists
		{
			get
			{
				try
				{
					bool b = this.CanPauseAndContinue;
					return true;
				}
				catch
				{
					return false;
				}
			}
		}

		protected virtual void InitTimer()
		{
			//refreshTimer.Interval = 100;
			//refreshTimer.Tick += new EventHandler(refreshTimer_Tick);
		}

		new public void Refresh()
		{
			base.Refresh();
			OnPropertyChanged(null);
		}

		/// <summary>
		/// MachineName\DisplayName
		/// </summary>
		public string FullName
		{
			get 
			{
				try
				{
					return MachineName + "\\" + DisplayName; 
				}
				catch (Exception)
				{
					return "";
				}
			}
		}

		//public bool AutoRefresh
		//{
		//    get { return refreshTimer.Enabled; }
		//    set
		//    {
		//        if (value == AutoRefresh)
		//            return;

		//        if (value)
		//            refreshTimer.Start();
		//        else
		//            refreshTimer.Stop();
		//    }
		//}

		//void refreshTimer_Tick(object sender, EventArgs e)
		//{
		//    Refresh();
		//}

		//public event EventHandler Refresh;

		//private void OnRefresh()
		//{
		//    if (PropertyChanged != null)
		//    {
		//        PropertyChanged(this, new PropertyChangedEventArgs(info));
		//    }
		//}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
		#endregion
	}

}
