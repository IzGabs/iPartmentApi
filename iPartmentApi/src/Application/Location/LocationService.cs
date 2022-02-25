﻿using API.Domain.Location;
using API.src.Domain.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Location
{
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository repository;

        public LocationService(ILocationRepository _repository) {
            repository = _repository;
        }

        public async Task<Address> Create(Address adress) => await repository.Create(adress);

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Edit(Address adress)
        {
            throw new NotImplementedException();
        }
    }
}
