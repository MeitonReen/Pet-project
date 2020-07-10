using System;
using System.Collections.Generic;
using System.Text;

namespace lvl2_CommunicatorsBtwLvl1AndLvl3.ClientCommands.RolesOfClientCommand
{
	public interface IExecutorOfClientCommand
	{
		public void Execute(object DataOfClientCommand);
	}
}
