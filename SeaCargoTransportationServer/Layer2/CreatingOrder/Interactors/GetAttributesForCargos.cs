
using System.Collections.Generic;
using System.Linq;

using Layer2.Shared.GatewayToDatabase;
using Layer2.Shared.Interactors;

namespace Layer2.CreatingOrder.Interactors
{
	public class GetAttributesForCargos : InteractorAbstract
	{
		public override object Execute(object dataFromInputConverter)
		{
			using (GetDataBase())
			{
				List<AttributesForCargos> AttributesForCargos =
					Database.AttributesForCargos.ToList();
				
				Database = null;
				return AttributesForCargos;
			}
		}

		public override void SetDefault()
		{
		}

	}
}
