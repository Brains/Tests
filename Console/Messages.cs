using System;
using System.Collections.Generic;

namespace ConsoleProject
{
	#region Messages

	internal abstract class Message
	{
		public IReceiver Source;
	}

	internal class MoveMessage : Message
	{
		public float Destination;
	}

	internal class AnimationMessage : Message
	{
		public string Name;
	}

	internal class ResponceMessage : Message
	{
		public IReceiver Destination;
	}

	#endregion




	#region Receiver

	internal interface IReceiver
	{
		void Receive<T>(T message) where T: Message;
	}

	internal class Receiver : IReceiver
	{
		private Dictionary<Type, Action<Message>> handlers; 
		public Receiver()
		{
			handlers = new Dictionary<Type, Action<Message>>();
			handlers.Add(typeof (MoveMessage),  message => Handle(message) );
			handlers.Add(typeof (AnimationMessage),  message => Handle((AnimationMessage) message) );
			handlers.Add(typeof (ResponceMessage),  message => Handle((ResponceMessage) message) );
        }

		public void Receive<T>(T message) where T : Message
		{
			handlers[message.GetType()](message);



//			var asd = Convert.ChangeType(message, type);
//
//			if (message is MoveMessage)
//				Handle((MoveMessage) message);
//			if (message is AnimationMessage)
//				Handle((AnimationMessage) message);
		}

		public void Handle<T>(T message) {}
		public void Handle(MoveMessage message) {}
		public void Handle(AnimationMessage message) {}
		public void Handle(ResponceMessage message) {}

		public void MyMethod()
		{
			var moveMessage = new MoveMessage();

			var masd = moveMessage;


			if (moveMessage != null)
			{
				foreach (var handler in handlers)
				{
					
				}	
			}
		}
	}

	#endregion

}