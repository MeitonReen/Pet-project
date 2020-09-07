using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;

using Layer0_Client.Shared.CommandsForDataContexts;
using Layer0_Client.CreatingOrder.CommandsForDataContext;
using System.ComponentModel;
using System;
using System.Threading;
using SharedDTOsByServer.CreatingOrder;
using SharedDTOsByClient.CreatingOrder;
using SharedDTOs.DataAboutClientRequests;

namespace Layer0_Client.CreatingOrder.DataContextForBindingsToWPF
{
	public class DCCreatingOrder : AbstractDataContext, INotifyPropertyChanged
	{
		#region Поля
		private ObservableCollection<CargoLayer0> _Cargos =
			new ObservableCollection<CargoLayer0>();

		private ObservableCollection<AttributeForCargoLayer0> _GettedAttributesForCargo =
			new ObservableCollection<AttributeForCargoLayer0>();
		private ObservableCollection<FlightScheduleLayer2> _GettedFlightsSchedule =
			new ObservableCollection<FlightScheduleLayer2>();
		private CargoLayer0 _SelectedCargo = null;
		#endregion

		#region Свойства
		public ObservableCollection<CargoLayer0> Cargos
		{
			get
			{
				return _Cargos;
			}
			set
			{
				_Cargos = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cargos"));
			}
		}
		public ObservableCollection<AttributeForCargoLayer0> GettedAttributesForCargo
		{
			get
			{
				return _GettedAttributesForCargo;
			}
			set
			{
				_GettedAttributesForCargo = value;
				PropertyChanged?.Invoke(
					this, 
					new PropertyChangedEventArgs("GettedAttributesForCargo"));
			}
		}
		public ObservableCollection<FlightScheduleLayer2> GettedFlightsSchedule
		{
			get
			{
				return _GettedFlightsSchedule;
			}
			set
			{
				_GettedFlightsSchedule = value;
				PropertyChanged?.Invoke(
					this, 
					new PropertyChangedEventArgs("GettedFlightsSchedule"));
			}
		}
		public CargoLayer0 SelectedCargo
		{
			get
			{
				return _SelectedCargo;
			}
			set
			{
				_SelectedCargo = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCargo"));
			}
		}
		#endregion

		#region Команды

		public ICommand AddCargo
		{
			get
			{
				return new AddCargo(this, SynchronizationContext.Current, parameter =>
					((Cargos != null &
					GettedAttributesForCargo?.Any() &
					GettedFlightsSchedule?.Any()) ?? new bool?(false)).Value);
			}
		}
		public ICommand RemoveCargo
		{
			get
			{
				return new RemoveCargo(this, SynchronizationContext.Current, parameter =>
					(Cargos?.Any() ?? new bool?(false)).Value);
			}
		}
		public ICommand SendRequestsForInitializeThisDataContext
		{
			get
			{
				return new RequestToBL(ClientController, null,
					EnumClientRequests.GetAttributeForCargos,
					EnumClientRequests.GetFlightsSchedule);
			}
		}
		public ICommand RefreshFlightSchedule
		{
			get
			{
				return new RequestToBL(ClientController, null,
					EnumClientRequests.GetFlightsSchedule);
			}
		}
		public ICommand CreateOrderAndCloseView
		{
			get
			{
				return new CreateOrderAndCloseView(ClientController, SynchronizationContext.Current);
			}
		}
		public ICommand Back
		{
			get
			{
				return new CloseView("VCreatingOrder", SynchronizationContext.Current);
			}
		}
		#endregion

		#region Служебное

		protected override EnumClientRequests[] DefineClientRequestIDsRunningInDataContext()
		{
			return new EnumClientRequests[]
			{
				EnumClientRequests.GetAttributeForCargos,
				EnumClientRequests.GetFlightsSchedule,
				EnumClientRequests.SetNewOrder
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
