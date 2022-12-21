using Infotecs.Core.Models;

namespace Infotecs.Core.Interfaces;

public interface IResultService
{
    Task<Result> ComputeResult(IEnumerable<Value> values);
}