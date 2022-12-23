namespace CsvParser.Core.Exceptions;

[Serializable]
public class InvalidDateTimeException : ValidationException
{
	public InvalidDateTimeException() { }
	public InvalidDateTimeException(string message) : base(message) { }
	public InvalidDateTimeException(string message, Exception inner) : base(message, inner) { }
	protected InvalidDateTimeException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}