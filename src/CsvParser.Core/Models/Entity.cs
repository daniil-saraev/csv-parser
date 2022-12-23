namespace CsvParser.Core.Models;

public abstract class Entity
{
    public string Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
}