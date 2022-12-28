namespace CsvParser.Core.Exceptions;

[Serializable]
public class InvalidRowCountException : ValidationException
{
	private const string MESSAGE = "Invalid number of records";

    public InvalidRowCountException() : base(MESSAGE) { }
	public InvalidRowCountException(string message) : base(message) { }
	public InvalidRowCountException(string message, Exception inner) : base(message, inner) { }
	protected InvalidRowCountException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}