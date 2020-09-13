using Layer0_Client.Shared.SettersToDataContext;
using Layer0_Client.MainMenu.DataContextForBindingsToWPF;
using SharedDTOsByServer.MainMenu;

namespace Layer0_Client.MainMenu.SettersToDataContext
{
	public class ClientData : AbstractSetterToDataContext
	{
		private DCMainMenu DCMainMenu = null;

		public ClientData(object dCMainMenu)
		{
			DCMainMenu = dCMainMenu as DCMainMenu;
		}
		protected override object SetToDataContext(object presentationData)
		{
			ClientLayer2 Client =
				(ClientLayer2)presentationData;
			DCMainMenu.Client = Client;

			return null;
		}
	}
}
