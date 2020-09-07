
using System;
using System.Windows;

namespace Layer0_Client.Shared.Create.Views
{
	public abstract class CreatorOfViewAbstract
	{
		private Window View = null;

		public Window CreateAndShow()
		{
			View = CreateView();
			View?.Show();

			return View;
		}

		public abstract Type TypeOfCreationView();
		protected abstract Window CreateView();
	}
}
