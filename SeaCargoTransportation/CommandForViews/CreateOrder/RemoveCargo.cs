
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

using Layer1_CommunicatorsBtwLay0AndLay2.
	TruncatedDataFromGatewayToDatabaseForLayer0;
using Layer0_Client.CommandForViews.Shared;

namespace Layer0_Client.CommandForViews.CreateOrder
{
	public class RemoveCargo : WPFCommand
	{
		public ObservableCollection<CargoLayer0> Cargos = null;
		private ObservableCollection<AttributeForCargoLayer0>
			GettedAttributesForCargo = null;

		public RemoveCargo(
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

		public override void Execute(object parameter)
		{
			if (Cargos != null)
			{
				if (Cargos.Any())
				{
					CargoLayer0 CargoIsSelected = Cargos.First(Cargo =>
						Cargo.IsSelected == true);
					;
					Cargos.Remove(CargoIsSelected);
				}
			}
			
		}
	}
}
