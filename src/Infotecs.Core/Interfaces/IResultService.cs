using Infotecs.Core.Models;

namespace Infotecs.Core.Interfaces;

public interface IResultService
{
    Result ComputeResult(IEnumerable<Value> values);
}