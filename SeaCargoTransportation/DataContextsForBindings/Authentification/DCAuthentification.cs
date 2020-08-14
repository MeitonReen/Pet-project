using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Layer2_ApplicationUseCases.
	TruncatedDataFromGatewayToDatabaseForLayer2.
	Shared;
using Layer0_Client.CommandForViews.Authentification;

namespace Layer0_Client.DataContextsForBindings.Authentification
{
	public class DCAuthentification
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public ClientLayer2 Client { get; set; }

		public ICommand AuthentificationApp
		{
			get
			{
				return new AuthentificationApp();
			}
		}
		public DCAuthentification()
		{
			//Промежуточная версия
			Client = new ClientLayer2();
			Client.IDСlient = 1;
		}
	}
}
