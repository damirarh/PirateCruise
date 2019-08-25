using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PirateCruise
{
    public class GpxFileParser
    {
        private readonly XNamespace topografix = "http://www.topografix.com/GPX/1/0";
        private readonly XNamespace groundspeak = "http://www.groundspeak.com/cache/1/0/1";
        private readonly Regex distanceAndBearingRegex = new Regex(
            @"Smjer/Peilung/Bearing: (?<distance>[\d\.]*) m / (?<bearing>[-\d\.]*) °", RegexOptions.Compiled);

        public IEnumerable<CacheData> Parse(XDocument gpxDocument)
        {
            return gpxDocument.Root.Elements(topografix + "wpt").Select(ParseWptElement);
        }

        private CacheData ParseWptElement(XElement wptElement)
        {
            var lat = double.Parse(wptElement.Attribute("lat").Value, CultureInfo.InvariantCulture);
            var lng = double.Parse(wptElement.Attribute("lon").Value, CultureInfo.InvariantCulture);
            var code = wptElement.Element(topografix + "name").Value;
            var (distance, bearing) = ParseDistanceAndBearing(
                wptElement.Element(groundspeak + "cache").Element(groundspeak + "long_description").Value);

            return new CacheData(code, new LatLng(lat, lng), bearing, distance);
        }

        private (double distance, double bearing) ParseDistanceAndBearing(string longDescription)
        {
            var match = distanceAndBearingRegex.Match(longDescription);
            var distance = double.Parse(match.Groups["distance"].Value, CultureInfo.InvariantCulture);
            var bearing = double.Parse(match.Groups["bearing"].Value, CultureInfo.InvariantCulture);
            return (distance, bearing);
        }
    }
}
