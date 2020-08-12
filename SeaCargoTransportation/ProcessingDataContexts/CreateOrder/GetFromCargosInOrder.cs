using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

using Layer0_Client.InterfacesForProcessingDataContexts;
using Layer0_Client.DataContextsForBindings.CreateOrder;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	SetNewOrderInDatabase;
using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;

namespace Layer0_Client.ProcessingDataContexts.CreateOrder
{
	public class GetFromCargosInOrder : IGetterFromDataContextForClientRequest
	{
		private DCCreateOrder DCCargosInOrder;

		public GetFromCargosInOrder(DCCreateOrder dCCargosInOrders)
		{
			DCCargosInOrder = dCCargosInOrders;
		}

		public object Get()
		{
			List<CargoLayer2> CargosLayer2 = null;
			ObservableCollection<CargoLayer0> CargosLayer0 =
				new ObservableCollection<CargoLayer0>(DCCargosInOrder.Cargos);
				
			CargosLayer0 = 
				FilterAttributesIsNotSelected(CargosLayer0);
			CargosLayer2 = ToCargosLayer2(CargosLayer0);

			return CargosLayer2;
		}
		private List<CargoLayer2> ToCargosLayer2(
			ObservableCollection<CargoLayer0> cargosLayer0)
		{
			IEnumerable<CargoLayer2> CargosLayer2BeforeConvert = 
				cargosLayer0.Select(CargoLayer0 =>
				{
					CargoLayer2 CargoLayer2 = new CargoLayer2();
					CargoLayer2.CargoCharacteristics.Height =
						CargoLayer0.CargoCharacteristics.Height;
					CargoLayer2.CargoCharacteristics.Wigth =
						CargoLayer0.CargoCharacteristics.Wigth;
					CargoLayer2.CargoCharacteristics.Weight =
						CargoLayer0.CargoCharacteristics.Weight;
					CargoLayer2.CargoCharacteristics.Amount =
						CargoLayer0.CargoCharacteristics.Amount;
					CargoLayer2.CargoCharacteristics.Length =
						CargoLayer0.CargoCharacteristics.Length;

					IEnumerable<CargoAttributeLayer2> CargoAttributeLayer2BeforeConvert =
						CargoLayer0.CargoAttributes.Select(AttributeForCargoLayer0 =>
						{
							CargoAttributeLayer2 CargoAttributeLayer2 =
								new CargoAttributeLayer2();
							CargoAttributeLayer2.IdattributesForCargos =
								AttributeForCargoLayer0.IdattributesForCargos;

							return CargoAttributeLayer2;
						});
					CargoLayer2.CargoAttributes =
						new List<CargoAttributeLayer2>(CargoAttributeLayer2BeforeConvert);

					return CargoLayer2;
				});

			return new List<CargoLayer2>(CargosLayer2BeforeConvert);
		}
		private ObservableCollection<CargoLayer0> 
			FilterAttributesIsNotSelected(
				ObservableCollection<CargoLayer0>
					Cargos)
		{
			IEnumerable<CargoLayer0> FilteredCargosBeforeConvert = Cargos.Select(Cargo =>
			{
				IEnumerable<AttributeForCargoLayer0> FilteredAttributesBeforeConvert =
					Cargo.CargoAttributes.Where(AttributeForCargo =>
					{
						return AttributeForCargo.IsSelected;
					});

				Cargo.CargoAttributes = new
					ObservableCollection<AttributeForCargoLayer0>(
						FilteredAttributesBeforeConvert);

				return Cargo;
			});

			return new ObservableCollection<CargoLayer0>(FilteredCargosBeforeConvert);
		}
	}
}
