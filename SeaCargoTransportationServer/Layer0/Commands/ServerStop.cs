using System;
using System.Threading.Tasks;

using Layer1.Shared.MainController;

namespace Layer0.Commands
{
	public class ServerStop : WPFCommand
	{
		private BLController ControllerOfBL = null;

		public ServerStop(BLController controllerOfBL)
		{
			ControllerOfBL = controllerOfBL;
		}
		protected override Func<object, bool> _CanExecute { get; set; }

		public override void Execute(object parameter)
		{
			ControllerOfBL.ServerStop();
		}
	}
}
