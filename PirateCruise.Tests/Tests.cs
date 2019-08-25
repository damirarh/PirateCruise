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
    }
}