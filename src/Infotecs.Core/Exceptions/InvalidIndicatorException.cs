namespace Infotecs.Core.Exceptions;

[Serializable]
public class InvalidIndicatorException : ValidationException
{
	public InvalidIndicatorException() { }
	public InvalidIndicatorException(string message) : base(message) { }
	public InvalidIndicatorException(string message, Exception inner) : base(message, inner) { }
	protected InvalidIndicatorException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}