using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using Layer0_Client.Shared.CommandsForDataContexts;
using SharedDTOsByClient.CreatingOrder;
using SharedDTOsByServer.CreatingOrder;

namespace Layer0_Client.CreatingOrder.CommandsForDataContext
{
	public class AddCargo : AbstractWPFCommandWithPostToWPF
	{
		private DCCreatingOrder DCCreatingOrder = null;

		public AddCargo(
			DCCreatingOrder dCCreatingOrder,
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			DCCreatingOrder = dCCreatingOrder;
		}

		private int GetMaxNumberCargos()
		{
			return (DCCreatingOrder?.Cargos?.Any() ?? new bool?(false)).Value ?
				DCCreatingOrder.Cargos.Max(Cargo => Cargo.Number) : 0;
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

		protected override void ExecuteInWPF(object parameter)
		{
			CargoLayer0 NewCargo = new CargoLayer0(GetMaxNumberCargos() + 1);
			NewCargo.CargoAttributes = CopyAttributeForCargoLayer0(
				DCCreatingOrder.GettedAttributesForCargo);
			NewCargo.CargoCharacteristics = new CargoCharacteristicsLayer2();
			NewCargo.IsSelected = true;

			DCCreatingOrder.Cargos.Add(NewCargo);
		}
	}
}
