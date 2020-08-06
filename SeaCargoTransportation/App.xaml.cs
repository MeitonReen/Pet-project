
using System.Windows;
using System.Threading;

using Layer0_Client.Views;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	ControllerOfClientRequests;
using Layer0_Client.
	ClientController;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests;
using Layer2_ApplicationUseCases.
	Interactors.
	CreatingOrder;
using Layer0_Client.
	CommandForViews.Shared;
using Layer0_Client.
	ProcessingDataContexts.
	CreateOrder;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer0_Client.CreatorLay0;
using Layer1_CommunicatorsBtwLay0AndLay2.CreatorLay1;

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

			VCreatingOrder MainView = new VCreatingOrder();
			
			Application.Current.MainWindow = MainView;

			SynchronizationContext SynchronizationContext =
				SynchronizationContext.Current;

			InitializeSeaCargoTransportation(
				SynchronizationContext,
				MainView.Resources);

			MainView.Show();
		}

		private void InitializeSeaCargoTransportation(
			SynchronizationContext synchronizationContext,
			ResourceDictionary giverDataContexts)
		{
			
			CreatorLay1 CreatorLay1 = new CreatorLay1();

			CreatorLay0 CreatorLay0 = new CreatorLay0(
				CreatorLay1.GetReceiverDataOfClientRequest(),
				synchronizationContext,
				(DCCreateOrder)giverDataContexts["DCCreateOrder"]);

			CreatorLay1.LinkToReceiverDataOfClientCommands(
				CreatorLay0.GetReceiverOfResponsesToClient());

			;
		}
	}
}
