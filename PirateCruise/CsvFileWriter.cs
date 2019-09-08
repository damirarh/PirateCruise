using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PirateCruise
{
    public class CsvFileWriter
    {
        public void Write(IEnumerable<ProcessedCacheData> cacheData, TextWriter writer)
        {
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.Delimiter = ",";
                csv.Configuration.RegisterClassMap<ProcessedCacheDataClassMap>();

                csv.WriteRecords(cacheData);
            }
        }
    }
}
