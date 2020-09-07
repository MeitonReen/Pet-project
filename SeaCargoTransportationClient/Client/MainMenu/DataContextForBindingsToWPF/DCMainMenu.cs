using System.Collections.ObjectModel;
using System.Windows.Input;

using Layer0_Client.CreatingOrder.DataContextForBindingsToWPF;
using Layer0_Client.Shared.CommandsForDataContexts;
using System.ComponentModel;
using Layer0_Client.MainMenu.CommandsForDataContext;
using System.Threading;
using SharedDTOsByClient.MainMenu;
using SharedDTOsByServer.MainMenu;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.MainMenu.DataContextForBindingsToWPF
{
	public class DCMainMenu : AbstractDataContext, INotifyPropertyChanged
	{
		#region Поля
		private ClientLayer2 _Client = new ClientLayer2();
		private ObservableCollection<OrderLayer0> _Orders =
			new ObservableCollection<OrderLayer0>();
		private OrderLayer0 _SelectedOrder = null;
		#endregion

		#region Свойства
		public ObservableCollection<OrderLayer0> Orders
		{
			get
			{
				return _Orders;
			}
			set
			{
				_Orders = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Orders"));
			}
		}

		public ClientLayer2 Client
		{
			get
			{
				return _Client;
			} 
			set
			{
				_Client = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Client"));
			}
		}

		public OrderLayer0 SelectedOrder
		{
			get
			{
				return _SelectedOrder;
			}
			set
			{
				_SelectedOrder = value;
				PropertyChanged?.Invoke(
					this,
					new PropertyChangedEventArgs("SelectedOrder"));
			}
		}
		#endregion
		
		#region Команды

		public ICommand SendRequestsForInitializeThisDataContext
		{
			get
			{
				return new RequestToBL(
					ClientController,
					null,
					EnumClientRequests.GetClientData,
					EnumClientRequests.GetClientOrders);
			}
		}
		public ICommand CreateOrder
		{
			get
			{
				return new ShowView("VCreatingOrder", SynchronizationContext.Current);
			}
		}
		public ICommand RefreshClientDataAndClientOrders
		{
			get
			{
				return new RequestToBL(
					ClientController,
					null,
					EnumClientRequests.GetClientData,
					EnumClientRequests.GetClientOrders);
			}
		}
		public ICommand OrderCancel
		{
			get
			{
				return new OrderCancel(
					ClientController, 
					this,
					SynchronizationContext.Current);
			}
		}
		public ICommand ShowOrderDetails
		{
			get
			{
				//return new Check(this);
				return new ShowView("VOrderDetails", SynchronizationContext.Current);
			}
		}
		public ICommand BackFromOrderDetails
		{
			get
			{
				return new CloseView("VOrderDetails", SynchronizationContext.Current);
			}
		}
		#endregion

		#region Служебное
		protected override EnumClientRequests[] DefineClientRequestIDsRunningInDataContext()
		{
			return new EnumClientRequests[]
			{
				EnumClientRequests.GetClientData,
				EnumClientRequests.GetClientOrders,
				EnumClientRequests.SetCancelOrder
			};
		}
		protected override ICommand[] DefineCommandsToExecuteDuringInitialization()
		{
			return new ICommand[]
			{
				SendRequestsForInitializeThisDataContext
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
}
