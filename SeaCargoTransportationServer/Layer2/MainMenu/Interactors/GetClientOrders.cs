using System.Linq;
using System.Collections.Generic;

using SharedDTOsByServer.MainMenu;
using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.Interactors;

namespace Layer2.MainMenu.Interactors
{
	public class GetClientOrders : InteractorAbstract
	{
		public override object Execute(object dataFromInputConverter)
		{
			using (GetDataBase())
			{
				List<OrderLayer2> ClientOrders = new List<OrderLayer2>();

				List<Orders> ClientOrdersDB =
					Database.Orders.Where(Order =>
						Order.Idclient == (int)GetClientIDByLogin()).ToList();

				foreach (Orders Order in ClientOrdersDB)
				{
					OrderLayer2 OrderLayer2 = new OrderLayer2();
					OrderLayer2.IDOrder = Order.Idorder;
					OrderLayer2.DateTimeCreate = Order.DateTimeCreate;
					OrderLayer2.ReceiptNumberOfOrder = Order.ReceiptNumberOfOrder;

					List<CargoLayer2> CargosLayer2 = new List<CargoLayer2>();

					List<CargosInOrders> CargosInOrder =
						Database.CargosInOrders.Where(CargosInOrder =>
							CargosInOrder.Idorder == Order.Idorder).ToList();

					foreach (CargosInOrders Cargo in CargosInOrder)
					{
						CargosCharacteristics CargoCharacteristics =
							Database.CargosCharacteristics.FirstOrDefault(
								CargoCharacteristics =>
									CargoCharacteristics.IdcargosInOrders ==
										Cargo.IdcargosInOrders);

						CargoLayer2 CargoLayer2 = new CargoLayer2();
						CargoLayer2.IDCargosInOrders = Cargo.IdcargosInOrders;
						CargoLayer2.Amount = CargoCharacteristics.Amount != null ?
							(decimal)CargoCharacteristics.Amount : 0;
						CargoLayer2.Weight = CargoCharacteristics.Weight != null ?
							(decimal)CargoCharacteristics.Weight : 0;

						CargosLayer2.Add(CargoLayer2);
					}

					OrderLayer2.Cargos = CargosLayer2;

					List<OrderOnFlightLayer2> OrderOnFligths = new List<OrderOnFlightLayer2>();

					List<OrdersOnFligths> OrderOnFligthsDB =
						Database.OrdersOnFligths.Where(OrderOnFligths =>
							OrderOnFligths.Idorder == OrderLayer2.IDOrder).ToList();

					foreach (OrdersOnFligths OrderOnFligthDB in OrderOnFligthsDB)
					{
						OrderOnFlightLayer2 OrderOnFlight = new OrderOnFlightLayer2();
						OrderOnFlight.DateTimeOfFlight = OrderOnFligthDB.DateTimeOfFlight;
						OrderOnFlight.ShipNumber = Database.Ships.FirstOrDefault(Ship =>
							Ship.Idships == OrderOnFligthDB.Idships).ShipNumber;

						List<StatusesFligths> StatusesFlight =
							Database.StatusesFligths.Where(Statuses =>
								Statuses.Idships == OrderOnFligthDB.Idships &&
									Statuses.DateTimeOfFlight ==
										OrderOnFligthDB.DateTimeOfFlight).ToList();

						OrderOnFlight.StatusesFlight = StatusesFlight.Select(Status1 =>
						{
							StatusesForFligths StatusesForFligths =
								Database.StatusesForFligths.FirstOrDefault(Status2 =>
									Status2.IdstatusesForFligths ==
										Status1.IdstatusesForFligths);
							return StatusesForFligths.Status;
						}).ToList();

						OrderOnFligths.Add(OrderOnFlight);
					}

					OrderLayer2.OrderOnFligths = OrderOnFligths;

					ClientOrders.Add(OrderLayer2);
				}

				Database = null;
				return ClientOrders;
			}
		}

		public override void SetDefault()
		{
		}
	}
}
