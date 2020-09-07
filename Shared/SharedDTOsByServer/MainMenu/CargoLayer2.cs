using System;

namespace SharedDTOsByServer.MainMenu
{
	[Serializable]
	public class CargoLayer2
	{
		public int IDCargosInOrders { get; set; }
		public decimal Weight { get; set; }
		public decimal Amount { get; set; }
	}
}
