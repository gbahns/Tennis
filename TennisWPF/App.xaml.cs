using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using log4net;

namespace TennisWPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{

		private static ILog log;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			//DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

	        log4net.Config.DOMConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log.config"));
			log = LogManager.GetLogger(typeof(App).ToString());
			log.Info("App.OnStartup");
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			log.Info("App.OnExit");
		}

		protected override void OnLoadCompleted(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnLoadCompleted(e);
			log.Info("App.OnLoadCompleted");
		}

		protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
		{
			base.OnSessionEnding(e);
			log.Info("App.OnSessionEnding");
		}

		void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			log.Error("Error", e.Exception);

			MessageBox.Show(e.Exception.Message,"Application Error");

			e.Handled = true;
		}

		

		
		//protected override void OnStartup(StartupEventArgs e)
		//{
		//    base.OnStartup(e);

		//    MainWindow window = new MainWindow();

		//    // Create the ViewModel to which 
		//    // the main window binds.
		//    string path = "Data/customers.xml";
		//    var viewModel = new MainWindowViewModel(path);

		//    // When the ViewModel asks to be closed, 
		//    // close the window.
		//    EventHandler handler = null;
		//    handler = delegate
		//    {
		//        viewModel.RequestClose -= handler;
		//        window.Close();
		//    };
		//    viewModel.RequestClose += handler;

		//    // Allow all controls in the window to 
		//    // bind to the ViewModel by setting the 
		//    // DataContext, which propagates down 
		//    // the element tree.
		//    window.DataContext = viewModel;

		//    window.Show();
		//}
	}
}
