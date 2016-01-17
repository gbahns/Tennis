using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TennisObjects;
using TennisSL.ServiceReference1;
using System.ServiceModel;

namespace TennisSL
{
	public partial class Page : UserControl
	{
		Service1 TennisService;
		//ITennis TennisService;

		public Page()
		{
			InitializeComponent();

			PlayerListBox.ItemsSource = Player.GetList();

			BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
			EndpointAddress endpointAddress = new EndpointAddress("http://localhost/TennisWCF/Tennis.svc");
			TennisService = new ChannelFactory<Service1>(basicHttpBinding, endpointAddress).CreateChannel();

			//TennisService =  new TennisClient();
			//TennisService.BeginGetData(5,GetDataCallback,null);
			  
		}

		/*
		 * An exception of type 'System.ServiceModel.CommunicationException' occurred in System.ServiceModel.dll but was not 
		 * handled in user code

		Additional information: An error occurred while trying to make a request to URI 'http://localhost:4308/Tennis.svc'. 
		 * This could be due to attempting to access a service in a cross-domain way without a proper cross-domain policy in place, 
		 * or a policy that is unsuitable for SOAP services. You may need to contact the owner of the service to publish a 
		 * cross-domain policy file and to ensure it allows SOAP-related HTTP headers to be sent. Please see the inner exception for 
		 * more details.
		 */

		//[ComVisibleAttribute(true)]
		//public delegate void GetDataCallback(IAsyncResult ar)
	
		void GetDataCallback(IAsyncResult ar)
		{
			try
			{
				//TestTextBox.Text = TennisService.EndGetData(ar);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			
		} 

	}
}
