using System;
using System.Collections.Generic;
using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.GatewayToDatabase.Context;
using Layer2.Shared.Interactors;
using SharedDTOsByServer.CreatingOrder;

namespace Layer2.CreatingOrder.Interactors
{
	public class SetNewOrder : InteractorAbstract
	{
		public override object Execute(object dataFromInputConverter)
		{
			using (SeaCargoTransportationContext Database = GetDataBase())
			{
				int IDClient = (int)GetClientIDByLogin();

				NewOrderLayer2 ReceivedNewOrder =
					(NewOrderLayer2)dataFromInputConverter;

				List<CargoLayer2> Cargos = ReceivedNewOrder?.Cargos;

				Random Random = new Random();

				Orders NewOrder = new Orders()
				{
					Idclient = IDClient,
					DateTimeCreate = DateTime.Now,
					ReceiptNumberOfOrder = Random.Next().ToString(),
				};
				Database?.Orders?.Add(NewOrder);
				Database?.SaveChanges();

				foreach (CargoLayer2 Cargo in Cargos ?? Enumerable.Empty<CargoLayer2>())
				{
					Containers NewContainer = new Containers()
					{
						Name = Random.Next().ToString()
					};
					Database?.Containers?.Add(NewContainer);
					Database?.SaveChanges();

					ContainersCharacteristics CharacteristicsOfNewContainer = new
						ContainersCharacteristics()
					{
						Weight = 5,

						LenghtIn = Cargo.CargoCharacteristics?.Length,
						HeightIn = Cargo.CargoCharacteristics?.Height,
						WidthIn = Cargo.CargoCharacteristics?.Wigth,
						AmountIn = Cargo.CargoCharacteristics?.Amount,

						LenghtOut = Cargo.CargoCharacteristics?.Length + 10,
						HeightOut = Cargo.CargoCharacteristics?.Height + 10,
						WidthOut = Cargo.CargoCharacteristics?.Wigth + 10,
						AmountOut = Cargo.CargoCharacteristics?.Amount + 1,

						Idcontainers = NewContainer.Idcontainers
					};
					Database?.ContainersCharacteristics.Add(CharacteristicsOfNewContainer);
					Database?.SaveChanges();

					List<ContainersForCargosAttributes> ContainersForCargosAttributes = new
							List<ContainersForCargosAttributes>();

					foreach (CargoAttributeLayer2 CargoAttribute in
						Cargo.CargoAttributes ?? Enumerable.Empty<CargoAttributeLayer2>())
					{
						ContainersForCargosAttributes ContainerForCargosAttributes = new
							ContainersForCargosAttributes()
						{
							Idcontainers = NewContainer.Idcontainers,
							IdattributesForCargos = CargoAttribute.IdattributesForCargos
						};
						ContainersForCargosAttributes.Add(ContainerForCargosAttributes);
					}
					Database?.ContainersForCargosAttributes.AddRange(ContainersForCargosAttributes);
					Database?.SaveChanges();

					CargosInOrders CargosInOrders = new CargosInOrders()
					{
						Idorder = NewOrder.Idorder,
						Idclient = IDClient,
						Idcontainers = NewContainer.Idcontainers
					};
					Database?.CargosInOrders.Add(CargosInOrders);
					Database?.SaveChanges();

					CargosCharacteristics CargosCharacteristics = new CargosCharacteristics()
					{
						Weight = Cargo.CargoCharacteristics?.Weight,
						Length = Cargo.CargoCharacteristics?.Length,
						Wigth = Cargo.CargoCharacteristics?.Wigth,
						Height = Cargo.CargoCharacteristics?.Height,
						Amount = Cargo.CargoCharacteristics?.Amount,
						IdcargosInOrders = CargosInOrders.IdcargosInOrders,
					};
					Database?.CargosCharacteristics.Add(CargosCharacteristics);
					Database?.SaveChanges();

					List<CargosAttributes> CargosAttributes = new List<CargosAttributes>();
					foreach (CargoAttributeLayer2 CargoAttribute in Cargo.CargoAttributes ??
						Enumerable.Empty<CargoAttributeLayer2>())
					{
						CargosAttributes CargosAttribute = new CargosAttributes()
						{
							IdcargosInOrders = CargosInOrders.IdcargosInOrders,
							IdattributesForCargos = CargoAttribute.IdattributesForCargos
						};

						CargosAttributes.Add(CargosAttribute);
					}
					Database?.CargosAttributes.AddRange(CargosAttributes);
					Database?.SaveChanges();
				}

				OrdersOnFligths OrdersOnFligths = new OrdersOnFligths()
				{
					DateTimeOfFlight = ReceivedNewOrder.SelectedFlight.DateTimeOfFlight,
					Idships = ReceivedNewOrder.SelectedFlight.IDShips,
					Idclient = IDClient,
					Idorder = NewOrder.Idorder
				};
				Database?.OrdersOnFligths.Add(OrdersOnFligths);
				Database?.SaveChanges();

				return null;
			}
		}
		public override void SetDefault()
		{
		}
	}
}
