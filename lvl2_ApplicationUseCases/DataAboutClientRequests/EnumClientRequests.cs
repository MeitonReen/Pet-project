
namespace Layer2_ApplicationUseCases.
	DataAboutClientRequest
{
	/// <summary>
	/// Перечисление функций. Контроллер на клиенте знает какую функцию использовать
	/// </summary>
	public enum EnumClientRequests
	{
		CreatingOrder_GetAttributeForCargos,
		CreatingOrder_SetCargosInOrders,
		Get_ClientData,
		Get_ClientOrders,
		Get_OrderDetail
	}
}
