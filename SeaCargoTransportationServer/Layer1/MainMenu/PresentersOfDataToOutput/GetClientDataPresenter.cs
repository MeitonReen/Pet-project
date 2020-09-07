using Layer1.Shared.PresentersOfDataToOutput;
using Layer2.Shared.GatewayToDatabase;
using SharedDTOsByServer.MainMenu;

namespace Layer1.MainMenu.PresentersOfDataToOutput
{
	public class GetClientDataPresenter : AbstractPresenterOfDataToOutput
	{
		protected override object Present(object client)
		{
			Clients Client = (Clients)client;

			ClientLayer2 ClientLayer2 = new ClientLayer2()
			{
				IDСlient = Client.Idclient,
				FirstName = Client.FirstName,
				LastName = Client.LastName,
				Patronymic = Client.Patronymic
			};

			return ClientLayer2;
		}
	}
}
