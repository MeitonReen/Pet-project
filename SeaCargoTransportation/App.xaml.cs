
using System.Windows;
using System.Threading;

using Layer0_Client.Views;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer0_Client.DataContextsForBindings.MainMenu;
using Layer0_Client.CreatorLay0;
using Layer1_CommunicatorsBtwLay0AndLay2.CreatorLay1;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using System.Net;
using System.Diagnostics;
using Layer0_Client.DataContextsForBindings.Authentification;
using Layer0_Client.CommandForViews.CreateOrder;
using Layer0_Client.CommandForViews.Shared;
using Layer0_Client.CommandForViews.MainMenu;
using Layer0_Client.InterfacesForClientController;

namespace SeaCargoTransportation
{

	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			VAuthentification MainView = new VAuthentification();
			Application.Current.MainWindow = MainView;
			MainView.Show();
		}

		
		public void VMainMenu()
		{
			Window VCreatingOrder = Application.Current.MainWindow;

			Application.Current.MainWindow = new VMainMenu();

			VCreatingOrder.Close();

			Application.Current.MainWindow.Show();
		}

		public void CreatingOrder()
		{
			Window VMainMenu = Application.Current.MainWindow;

			Application.Current.MainWindow = new VCreatingOrder();

			VMainMenu.Close();

			DCCreateOrder DCCreateOrder =
				(DCCreateOrder)
					Application.Current.MainWindow.Resources["DCCreateOrder"];

			ISenderOfClientRequestsToApplication ClientController =
				((VMainMenu.Resources["DCMainMenu"] as DCMainMenu).
					GetClientDataAndClientOrders as GetClientDataAndClientOrders).
						get_GetClientData().getcc();
			
					
			if (DCCreateOrder != null)
			{
				Initialize Initialize =
					(DCCreateOrder.InitializeCreateOrder as
						Initialize);
				Initialize.LinkToSenderOfClientRequestsToApplication(
					ClientController);

				SendClientRequest SendClientRequest =
					(DCCreateOrder.SendRequestSetCargosInOrders as
						SendClientRequest);
				SendClientRequest.LinkToSenderOfClientRequestsToApplication(
					ClientController);
			}

			DCCreateOrder.InitializeCreateOrder.Execute(null);

			Application.Current.MainWindow.Show();
		}

		public void Authentification()
		{
			Window VAuthentification = Application.Current.MainWindow;
			//Промежуточная версия
			Application.Current.MainWindow = new VMainMenu();
			ClientLayer2 Client =
				(VAuthentification.Resources["DCAuthentification"] as
					DCAuthentification).Client;

			VAuthentification.Close();
			
			SynchronizationContext SynchronizationContext =
				SynchronizationContext.Current;
			InitializeSeaCargoTransportation(
				SynchronizationContext,
				Application.Current.MainWindow.Resources,
				Client);

			(Application.Current.MainWindow.Resources["DCMainMenu"] as DCMainMenu).
				GetClientDataAndClientOrders.Execute(null);
			Application.Current.MainWindow.Show();
		}

		private void InitializeSeaCargoTransportation(
			SynchronizationContext synchronizationContext,
			ResourceDictionary giverDataContexts,
			ClientLayer2 client)
		{
			
			if ((DCMainMenu)giverDataContexts["DCMainMenu"] != null)
			{
				((DCMainMenu)giverDataContexts["DCMainMenu"]).Client =
					client;
			}

			CreatorLay1 CreatorLay1 = new CreatorLay1(client);

			CreatorLay0 CreatorLay0 = new CreatorLay0(
				CreatorLay1.GetReceiverDataOfClientRequest(),
				synchronizationContext,
				(DCCreateOrder)giverDataContexts["DCCreateOrder"],
				(DCMainMenu)giverDataContexts["DCMainMenu"],
				client);

			CreatorLay1.LinkToReceiverDataOfClientCommands(
				CreatorLay0.GetReceiverOfResponsesToClient());

			;
		}
	}
}
