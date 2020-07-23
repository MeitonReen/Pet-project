using System;
using System.Collections.Generic;
using System.Text;

namespace lvl2_ApplicationUseCases.
	Interactors.
	ToolsForInteractors.
	CommonForClientCommands.
	InterfacesForClientCommands.
	IExecutorOfClientCommand.
	Data
{
	/// <summary>
	///	Данные команды клиента 
	/// </summary>
	public class DataOfClientCommand
	{
		public EnumClientCommands CommandID { get; set; }
		public object DataForExecutorClientCommands { get; set; }
	}
}
