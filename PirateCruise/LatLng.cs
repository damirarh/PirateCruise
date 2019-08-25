namespace PirateCruise
{
    public struct LatLng
    {
        public double Lat { get; }
        public double Lng { get; }

        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }
}
