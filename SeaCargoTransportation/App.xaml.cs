
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
using Layer0_Client.
	InterfacesForDataContext;
using Layer2_ApplicationUseCases.
	Interactors.
	CreatingOrder;

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
			InitializeSeaCargoTransportation(MainView);

			MainView.Show();
		}

		private void InitializeSeaCargoTransportation(VCreatingOrder mainView)
		{
			ControllerOfClientRequests ClientRequestsToApplication =
				new ControllerOfClientRequests();
			//VCreatingOrder VCreatingOrder = new VCreatingOrder();
		
			SynchronizationContext SynchronizationContext =
				SynchronizationContext.Current;

			ClientController ClientController = new ClientController(
				ClientRequestsToApplication,
				mainView,
				SynchronizationContext);


			ClientRequestsToApplication.RegistrationOfRequest(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				new CreatingOrder(
						new AttributesForCargosPresenter(ClientController))
				);
			
			ClientController.RegistrationVM(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				(IDataContextToApplication)mainView.Resources["VMAttributesForCargos"]);
		}
	}
}
