
namespace Layer2_ApplicationUseCases.
	InterfacesForStatesOfInteractors
{
	public interface IExecutorOfClientRequest
	{
	//Вместо bool добавить обобщённый Result
		public object Execute(object dataOfClientRequest);
		public void ClearRequest();
	}
}
