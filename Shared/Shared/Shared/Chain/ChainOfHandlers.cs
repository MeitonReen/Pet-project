using System;
using System.Linq;

namespace Shared.Chain
{
	public class ChainOfHandlers
	{
		private ChainOfHandlers NextHandler = null;
		private IHandler Handler = null;

		public ChainOfHandlers(params IHandler[] handlers)
		{
			Handler = handlers[0];

			IHandler[] SendHandlersToNext = new IHandler[handlers.Length - 1];
			Array.Copy(handlers, 1, SendHandlersToNext, 0, handlers.Length - 1);

			if (SendHandlersToNext.Any())
			{
				NextHandler = new ChainOfHandlers(SendHandlersToNext);
			}
		}

		public void Handle(object data)
		{
			if (Handler != null)
			{
				Handler.Handle(data);
			}
			if (NextHandler != null)
			{
				NextHandler.Handle(data);
			}
		}
	}
}
