﻿using System;
using System.Collections.Generic;
using System.Text;
using lvl2_CommunicatorsBtwLvl1AndLvl3.ClientCommands;
using lvl2_CommunicatorsBtwLvl1AndLvl3.ClientCommands.RolesOfClientCommand;
using lvl2_CommunicatorsBtwLvl1AndLvl3.
	ControllerOfClientCommands.
	RolesOfCreatorOfClientCommands;
using lvl2_CommunicatorsBtwLvl1AndLvl3.DataOfClientCommands;
namespace lvl2_CommunicatorsBtwLvl1AndLvl3
{
	public class DataForRunnerClientCommands
	{
		
		public IExecutorOfClientCommand Command { get; set; }
		public object DataForExecutorClientCommands { get; set; }
	}
}