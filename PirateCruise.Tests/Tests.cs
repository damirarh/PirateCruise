using FluentAssertions;
using NUnit.Framework;
using PirateCruise;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Tests
{
    public class Tests
    {
        private readonly string gpxFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "sample.gpx");

        [Test]
        public void ParseGpxFile()
        {
            var gpxDocument = XDocument.Load(gpxFile);
            var parser = new GpxFileParser();

            var parsed = parser.Parse(gpxDocument).Single();

            var expected = new CacheData("GC7WP8Y", new LatLng(43.550767, 16.51405), -23.896, 905.656);
            parsed.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ProcessCacheData()
        {
            var cacheData = new CacheData("GC7WP8Y", new LatLng(43.550767, 16.51405), -23.896, 905.656);
            var processor = new CacheProcessor();

            var processed = processor.Process(cacheData);

            var expected = new ProcessedCacheData(cacheData, new LatLng(43.558220, 16.509510));
            processed.Should().BeEquivalentTo(expected, options => options
                .ComparingByMembers<LatLng>()
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 0.000001)).WhenTypeIs<double>()
            );
        }
    }
}