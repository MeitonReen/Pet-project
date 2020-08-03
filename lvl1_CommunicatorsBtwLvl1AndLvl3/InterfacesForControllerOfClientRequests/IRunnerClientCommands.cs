
//RunnerClientRequests знает кто должен выполнить команду клиента
using Layer2_ApplicationUseCases.
	InterfacesForInteractors;
//RunnerClientRequests знает какие данные должен отдать выполнителю команды клиента
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests
{
/// <summary>
/// object Data для запуска в отдельном потоке
/// </summary>
	public interface IRunnerClientRequests
	{
		public void RunClientRequest(
			IExecutorOfApplicationUseCase _executorOfClientRequest,
			DataOfClientRequest _dataClientRequest);
	}

}
