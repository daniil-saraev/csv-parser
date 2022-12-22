using Infotecs.Core.Models;

namespace Infotecs.Core.Interfaces;

public interface ICsvService
{
    IEnumerable<Value> ReadValuesFromCsv(Stream stream, string fileName);
}