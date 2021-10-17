using System;
using System.Runtime.Serialization;

namespace Poc.Mongo.Core.Exceptions
{
	[Serializable]
	public class GenericException : Exception
	{
		public GenericException()
		{
		}

		public GenericException(string message) : base(message)
		{
		}

		public GenericException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected GenericException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
			=> base.GetObjectData(info, context);
	}
}
