using System;
using System.ComponentModel;
using System.Windows.Input;

using Layer0_Client.Authentification.CommandsForDataContexts;
using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.Authentification.DataContextForBindingsToWPF
{
	public class DCAuthentification : AbstractDataContext, INotifyPropertyChanged
	{
		#region Свойства
		public string Login { get; set; } = "";
		public string Password { get; set; } = "";
		#endregion

		#region Команды
		public ICommand AuthentificationApp
		{
			get
			{
				return new AuthentificationApp(ClientController, this);
			}
		}
		#endregion

		#region Служебное
		private bool _Connected = true;
		public bool Connected
		{
			get
			{
				return _Connected;
			}
			set
			{
				_Connected = value;
				ChangeConnectionStatus?.Invoke(this, _Connected);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Connected"));
			}
		}

		protected override EnumClientRequests[] DefineClientRequestIDsRunningInDataContext()
		{
			return new EnumClientRequests[]
			{
				EnumClientRequests.GetAuthorization
			};
		}

		protected override ICommand[] DefineCommandsToExecuteDuringInitialization()
		{
			return null;
		}

		public event EventHandler<bool> ChangeConnectionStatus;
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
}
