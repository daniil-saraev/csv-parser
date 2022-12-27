namespace CsvParser.Core.Models
{
    public class ParsingResult
    {
        public IEnumerable<Value> Values { get; }

        public int ParsingErrorCount { get; }

        public ParsingResult(IEnumerable<Value> values, int parsingErrorCount)
        {
            Values = values;
            ParsingErrorCount = parsingErrorCount;
        }
    }
}
