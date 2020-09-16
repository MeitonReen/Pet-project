using System.Collections.Generic;
using System.Linq;

namespace Layer2.Shared.SimpleStateMachine
{
	public class SharedBufferForStates<TStateID>
	{
		public List<TStateID> SuccessExecutedStates { get; set; } = new List<TStateID>();
		public SharedBufferForStates(TStateID nullState)
		{
			SuccessExecutedStates.Add(nullState);
		}
		public void ExcludeItems(params TStateID[] StateIDs)
		{
			if (StateIDs != null)
			{
				SuccessExecutedStates = SuccessExecutedStates.Except(StateIDs).ToList();
			}
		}
	}
}
