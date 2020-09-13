using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Layer0_Client.Shared.ClientPresenters;
using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using SharedDTOsByServer.CreatingOrder;
using SharedDTOsByClient.CreatingOrder;

namespace Layer0_Client.CreatingOrder.ClientPresenters
{
	public class CreateOrder : AbstractGetterFromDataContext
	{
		private DCCreatingOrder DCCreatingOrder = null;

		public CreateOrder(object dCCreatingOrder)
		{
			DCCreatingOrder = dCCreatingOrder as DCCreatingOrder;
		}

		protected override object GetFromDataContext( )
		{
			object GettedData = null;

			if (DCCreatingOrder != null)
			{
				GettedData = Prepare(DCCreatingOrder);
			}

			return GettedData;
		}
		private object Prepare(DCCreatingOrder DCCreateOrder)
		{
			NewOrderLayer2 NewOrder = new NewOrderLayer2();
			NewOrder.SelectedFlight =
				DCCreateOrder.GettedFlightsSchedule.FirstOrDefault(FlightSchedule =>
					FlightSchedule.IsSelected);

			ObservableCollection<CargoLayer0> CargosLayer0 =
				FilterUnSelectedAttributesForCargo(DCCreateOrder.Cargos);
			NewOrder.Cargos = ToCargosLayer2(CargosLayer0);

			return NewOrder;
		}
		private List<CargoLayer2> ToCargosLayer2(
			ObservableCollection<CargoLayer0> cargosLayer0)
		{
			IEnumerable<CargoLayer2> CargosLayer2BeforeConvert =
				cargosLayer0.Select(CargoLayer0 =>
				{
					CargoLayer2 CargoLayer2 = new CargoLayer2();

					IEnumerable<CargoAttributeLayer2> CargoAttributeLayer2BeforeConvert =
						CargoLayer0.CargoAttributes.Select(AttributeForCargoLayer0 =>
						{
							CargoAttributeLayer2 CargoAttributeLayer2 =
								AttributeForCargoLayer0.ToCargoAttributeLayer2();

							return CargoAttributeLayer2;
						});

					CargoLayer2.CargoCharacteristics =
						CargoLayer0.CargoCharacteristics;
					CargoLayer2.CargoAttributes =
						new List<CargoAttributeLayer2>(
							CargoAttributeLayer2BeforeConvert);

					return CargoLayer2;
				});

			return new List<CargoLayer2>(CargosLayer2BeforeConvert);
		}
		private ObservableCollection<CargoLayer0>
			FilterUnSelectedAttributesForCargo(
				ObservableCollection<CargoLayer0> Cargos)
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
