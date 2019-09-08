using CsvHelper.Configuration;

namespace PirateCruise
{
    public sealed class ProcessedCacheDataClassMap : ClassMap<ProcessedCacheData>
    {
        public ProcessedCacheDataClassMap()
        {
            Map(m => m.Code).Index(0);
            Map(m => m.CorrectedCoords.Lat).Index(1);
            Map(m => m.CorrectedCoords.Lng).Index(2);
        }
    }
}
