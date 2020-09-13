using System;
using System.Windows;
using System.Collections.Generic;

using Layer0_Client.CreatingOrder.CreateViews;

namespace Layer0_Client.Shared.Create.Views
{
	public class FactoryOfViews
	{
		private Dictionary<string, CreatorOfViewAbstract> CreatorsOfViews = null;
		private Dictionary<string, Type> TypesOfCreationView = 
			new Dictionary<string, Type>();

		public FactoryOfViews()
		{
			CreatorsOfViews = new Dictionary<string, CreatorOfViewAbstract>()
			{
				{
					"VAuthentification",
					new CreateAuthentification()
				},
				{
					"VCreatingOrder",
					new CreateCreatingOrder()
				},
				{
					"VMainMenu",
					new CreateMainMenu()
				},
				{
					"VOrderDetails",
					new CreateOrderDetails()
				}
			};
			
			foreach(KeyValuePair<string, CreatorOfViewAbstract> DictItem in CreatorsOfViews)
			{
				TypesOfCreationView.Add(DictItem.Key, DictItem.Value.TypeOfCreationView());
			}
		}
		public void Close(string viewNameToClose)
		{	
			if (TypesOfCreationView.ContainsKey(viewNameToClose))
			{
				Type SearchTypeWindow = TypesOfCreationView[viewNameToClose];
				Window SearchWindow = null;

				for (int i = 0;
					(i < Application.Current.Windows.Count) &&
					(SearchWindow == null);
					i++)
				{
					if (Application.Current.Windows[i].GetType() ==
						SearchTypeWindow)
					{
						SearchWindow = Application.Current.Windows[i];
					}
				}

				SearchWindow?.Close();
			}
		}
		public void CreateAndShow(string newViewName)
		{
			if (CreatorsOfViews.ContainsKey(newViewName))
			{
				CreatorsOfViews[newViewName].CreateAndShow();
			}
		}
		public void CreateShowAndGoToNewView(string newViewName)
		{
			if (CreatorsOfViews.ContainsKey(newViewName))
			{
				Window CurrentWindow = Application.Current.MainWindow;

				Window NewView = CreatorsOfViews[newViewName].CreateAndShow();

				Application.Current.MainWindow = NewView;
				CurrentWindow?.Close();
			}
		}
	}
}
