namespace CsvParser.Core.Models
{
    /// <summary>
    /// Contains a collection of valid <see cref="Value"/> entities and the number of validation errors
    /// that occured during parsing.
    /// </summary>
    public class ParsingResult
    {
        public IEnumerable<Value> Values { get; }

        public int ParsingErrorCount { get; }

        internal ParsingResult(IEnumerable<Value> values, int parsingErrorCount)
        {
            Values = values;
            ParsingErrorCount = parsingErrorCount;
        }
    }
}
