using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Shell;
using System.ComponentModel;

namespace TennisWPF
{
	/// <summary>
	/// Interaction logic for Window2.xaml
	/// </summary>
	public partial class Window2 : Window, INotifyPropertyChanged
	{
		public Window2()
		{
			InitializeComponent();
			DataContext = this;
		}

		private void _OnSystemCommandCloseWindow(object sender, ExecutedRoutedEventArgs e)
		{
			Close();
		}

		private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 1)
			{
				Point p = this.PointToScreen(e.GetPosition(this) );
				p.X += 1;
				p.Y += 1;
				SystemCommands.ShowSystemMenu(this, p);
			}
			if (e.ClickCount == 2)
				Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void MinButton_Click(object sender, RoutedEventArgs e)
		{
			SystemCommands.MinimizeWindow(this);
		}

		private void MaxButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == System.Windows.WindowState.Maximized)
				SystemCommands.RestoreWindow(this);
			else
				SystemCommands.MaximizeWindow(this);
		}

		public Thickness TitlePadding
		{
			get
			{
				if (WindowState == System.Windows.WindowState.Maximized)
					return new Thickness(6, 6, 0, 0);
				else
					return new Thickness(0);
			}
		}

		public Thickness WindowIconsMargin
		{
			get
			{
				if (WindowState == System.Windows.WindowState.Maximized)
					return new Thickness(6, 6, 12, 0); //Margin="0,0,12,0"
				else
					return new Thickness(0,0,12,0);
			}
		}

		protected override void OnStateChanged(EventArgs e)
		{
			base.OnStateChanged(e);
			OnPropertyChanged("TitlePadding");
			OnPropertyChanged("WindowIconsMargin");
		}

		#region INotifyPropertyChanged
		private void OnPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
}
