using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace PirateCruise
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineApplication.Execute<Program>(args);
        }

        [Required]
        [Option(Description = "GPX file with cache details")]
        public string Input { get; }

        [Required]
        [Option(Description = "CSV file with calculated coordinates")]
        public string Output { get; }

        private void OnExecute()
        {
            var gpxDocument = XDocument.Load(Input);

            var gpxParser = new GpxFileParser();
            var parsedCaches = gpxParser.Parse(gpxDocument);

            var processor = new CacheProcessor();
            var processedCaches = parsedCaches.Select(cache => processor.Process(cache));

            var csvWriter = new CsvFileWriter();
            using(var writer = new StreamWriter(Output))
            {
                csvWriter.Write(processedCaches, writer);
            }
        }
    }
}
