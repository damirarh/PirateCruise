namespace PirateCruise
{
    public class CacheData
    {
        private CacheData cacheData;

        public string Code { get; }
        public LatLng OriginalCoords { get; }
        public double Bearing { get; }
        public double Distance { get; }

        public CacheData(string code, LatLng originalCoords, double bearing, double distance)
        {
            Code = code;
            OriginalCoords = originalCoords;
            Bearing = bearing;
            Distance = distance;
        }

        public CacheData(CacheData cacheData)
            : this(cacheData.Code, cacheData.OriginalCoords, cacheData.Bearing, cacheData.Distance)
        {}
    }
}
