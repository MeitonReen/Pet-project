using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.Interactors;
using Shared.Dictionary;
using SharedDTOs;
using SharedDTOs.DataAboutClientRequests;

namespace Layer2.Authentification.Interactors
{
	public class GetAuthorization : InteractorAbstract
	{
		public override object Execute(object dataFromInputConverter)
		{
			LoginAndPassword LoginAndPassword = (LoginAndPassword)dataFromInputConverter;

			bool Connected = false;
			DataAuthorization = LoginAndPassword;
			using (GetDataBase())
			{
				Clients Client = Database.Clients.FirstOrDefault(Client =>
					Client.Name == LoginAndPassword.Login);
				Database = null;
				
				if (Client != null)
				{
					Connected = true;

					(SharedCommunication as DictionaryOfHandlers<EnumClientRequests>)?.
						MulticastSendServiceData(LoginAndPassword);
				}
				
				return Connected;
			}
		}

		public override void SetDefault()
		{
		}
	}
}
