using System;
using System.Collections.Generic;
using System.Text;
using lvl2_CommunicatorsBtwLvl1AndLvl3.ClientCommands;

namespace lvl2_CommunicatorsBtwLvl1AndLvl3.DataOfClientCommands
{
	public class DataForReceiverDataClientCommands
	{
		
		public EnumClientCommands IDCommand { get; set; }
		public object Data { get; set; }
	}
}
