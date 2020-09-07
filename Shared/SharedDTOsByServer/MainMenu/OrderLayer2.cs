using System;
using System.Collections.Generic;

namespace SharedDTOsByServer.MainMenu
{
	[Serializable]
	public class OrderLayer2
	{
		public int IDOrder { get; set; }
		public DateTime? DateTimeCreate { get; set; }
		public string ReceiptNumberOfOrder { get; set; }

		public List<CargoLayer2> Cargos { get; set; }
		public List<OrderOnFlightLayer2> OrderOnFligths { get; set; }
	}
}
