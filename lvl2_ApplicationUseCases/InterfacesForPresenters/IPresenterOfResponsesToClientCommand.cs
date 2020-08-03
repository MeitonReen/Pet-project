
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;

namespace Layer2_ApplicationUseCases.InterfacesForPresenters
{
	public interface IPresenterOfResponsesToClientRequest
	{
		void PresentAndSend(
			EnumClientRequests RequestID, 
			object responseDataFromInteractor);
	}
}
