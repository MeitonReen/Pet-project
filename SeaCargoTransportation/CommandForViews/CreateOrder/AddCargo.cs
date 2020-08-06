
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer0_Client.CommandForViews.Shared;

namespace Layer0_Client.CommandForViews.CreateOrder
{
	public class AddCargo : WPFCommand, ICommand
	{
		public ObservableCollection<CargoLayer0> Cargos = null;

		private ObservableCollection<AttributeForCargoLayer0>
			GettedAttributesForCargo = null;

		public AddCargo(
			ObservableCollection<CargoLayer0> cargos,
			ObservableCollection<AttributeForCargoLayer0> 
				gettedAttributesForCargo)
			: base()
		{
			Cargos = cargos;
			GettedAttributesForCargo = gettedAttributesForCargo;

			_CanExecute =
				(obj) =>
				{
					bool Allow = false;
					if ((Cargos != null) && (GettedAttributesForCargo != null))
					{
						if (GettedAttributesForCargo.Any())
						{
							Allow = true;
						}
					}

					return Allow;
				};
		}

		private int GetMaxNumberCargos()
		{
			return Cargos.Max(Cargo => Cargo.Number);
		}

		private ObservableCollection<AttributeForCargoLayer0>
			CopyAttributeForCargoLayer0(
				ObservableCollection<AttributeForCargoLayer0> original)
		{
			ObservableCollection<AttributeForCargoLayer0>
				Copied =
					new ObservableCollection<AttributeForCargoLayer0>();

			foreach (AttributeForCargoLayer0 OriginalItem in
				original)
			{
				AttributeForCargoLayer0 NewItemToCopied =
					(AttributeForCargoLayer0)OriginalItem.Clone();
				Copied.Add(NewItemToCopied);
			}

			return Copied;
		}

		public override void Execute(object parameter)
		{
			CargoLayer0 NewCargo = new CargoLayer0(GetMaxNumberCargos() + 1);
			NewCargo.CargoAttributes = CopyAttributeForCargoLayer0(
				GettedAttributesForCargo);
			NewCargo.CargoCharacteristics = new CargoCharacteristicsLayer0();

			Cargos.Add(NewCargo);
		}
	}
}
