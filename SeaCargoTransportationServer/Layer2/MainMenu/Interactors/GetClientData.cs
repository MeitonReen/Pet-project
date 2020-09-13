using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.GatewayToDatabase.Context;
using Layer2.Shared.Interactors;

namespace Layer2.MainMenu.Interactors
{
	public class GetClientData : InteractorAbstract
	{
		public override void SetDefault()
		{

		}

		public override object Execute(object dataFromInputConverter)
		{
			using (SeaCargoTransportationContext Database = GetDataBase())
			{
				Clients ClientData =
						Database?.Clients.FirstOrDefault(Client =>
							Client.Name == GetLoginClient());
				return ClientData;
			}
		}
	}
}
