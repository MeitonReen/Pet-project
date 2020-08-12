
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

namespace SeaCargoTransportation
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			VMainMenu MainView = new VMainMenu();
			
			Application.Current.MainWindow = MainView;

			SynchronizationContext SynchronizationContext =
				SynchronizationContext.Current;

			ClientLayer2 Client = new ClientLayer2();//Получен будет из авторизации

			InitializeSeaCargoTransportation(
				SynchronizationContext,
				MainView.Resources,
				Client);

			MainView.Show();
		}

		private void InitializeSeaCargoTransportation(
			SynchronizationContext synchronizationContext,
			ResourceDictionary giverDataContexts,
			ClientLayer2 client)
		{
			
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
