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

namespace TennisWPF
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
            //this.Style = (Style)Resources["GlassStyle"];
        }

        private void _OnStandardChromeClicked(object sender, RoutedEventArgs e)
        {
            this.Style = null;
        }

        private void _OnGradientChromeClicked(object sender, RoutedEventArgs e)
        {
            var style = (Style)Resources["GradientStyle"];
            this.Style = style;
        }

        private void _OnGlassyChromeClicked(object sender, RoutedEventArgs e)
        {
            var style = (Style)Resources["GlassStyle"];
            this.Style = style;
        }

        private void _OnSystemCommandCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow((Window)e.Parameter);
        }
    }
}
