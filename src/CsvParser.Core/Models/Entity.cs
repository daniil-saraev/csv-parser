namespace CsvParser.Core.Models;

/// <summary>
/// Base class for models that are to be persisted.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Primary key.
    /// </summary>
    public Guid Id { get; private set; }
}