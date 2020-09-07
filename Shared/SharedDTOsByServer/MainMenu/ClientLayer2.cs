using System;

namespace SharedDTOsByServer.MainMenu
{
	[Serializable]
	public class ClientLayer2
	{
		public int IDСlient { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public string Email { get; set; }
	}
}
