
using System.Linq;

using Layer2.Shared.GatewayToDatabase;
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
			using (Database = GetDataBase())
			{
				if (Database == null)
					return null;
					Clients ClientData =
						Database.Clients.FirstOrDefault(Client =>
							Client.Name == GetLoginClient());

					Database = null;
					return ClientData;
			}
		}
	}
}
