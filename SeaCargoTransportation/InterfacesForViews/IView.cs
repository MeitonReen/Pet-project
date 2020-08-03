
using System;
using System.Collections.Generic;

namespace Layer0_Client.InterfacesForViews
{
	public interface IView
	{
		//Придумать List<event>? И динамически создавать обработчики в
		//Client Controller в зависимости от ClientRequestID, чтобы Send
		//делать в Application универсально
		//Либо перейти на команды
		event EventHandler StartClientRequest;
	}
}
