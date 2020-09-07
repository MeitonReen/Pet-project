using System;
using System.Collections.ObjectModel;

using SharedDTOsByServer.MainMenu;

namespace SharedDTOsByClient.MainMenu
{
	[Serializable]
	public class OrderLayer0
	{
		public int IDOrder { get; set; }
		public DateTime? DateTimeCreate { get; set; }
		public string ReceiptNumberOfOrder { get; set; }
		public bool IsSelected { get; set; }

		public ObservableCollection<CargoLayer2> Cargos { get; set; }
		public ObservableCollection<OrderOnFlightLayer0> OrderOnFligths { get; set; }
	}
}
