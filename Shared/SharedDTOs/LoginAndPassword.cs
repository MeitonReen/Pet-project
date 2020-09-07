using System;
using System.Collections.Generic;
using System.Text;

namespace SharedDTOs
{
	[Serializable]
	public class LoginAndPassword
	{
		public string Login { get; set; }
		public string Password { get; set; }
	}
}
