
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer2_ApplicationUseCases.
	InterfacesForInteractors
{
	public interface IExecutorOfApplicationUseCase
	{
	//Вместо bool добавить обобщённый Result
		public bool Execute(DataOfClientRequest dataOfClientRequest);
	}
}
