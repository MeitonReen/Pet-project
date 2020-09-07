namespace Layer1.Shared
{
	public interface IPresentersOfDataToOutput
	{
		object PresentAndSend(object responseDataFromInteractor);
	}
}
