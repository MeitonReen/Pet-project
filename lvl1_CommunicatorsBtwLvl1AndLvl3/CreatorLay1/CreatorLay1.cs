using System;
using System.Collections.Generic;
using System.Text;
using Layer1_CommunicatorsBtwLvl1AndLvl3.ControllerOfClientRequests;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForReceiverOfResponsesToClient;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	InterfacesForControllerOfClientRequests;
using Layer2_ApplicationUseCases.
	DataAboutClientRequest;
using Layer2_ApplicationUseCases.
	Interactors.
	CreatingOrder;
using Layer1_CommunicatorsBtwLvl1AndLvl3.
	PresentersOfResponsesToClientRequests;

namespace Layer1_CommunicatorsBtwLay0AndLay2.CreatorLay1
{
	public class CreatorLay1
	{
		private ControllerOfClientRequests ClientRequestsToApplication = null;
		private CreatingOrder CreatingOrder = null;
		private AttributesForCargosPresenter AttributesForCargosPresenter = 
			null;
		private IReceiverOfResponsesToClient ReceiverDataOfClientCommands = 
			null;

		public CreatorLay1()
		{
			ClientRequestsToApplication =
				new ControllerOfClientRequests();
		}

		private void Create_CreateOrder()
		{
			AttributesForCargosPresenter =
				new AttributesForCargosPresenter(ReceiverDataOfClientCommands);
			CreatingOrder = new CreatingOrder(AttributesForCargosPresenter);

			ClientRequestsToApplication.RegistrationOfRequest(
				EnumClientRequests.CreatingOrder_GetAttributeForCargos,
				CreatingOrder);
		}

		public void LinkToReceiverDataOfClientCommands(
			IReceiverOfResponsesToClient receiverDataOfClientCommands)
		{
			ReceiverDataOfClientCommands = receiverDataOfClientCommands;
			
			Create_CreateOrder();
		}

		public IReceiverDataOfClientRequests 
			GetReceiverDataOfClientRequest()
		{
			return ClientRequestsToApplication;
		}
	}
}
