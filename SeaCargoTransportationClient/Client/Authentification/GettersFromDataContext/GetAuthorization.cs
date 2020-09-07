
using Layer0_Client.Authentification.DataContextForBindingsToWPF;
using Layer0_Client.Shared.ClientPresenters;
using SharedDTOs;

namespace Layer0_Client.Authentification.GettersFromDataContext
{
	public class GetAuthorization : AbstractGetterFromDataContext
	{
		private DCAuthentification DCAuthentification = null;

		public GetAuthorization(object dCAuthentification)
		{
			DCAuthentification = dCAuthentification as DCAuthentification;
		}
		protected override object GetFromDataContext()
		{
			return new LoginAndPassword()
			{
				Login = DCAuthentification.Login,
				Password = DCAuthentification.Password
			};
		}
	}
}
