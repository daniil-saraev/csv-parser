namespace CsvParser.Core.Configuration
{
    /// <summary>
    /// Intended to be mapped to external configuration file like appsettings.json.
    /// </summary>
    public class CsvFormatConfiguration
    {
        public bool HasHeaders { get; set; }
        public string Delimiter { get; set; } = null!;
        public string DateTimeFormat { get; set; } = null!;
    }
}
