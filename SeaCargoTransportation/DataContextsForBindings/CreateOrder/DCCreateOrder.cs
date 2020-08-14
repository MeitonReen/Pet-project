
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Layer1_CommunicatorsBtwLay0AndLay2.
    TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer0_Client.CommandForViews.Shared;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer0_Client.CommandForViews.CreateOrder;
//Для send создаём один раз, потому что связываю руками с сендером
//запросов клиента в приложение через ресурсы WPF в app.xaml
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase;
using System.Windows;
using SeaCargoTransportation;

namespace Layer0_Client.DataContextsForBindings.CreateOrder
{
	public class DCCreateOrder
	{
		public ObservableCollection<CargoLayer0> Cargos { get; set; } = null;
		
		public ObservableCollection<AttributeForCargoLayer0>
			GettedAttributesForCargo { get; set; } = null;
		public ObservableCollection<FlightScheduleLayer2>
			GettedFlightsSchedule { get; set; } = null;

		public DCCreateOrder()
		{
			Cargos = new ObservableCollection<CargoLayer0>();
			GettedAttributesForCargo = 
				new ObservableCollection<AttributeForCargoLayer0>();
			GettedFlightsSchedule = 
				new ObservableCollection<FlightScheduleLayer2>();

			CargoLayer0 NewCargo = new CargoLayer0(0);
			NewCargo.CargoAttributes =
				new ObservableCollection<AttributeForCargoLayer0>();
			NewCargo.CargoCharacteristics = new CargoCharacteristicsLayer0();

			Cargos.Add(NewCargo);
		}

		private Initialize Initialize =
			new Initialize();
		public ICommand InitializeCreateOrder
		{ 
			get
			{
				return Initialize;
			}
		}

		private SendClientRequest SetCargosInOrders =
			new SendClientRequest(
					EnumClientRequests.CreatingOrder_SetCargosInOrders);
		public ICommand SendRequestSetCargosInOrders
		{ 
			get
			{
				//Промежуточная версия
				(Application.Current as App).VMainMenu();
				return SetCargosInOrders;
			}
		}
		
		public ICommand AddCargo
		{
			get
			{
				return
					new AddCargo(Cargos, GettedAttributesForCargo);
			}
		}

		public ICommand RemoveCargo
		{
			get
			{
				return
					new RemoveCargo(Cargos, GettedAttributesForCargo);
			}
		}
	}
}
