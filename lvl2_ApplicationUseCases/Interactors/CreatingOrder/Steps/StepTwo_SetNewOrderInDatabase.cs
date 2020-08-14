
using System.Collections.Generic;

using Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors;
using Layer2_ApplicationUseCases.GatewayToDatabase;
using Layer2_ApplicationUseCases.GatewayToDatabase.Context;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using System;
using Layer2_ApplicationUseCases.DataAboutClientRequest;


namespace Layer2_ApplicationUseCases.Interactors.CreatingOrder.States
{
	public class StepTwo_SetNewOrderInDatabase : IExecutorOfClientRequest
	{
		private ClientLayer2 Client = null;
		private SeaCargoTransportationContext Database =
			new SeaCargoTransportationContext();

		public StepTwo_SetNewOrderInDatabase(ClientLayer2 client)
		{
			Client = client;
		}

		public void ClearRequest()
		{
			//Скорее всего придётся Database освобождать, или раньше
		}

		public bool Execute(EnumClientRequests RequestID, object dataOfClientRequest)
		{	
			CargosIntoFlightLayer2 OrderOnFlight =
				(CargosIntoFlightLayer2)dataOfClientRequest;

			List<CargoLayer2> Cargos = OrderOnFlight.Cargos;

			Random Random = new Random();

			Orders NewOrder = new Orders()
			{
				Idclient = Client.IDСlient,
				DateTimeCreate = DateTime.Now,
				ReceiptNumberOfOrder = Random.Next().ToString(),
			};
			Database.Orders.Add(NewOrder);
			Database.SaveChanges();

			foreach(CargoLayer2 Cargo in Cargos)
			{
				Containers NewContainer = new Containers()
				{
					Name = Random.Next().ToString()
				};
				Database.Containers.Add(NewContainer);
				Database.SaveChanges();

				ContainersCharacteristics CharacteristicsOfNewContainer = new
					ContainersCharacteristics()
					{
						Weight = 5,

						LenghtIn = Cargo.CargoCharacteristics.Length,
						HeightIn = Cargo.CargoCharacteristics.Height,
						WidthIn = Cargo.CargoCharacteristics.Wigth,
						AmountIn = Cargo.CargoCharacteristics.Amount,

						LenghtOut = Cargo.CargoCharacteristics.Length + 10,
						HeightOut = Cargo.CargoCharacteristics.Height + 10,
						WidthOut = Cargo.CargoCharacteristics.Wigth + 10,
						AmountOut = Cargo.CargoCharacteristics.Amount + 1,

						Idcontainers = NewContainer.Idcontainers
					};
				Database.ContainersCharacteristics.Add(CharacteristicsOfNewContainer);
				Database.SaveChanges();

				List<ContainersForCargosAttributes> ContainersForCargosAttributes = new
						List<ContainersForCargosAttributes>();

				foreach(CargoAttributeLayer2 CargoAttribute in
					Cargo.CargoAttributes)
				{
					ContainersForCargosAttributes ContainerForCargosAttributes = new
						ContainersForCargosAttributes()
						{
							Idcontainers = NewContainer.Idcontainers,
							IdattributesForCargos = CargoAttribute.IdattributesForCargos
						};
					ContainersForCargosAttributes.Add(ContainerForCargosAttributes);
				}
				Database.ContainersForCargosAttributes.AddRange(ContainersForCargosAttributes);
				Database.SaveChanges();

				CargosInOrders CargosInOrders = new CargosInOrders()
				{
					Idorder = NewOrder.Idorder,
					Idclient = Client.IDСlient,
					Idcontainers = NewContainer.Idcontainers
				};
				Database.CargosInOrders.Add(CargosInOrders);
				Database.SaveChanges();

				CargosCharacteristics CargosCharacteristics = new CargosCharacteristics()
				{
					Weight = Cargo.CargoCharacteristics.Weight,
					Length = Cargo.CargoCharacteristics.Length,
					Wigth = Cargo.CargoCharacteristics.Wigth,
					Height = Cargo.CargoCharacteristics.Height,
					Amount = Cargo.CargoCharacteristics.Amount,
					IdcargosInOrders = CargosInOrders.IdcargosInOrders,
				};
				Database.CargosCharacteristics.Add(CargosCharacteristics);
				Database.SaveChanges();

				List<CargosAttributes> CargosAttributes = new List<CargosAttributes>();
				foreach(CargoAttributeLayer2 CargoAttribute in Cargo.CargoAttributes)
				{
					CargosAttributes CargosAttribute = new CargosAttributes()
					{
						IdcargosInOrders = CargosInOrders.IdcargosInOrders,
						IdattributesForCargos = CargoAttribute.IdattributesForCargos
					};

					CargosAttributes.Add(CargosAttribute);
				}
				Database.CargosAttributes.AddRange(CargosAttributes);
				Database.SaveChanges();
			}

			OrdersOnFligths OrdersOnFligths = new OrdersOnFligths()
			{
				DateTimeOfFlight = OrderOnFlight.FlightSchedule.DateTimeOfFlight,
				Idships = OrderOnFlight.FlightSchedule.IDShips,
				Idclient = Client.IDСlient,
				Idorder = NewOrder.Idorder
			};
			Database.OrdersOnFligths.Add(OrdersOnFligths);
			Database.SaveChanges();

			return true;
		}
	}
}
