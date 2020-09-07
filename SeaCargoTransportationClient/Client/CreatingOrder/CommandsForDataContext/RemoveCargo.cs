using System;
using System.Linq;
using System.Threading;

using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using Layer0_Client.Shared.CommandsForDataContexts;
using SharedDTOsByClient.CreatingOrder;

namespace Layer0_Client.CreatingOrder.CommandsForDataContext
{
	public class RemoveCargo : AbstractWPFCommandWithPostToWPF
	{
		private DCCreatingOrder DCCreatingOrder = null;

		public RemoveCargo(
			DCCreatingOrder dCCreatingOrder,
			SynchronizationContext synchronizationContext,
			Predicate<object> canExecute = null)
		:base(synchronizationContext, canExecute)
		{
			DCCreatingOrder = dCCreatingOrder;
		}

		protected override void ExecuteInWPF(object parameter)
		{
			if (DCCreatingOrder.Cargos.Any())
			{
				CargoLayer0 CargoIsSelected = DCCreatingOrder.Cargos.FirstOrDefault(
					Cargo => Cargo.IsSelected);

				DCCreatingOrder.Cargos.Remove(CargoIsSelected);

				if (DCCreatingOrder.Cargos.LastOrDefault() != null)
				{
					DCCreatingOrder.Cargos.LastOrDefault().IsSelected = true;
				}
			}
		}
	}
}
