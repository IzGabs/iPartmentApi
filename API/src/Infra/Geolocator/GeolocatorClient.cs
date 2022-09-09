using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Infra.Geolocator
{
    public class GeolocatorClient
    {
        IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyDaHUAN5K0YOy_kFCbo5mGz2SbOpSPRXto" };

        public async Task<Location> LatLongFromString(string fullAddress)
        {
            try
            {
                IEnumerable<Address> addresses = await geocoder.GeocodeAsync(fullAddress);
                return addresses.First().Coordinates;
            }
            catch
            {
                Console.WriteLine("Could Not return a LatLong");
            }

            return null;
        }
    }
}