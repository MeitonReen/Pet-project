using System.Linq;
using Layer2.Shared.GatewayToDatabase.Context;
using SharedDTOs;

namespace Layer2.Shared.Interactors
{
	public abstract class InteractorAbstract : IExecutorOfClientRequest
	{
		protected SeaCargoTransportationContext Database = null;
		protected object DataAuthorization = null;
		protected object SharedCommunication = null;

		protected string GetLoginClient()
		{
			return (DataAuthorization as LoginAndPassword).Login;
		}
		protected int? GetClientIDByLogin()
		{ 
			int? IDClient = null;
			GetDataBase();
			IDClient = Database.Clients.FirstOrDefault(Client =>
				Client.Name == GetLoginClient())?.Idclient;

			return IDClient;
		}
		protected SeaCargoTransportationContext GetDataBase()
		{
			Database = (Database != null) ?
				Database : (DataAuthorization != null) ?
					new SeaCargoTransportationContext(DataAuthorization) : null;

			return Database;
		}

		public void MulticastSendDataAuthorization(object dataAuthorization)
		{
			DataAuthorization = dataAuthorization;
		}

		public void SetSharedCommunication(object reference)
		{
			SharedCommunication = reference;
		}

		public abstract object Execute(object dataFromInputConverter);
		public abstract void SetDefault();
	}
}
