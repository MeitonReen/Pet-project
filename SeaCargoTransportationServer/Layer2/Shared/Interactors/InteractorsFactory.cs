
using Layer2.Shared.SimpleStateMachine;
using Shared.Dictionary;
using SharedDTOs.DataAboutClientRequests;

namespace Layer2.Shared.Interactors
{
	public class InteractorsFactory
	{
		private DictionaryOfHandlers<EnumClientRequests> Interactors =
			new DictionaryOfHandlers<EnumClientRequests>();

		private SharedBufferForStates<EnumClientRequests> SharedBufferForInteractors =
			new SharedBufferForStates<EnumClientRequests>();

		public DictionaryOfHandlers<EnumClientRequests> CreateInteractors()
		{
			CreateAndLink();

			return Interactors;
		}

		private void CreateAndLink()
		{
			CreatingOrder.InteractorsLinker LinkerCreatingOrder =
				new CreatingOrder.InteractorsLinker(SharedBufferForInteractors);
			MainMenu.InteractorsLinker LinkerMainMenu =
				new MainMenu.InteractorsLinker(SharedBufferForInteractors);
			Authentification.InteractorsLinker LinkerAuthentification =
				new Authentification.InteractorsLinker(SharedBufferForInteractors);

			Interactors.AddRange(LinkerCreatingOrder.LinkStates());
			Interactors.AddRange(LinkerMainMenu.LinkStates());
			Interactors.AddRange(LinkerAuthentification.LinkStates());
		}

	}
}
