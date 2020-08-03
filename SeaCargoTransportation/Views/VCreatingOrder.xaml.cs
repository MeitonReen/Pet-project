
using System;
using System.Windows;
using System.Collections.Generic;

using Layer0_Client.InterfacesForViews;

namespace Layer0_Client.Views
{
	/// <summary>
	/// Логика взаимодействия для VCreatingOrder.xaml
	/// </summary>
	
	public partial class VCreatingOrder : Window, ICreatingOrder
	{
		
		
		public VCreatingOrder()
		{
			InitializeComponent();

		}

		public event EventHandler GetAttributeForCargos;
	
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			GetAttributeForCargos?.Invoke(sender, e);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
