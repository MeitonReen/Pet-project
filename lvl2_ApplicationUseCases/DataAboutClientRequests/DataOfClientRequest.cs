
namespace Layer2_ApplicationUseCases.
	DataAboutClientRequest
{
	/// <summary>
	///	Данные команды клиента 
	/// </summary>
	public class DataOfClientRequest
	{
		public EnumClientRequests RequestID { get; set; }
		public object DataForExecutorClientRequests { get; set; }
	}
}
