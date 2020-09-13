using Layer1.Shared.InputDataConverters;
using SharedDTOsByServer.CreatingOrder;

namespace Layer1.CreatingOrder.InputDataConverters
{
	public class SetNewOrderConverter : AbstractInputConverter
	{
		protected override object Convert(object data)
		{
			return data as NewOrderLayer2;
		}
	}
}
