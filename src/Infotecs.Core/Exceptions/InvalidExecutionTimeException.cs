namespace Infotecs.Core.Exceptions;

[Serializable]
public class InvalidExecutionTimeException : ValidationException
{
	public InvalidExecutionTimeException() { }
	public InvalidExecutionTimeException(string message) : base(message) { }
	public InvalidExecutionTimeException(string message, Exception inner) : base(message, inner) { }
	protected InvalidExecutionTimeException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}