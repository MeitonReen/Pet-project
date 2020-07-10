using System;
using System.Collections.Generic;
using System.Text;
using lvl2_CommunicatorsBtwLvl1AndLvl3.DataOfClientCommands;

namespace lvl2_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientCommands.RolesOfCreatorOfClientCommands
{
	public interface IReceiverDataOfClientCommands
	{
		public int Receive(DataForReceiverDataClientCommands Data);
	}
}
