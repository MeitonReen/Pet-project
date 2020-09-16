using System;
using System.Collections.Generic;
using System.Linq;

namespace Layer2.Shared.SimpleStateMachine
{
	public static class FromState<TStateID> where TStateID : Enum
	{
		public static State<TStateID> Null { get; set; }
		public static State<TStateID> Anywhere { get; set; }

		static FromState()
		{
			List<TStateID> StateIDs = Enum.GetValues(typeof(TStateID)).Cast<TStateID>().ToList();

			TStateID StateIDForNullState = GetFreeSpaceInEnum(StateIDs.ToArray());
			StateIDs.Add(StateIDForNullState);

			TStateID StateIDForAnywhereState = GetFreeSpaceInEnum(StateIDs.ToArray());

			Null = new State<TStateID>(StateIDForNullState, null);
			Anywhere = new State<TStateID>(StateIDForAnywhereState, null);
		}

		private static TStateID GetFreeSpaceInEnum(TStateID[] stateIDs)
		{
			//Поддерживаем только базовый Enum'а - int. Количество состояний в этом приложении
			//не может превышать пределы int32
			bool IsFound = false;
			TStateID Result = (TStateID)(object)-1;

			for(int i = Int32.MinValue; i < Int32.MaxValue && !IsFound; i++)
			{
				TStateID TStateIDi = (TStateID)(object)i;
				if (!stateIDs.Contains(TStateIDi))
				{
					IsFound = true;
					Result = TStateIDi;
				}
			}

			if (!IsFound)
			{
				throw new ArgumentOutOfRangeException();
			}

			return Result;
		}
		
	}
}
