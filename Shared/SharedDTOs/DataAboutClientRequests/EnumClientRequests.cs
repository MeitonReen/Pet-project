using System;

namespace SharedDTOs.DataAboutClientRequests
{
	[Serializable]
	public enum EnumClientRequests
	{
		GetAuthorization,	
		GetAttributeForCargos,
		GetFlightsSchedule,
		SetNewOrder,
		GetClientData,
		GetClientOrders,
		SetCancelOrder
	}
}
