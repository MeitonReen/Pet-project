using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.Interactors;

namespace Layer2.MainMenu.Interactors
{
	public class SetOrderCancel : InteractorAbstract
	{
		public override object Execute(object dataFromInputConverter)
		{
			int? IDOrder = (int?)dataFromInputConverter;
			if (IDOrder.HasValue)
			{
				using (GetDataBase())
				{
					Orders RemoveOrder =
						Database.Orders.FirstOrDefault(Order => Order.Idorder == IDOrder);
					Database.Orders.Remove(RemoveOrder);
					Database.SaveChanges();
				}
			}

			return null;
		}

		public override void SetDefault()
		{
		}
	}
}
