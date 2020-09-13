using System.Collections.Generic;

using Shared;
using SharedDTOs.DataAboutClientRequests;

namespace Layer2.Shared
{
	public interface ILinkerInteractorStates
	{
		KeyValuePair<EnumClientRequests, IHandler>[] LinkStates();
	}
}
