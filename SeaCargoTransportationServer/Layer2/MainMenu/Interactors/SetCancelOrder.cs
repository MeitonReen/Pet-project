using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.GatewayToDatabase.Context;
using Layer2.Shared.Interactors;

namespace Layer2.MainMenu.Interactors
{
	public class SetCancelOrder : InteractorAbstract
	{
		public override object Execute(object dataFromClient)
		{
			int? IDOrder = (int?)dataFromClient;
			if (IDOrder.HasValue)
			{
				using (SeaCargoTransportationContext Database = GetDataBase())
				{
					Orders RemoveOrder =
						Database?.Orders.FirstOrDefault(Order => Order.Idorder == IDOrder.Value);
					Database?.Orders.Remove(RemoveOrder);
					Database?.SaveChanges();
				}
			}
			return null;
		}

		public override void SetDefault()
		{
		}
	}
}
