namespace Raycasting
{
    public interface ILatLong
    {
         double Latitude { get;  }
         double Longtitude { get;  }
    }

    public static class Raycaster
    {

        public static bool Contains(ILatLong[] bounds, double lat, double lng)
        {
            var count = 0;
            for (var b = 0; b < bounds.Length; b++)
            {
                var vertex1 = bounds[b];
                var vertex2 = bounds[(b + 1) % bounds.Length];
                if (West(vertex1, vertex2, lng, lat))
                    ++count;
            }
            return count % 2 == 1;
        }

        private static bool West(ILatLong a, ILatLong b, double x, double y)
        {
            if (!(a.Longtitude <= b.Longtitude)) return West(b, a, x, y);
            if (y <= a.Longtitude || y > b.Longtitude ||
                x >= a.Latitude && x >= b.Latitude)
            {
                return false;
            }
            if (x < a.Latitude && x < b.Latitude)
            {
                return true;
            }
            return (y - a.Longtitude) / (x - a.Latitude) > (b.Longtitude - a.Longtitude) / (b.Latitude - a.Latitude);
        }
    }
}


