namespace Layer2.Shared
{
	public interface IExecutorOfClientRequest
	{
		object Execute(object dataFromInputConverter);
		void SetDefault();

		void SetSharedCommunication(object reference);
		void MulticastSendDataAuthorization(object dataAuthorization);
	}
}
