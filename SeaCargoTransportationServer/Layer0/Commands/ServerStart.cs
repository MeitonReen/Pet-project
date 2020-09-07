using System;
using System.Threading.Tasks;

using Layer1.Shared.MainController;

namespace Layer0.Commands
{
	public class ServerStart : WPFCommand
	{
		private BLController ControllerOfBL = null;

		public ServerStart(BLController controllerOfBL)
		{
			ControllerOfBL = controllerOfBL;
		}
		protected override Func<object, bool> _CanExecute { get; set; }

		public override void Execute(object parameter)
		{
			Task.Factory.StartNew(ControllerOfBL.ServerStart);
		}
	}
}
