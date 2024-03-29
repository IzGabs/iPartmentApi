﻿using API.Domain.Location;
using System.Threading.Tasks;

namespace API.src.Domain.Location
{
    public interface ILocationRepository
    {

        Task<Address> Create(Address adress);
        Task<Address> Edit(int id, Address adress);
        Task<bool> Delete(int id);
    }
}
