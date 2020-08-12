
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors
{
	public interface IExecutorOfClientRequest
	{
	//Вместо bool добавить обобщённый Result
		public bool Execute(EnumClientRequests RequestID, object dataOfClientRequest);
		public void ClearRequest();
	}
}
