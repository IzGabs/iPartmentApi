using API.Domain.Location;
using API.src.Core.Errors;
using API.src.Domain.Location;
using API.src.Infra.Geolocator;
using System;
using System.Threading.Tasks;

namespace API.src.Application.Location
{
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository repository;
        private readonly GeolocatorClient geolocation;

        public LocationService(ILocationRepository _repository, GeolocatorClient geo)
        {
            repository = _repository;
            this.geolocation = geo;
        }

        public async Task<Address> Create(Address adress)
        {
            var getLatLong = await geolocation.LatLongFromString(adress.FullAddress) ?? throw new CouldNotCreateLocationException("Could Not Find LatLng");
            adress.fromGeolocation(getLatLong);

            return await repository.Create(adress);
        }

        public Task<bool> Delete(int id) => throw new NotImplementedException();
        public Task<Address> Edit(Address adress) =>     throw new NotImplementedException();
        
    }
}
