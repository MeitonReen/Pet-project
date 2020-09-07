
using System.Collections.Generic;
using System.Linq;
using SharedDTOs;

namespace Shared.Dictionary
{
	public class DictionaryOfHandlers<TKey>
	{
		private Dictionary<TKey, IHandler> Handlers = new Dictionary<TKey, IHandler>();

		public DictionaryOfHandlers()
		{
			Handlers = new Dictionary<TKey, IHandler>();
		}
		public DictionaryOfHandlers(Dictionary<TKey, IHandler> handlers)
		{
			Handlers = handlers;
		}
		public DictionaryOfHandlers(params KeyValuePair<TKey, IHandler>[] handlers)
		{
			foreach (KeyValuePair<TKey, IHandler> HandlerItem in handlers)
			{
				Handlers.Add(HandlerItem.Key, HandlerItem.Value);
			}
		}
		public DictionaryOfHandlers(params KeyAndData[] items)
		{
			Handlers = new Dictionary<TKey, IHandler>();
			foreach (KeyAndData Item in items)
			{
				Handlers.Add((TKey)Item.Key, (IHandler)Item.Data);
			}
		}

		public void ExcludeByKeys(params TKey[] keys)
		{
			Handlers = Handlers.Where(DictItem => keys.Contains(DictItem.Key)).
				ToDictionary(DictItem => DictItem.Key, DictItem => DictItem.Value);
		}

		public void MulticastSendServiceData(object data)
		{
			foreach(KeyValuePair<TKey, IHandler> DictItem in Handlers)
			{
				DictItem.Value.MulticastSendServiceData(data);
			}
		}

		public void AddRange(params KeyValuePair<TKey, IHandler>[] handlers)
		{
			foreach (KeyValuePair<TKey, IHandler> handlerItem in handlers)
			{
				Add(handlerItem);
			}
		}
		public void Add(KeyValuePair<TKey, IHandler> handlerItem)
		{
			Add(handlerItem.Key, handlerItem.Value);
		}

		public void Add(TKey key, IHandler handler)
		{
			Handlers.Add(key, handler);
			Handlers[key].SetSharedCommunication(this);
		}

		public KeyValuePair<TKey, object>[]
			HandleWithoutKeyInto_WithKeyOut(KeyValuePair<TKey, object>[] keysAndDatas)
		{
			List<KeyValuePair<TKey, object>> Ress = new List<KeyValuePair<TKey, object>>();

			foreach (KeyValuePair<TKey, object> KeyAndData in keysAndDatas)
			{
				Ress.Add(HandleWithoutKeyInto_WithKeyOut(KeyAndData));
			}

			return Ress.ToArray();
		}
		public KeyValuePair<TKey, object>
			HandleWithoutKeyInto_WithKeyOut(KeyValuePair<TKey, object> keyAndData)
		{
			TKey Key = keyAndData.Key;

			object Data = null;
			if (Handlers.ContainsKey(Key))
			{
				Data = Handlers[Key].Handle(keyAndData.Value);
			}
			return new KeyValuePair<TKey, object>(Key, Data);
		}

		public KeyValuePair<TKey, object>[]
			HandleWithKeyInto_WithKeyOut(KeyValuePair<TKey, object>[] keysAndDatas)
		{
			List<KeyValuePair<TKey, object>> Ress = new List<KeyValuePair<TKey, object>>();

			foreach (KeyValuePair<TKey, object> KeyAndData in keysAndDatas)
			{
				Ress.Add(HandleWithKeyInto_WithKeyOut(KeyAndData));
			}

			return Ress.ToArray();
		}

		public KeyValuePair<TKey, object>
			HandleWithKeyInto_WithKeyOut(KeyValuePair<TKey, object> keyAndData)
		{
			TKey Key = keyAndData.Key;

			object Data = null;
			if (Handlers.ContainsKey(Key))
			{
				Data = Handlers[Key].Handle(keyAndData);
			}
			return new KeyValuePair<TKey, object>(Key, Data);
		}

		/*public object[] HandleWithoutKeyInto_WithoutKeyOut(KeyAndData[] keysAndDatas)
		{
			List<object> Ress = new List<object>();

			foreach(KeyAndData KeyAndData in keysAndDatas)
			{
				Ress.Add(HandleWithoutKeyInto_WithoutKeyOut(KeyAndData));
			}

			return Ress.ToArray();
		}
		public object HandleWithoutKeyInto_WithoutKeyOut(KeyAndData keyAndData)
		{
			TKey Key = (TKey)keyAndData.Key;

			return Handlers[Key].Handle(keyAndData.Data);
		}
		
		public object[] HandleWithKeyInto_WithoutKeyOut(KeyAndData[] keysAndDatas)
		{
			List<object> Ress = new List<object>();

			foreach(KeyAndData KeyAndData in keysAndDatas)
			{
				Ress.Add(HandleWithKeyInto_WithoutKeyOut(KeyAndData));
			}

			return Ress.ToArray();
		}
		public object HandleWithKeyInto_WithoutKeyOut(KeyAndData keyAndData)
		{
			TKey Key = (TKey)keyAndData.Key;

			return Handlers[Key].Handle(keyAndData);
		}
		*/

		/*public void Handle(object[] keysAndDatas)
		{
			foreach(object keyAndData in keysAndDatas)
			{
				Handle(keyAndData);
			}
		}
		public void Handle(object keyAndData)
		{
			KeyAndData KeyAndData = (KeyAndData)keyAndData;
			Handle(KeyAndData);
		}
		public void Handle(KeyAndData[] KeysAndDatas)
		{
			foreach(KeyAndData KeyAndData in KeysAndDatas)
			{
				Handle(KeyAndData);
			}
		}
		public void Handle(KeyAndData keyAndData)
		{
			TKey Key = (TKey)keyAndData.Key;

			if (Handlers.ContainsKey(Key))
			{
				Handlers[Key].Handle(keyAndData);
			}
		}
		public void Handle(TKey key, object data)
		{
			if (Handlers.ContainsKey(key))
			{
				KeyAndData KeyAndData = new KeyAndData()
				{
					Key = key,
					Data = data
				};

				Handlers[key].Handle(KeyAndData);
			}
		}

		public void Handle(TKey[] keys, object[] datas)
		{
			for(int i = 0; i < keys.Length - 1; i++)
			{
				Handle(keys[i], datas[i]);
			}
		}

		public void Handle(TKey[] keys, object data)
		{
			foreach(TKey key in keys)
			{
				Handle(key, data);
			}
		}
		
		 
		 public void Handle(object[] keys, object[] datas)
		{
			for(int i = 0; i < keys.Length - 1; i++)
			{
				Handle(keys[i], datas[i]);
			}
		}
	
		public object Handle(object key, object data)
		{
			TKey Key = (TKey)key;

			return Handle(Key, data);
		}
		
		public void Handle(TKey[] keys, object data)
		{
			object[] Datas = new object[keys.Length];

			for(int i = 0; i < keys.Length - 1; i++)
			{
				Datas[i] = data;
			}

			Handle(keys, Datas);
		}
		public object[] Handle(TKey[] keys, object[] datas)
		{
			List<object> Ress = new List<object>();

			for(int i = 0; i < keys.Length - 1; i++)
			{
				Ress.Add(Handle(keys[i], datas[i]));
			}

			return Ress.ToArray();
		}

		public object Handle(TKey key, object data)
		{
			object Res = null;

			if (Handlers.ContainsKey(key))
			{
				KeyAndData KeyAndData = new KeyAndData()
				{
					Key = key,
					Data = data
				};

				Res = Handlers[key].Handle(KeyAndData);
			}

			return Res;
		}
		 */
	}
}
