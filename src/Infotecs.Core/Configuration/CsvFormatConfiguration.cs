namespace Infotecs.Core.Configuration
{
    public class CsvFormatConfiguration
    {
        public bool HasHeaders { get; set; }
        public string Delimiter { get; set; } = null!;
        public string DateTimeFormat { get; set; } = null!;
    }
}
