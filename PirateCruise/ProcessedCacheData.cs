namespace PirateCruise
{
    public class ProcessedCacheData : CacheData
    {
        public LatLng CorrectedCoords { get; set; }

        public ProcessedCacheData(CacheData cacheData, LatLng correctedCoords)
            : base(cacheData)
        {
            CorrectedCoords = correctedCoords;
        }
    }
}
