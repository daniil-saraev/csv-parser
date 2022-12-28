namespace CsvParser.Core.Exceptions;

/// <summary>
/// Base class for all domain validation exceptions.
/// </summary>
public abstract class ValidationException : Exception
{
	public ValidationException() { }
	public ValidationException(string message) : base(message) { }
	public ValidationException(string message, Exception inner) : base(message, inner) { }
	protected ValidationException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
