using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

using SharedDTOsByServer.CreatingOrder;

namespace SharedDTOsByClient.CreatingOrder
{
	[Serializable]
	public class CargoLayer0 : INotifyPropertyChanged
	{
		public ObservableCollection<AttributeForCargoLayer0> CargoAttributes
			{ get; set; } = new ObservableCollection<AttributeForCargoLayer0>();
		public CargoCharacteristicsLayer2 CargoCharacteristics
			{ get; set; } = new CargoCharacteristicsLayer2();

		public int Number { get; set; }
		private bool _IsSelected = false;
		public bool IsSelected
		{
			get
			{
				return _IsSelected;
			}
			set
			{
				_IsSelected = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
			}
		}

		public CargoLayer0(int number)
		{
			Number = number;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
