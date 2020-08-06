
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
namespace Layer0_Client.DataContextsForBindings.CreateOrder
{
	public class DCCreateOrder
	{
		public ObservableCollection<CargoLayer0> Cargos { get; set; } = null;
		public CargoLayer0 CargoLayer0 { get; set; } = null;
		public ObservableCollection<AttributeForCargoLayer0>
			GettedAttributesForCargo { get; set; } = null;

		public DCCreateOrder()
		{
			Cargos = new ObservableCollection<CargoLayer0>();
			GettedAttributesForCargo = 
				new ObservableCollection<AttributeForCargoLayer0>();

			CargoLayer0 NewCargo = new CargoLayer0(0);
			NewCargo.CargoAttributes =
				new ObservableCollection<AttributeForCargoLayer0>();
			NewCargo.CargoCharacteristics = new CargoCharacteristicsLayer0();

			Cargos.Add(NewCargo);
		}

		public ICommand SendRequestGetAttributesForCargos
		{ 
			get
			{
				return GetAttributesForCargos;
			}
		}
		private SendClientRequest GetAttributesForCargos =
			new SendClientRequest(
					EnumClientRequests.CreatingOrder_GetAttributeForCargos);
		
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
