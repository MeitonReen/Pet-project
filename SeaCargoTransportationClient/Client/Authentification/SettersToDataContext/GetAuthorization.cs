using Layer0_Client.Authentification.DataContextForBindingsToWPF;
using Layer0_Client.Shared.SettersToDataContext;

namespace Layer0_Client.Authentification.SettersToDataContext
{
	public class GetAuthorization : AbstractSetterToDataContext
	{
		private DCAuthentification DCAuthentification = null;

		public GetAuthorization(object dCAuthentification)
		{
			DCAuthentification = dCAuthentification as DCAuthentification;
		}

		protected override object SetToDataContext(object presentationData)
		{
			DCAuthentification.Connected = (bool)presentationData;
			return null;
		}
	}
}
