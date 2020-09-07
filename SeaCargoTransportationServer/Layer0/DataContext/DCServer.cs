using System.ComponentModel;
using System.Windows.Input;

using Layer0.Commands;
using Layer1.Shared.MainController;

namespace Layer0.DataContext
{
	public class DCServer : INotifyPropertyChanged
	{
		public bool ServerStatus
		{
			get
			{
				return _ServerStatus;
			}
			set
			{
				_ServerStatus = value;
				PropertyChanged(this, new PropertyChangedEventArgs("ServerStatus"));
			}
		}

		public ICommand ServerStart
		{
			get
			{
				return new ServerStart(ControllerOfBL);	
			}
		}

		public ICommand ServerStop
		{
			get
			{
				return new ServerStop(ControllerOfBL);	
			}
		}

		private BLController ControllerOfBL = new BLController();
		private bool _ServerStatus = false;

		public DCServer()
		{
			ControllerOfBL.ChangeServerStatus += ControllerOfBL_ChangeServerStatus;
		}

		private void ControllerOfBL_ChangeServerStatus(object sender, bool e)
		{
			ServerStatus = e;
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
