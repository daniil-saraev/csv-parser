namespace Infotecs.Core.Exceptions;

[Serializable]
public class InvalidRowCountException : ValidationException
{
	public InvalidRowCountException() { }
	public InvalidRowCountException(string message) : base(message) { }
	public InvalidRowCountException(string message, Exception inner) : base(message, inner) { }
	protected InvalidRowCountException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}