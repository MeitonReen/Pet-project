using Layer1.Shared.InputDataConverters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer1.MainMenu.InputDataConverters
{
	public class SetCancelOrder : AbstractInputConverter
	{
		protected override object Convert(object data)
		{
			object IDOrder = data;

			return IDOrder;
		}
	}
}
