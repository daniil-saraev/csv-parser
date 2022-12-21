using Infotecs.Core.Models;

namespace Infotecs.Core.Interfaces;

public interface ICsvService
{
    Task<IEnumerable<Value>> ReadValuesFromCsv(Stream stream, string fileName);
}