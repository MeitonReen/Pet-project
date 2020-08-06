
using System.Collections.Generic;
using System.Threading.Tasks;

using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	InterfacesForInteractors;

namespace Layer1_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientRequests
{
	public class ControllerOfClientRequests:
		IReceiverDataOfClientRequests,
		IRunnerClientRequests
	{
		private Dictionary<EnumClientRequests, IExecutorOfApplicationUseCase>
			ClientRequestsDictionary = new 
				Dictionary<EnumClientRequests, IExecutorOfApplicationUseCase>();
	
		public void RegistrationOfRequest(
			EnumClientRequests RequestID, IExecutorOfApplicationUseCase ExecutorClientRequest)
		{
			ClientRequestsDictionary.Add(RequestID, ExecutorClientRequest);
		}
		
		public int Receive(DataOfClientRequest dataClientRequest)
		{
			IExecutorOfApplicationUseCase ExecutorOfClientRequest =
				ClientRequestsDictionary[dataClientRequest.RequestID];

			RunClientRequest(ExecutorOfClientRequest, dataClientRequest);
			//Добавить проверочки, исключения
			return 0;
		}
		
		public void RunClientRequest(
			IExecutorOfApplicationUseCase executorOfClientRequest,
			DataOfClientRequest dataClientRequest)
		{
			object data = dataClientRequest;
			Task NewTask = Task.Factory.StartNew( () =>
				{
					executorOfClientRequest.Execute(dataClientRequest);
				}
			);

	
		}
	}
}
