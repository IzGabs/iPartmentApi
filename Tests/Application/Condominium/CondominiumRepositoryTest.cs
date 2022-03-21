using API.src.Domain.Condominium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.src.Application.Condominium;
using Xunit;
using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Domain.Values;
using API.src.Domain.RealState.Entities;
using Microsoft.Extensions.DependencyInjection; 

namespace Tests.Application.Condominium
{
    public class CondominiumRepositoryTest : IClassFixture<ContextTestClass>
    {
        private ICondominiumRepository repo;

        public CondominiumRepositoryTest(ContextTestClass seed)
        {
            repo = new CondominiumRepository(seed.buildContext);
        }

        [Fact]
        public async void Update()
        {
            //ARRANGE
            var adressSample = new Address(
                    ID: null,
                    cep: "123",
                    numero: "123",
                complemento: "123");

            var monetarySample = new CondominiumMonetary();

            var objectSimple = new CondominiumObject(
                iD: null,
                name: "LALA",
                location: adressSample,
                academia: false,
                Valores: monetarySample,
                realStates: new List<RealStateWithCondo>()
                );


            //ACT
            var create = await repo.Create(objectSimple);
            if (!(create is CondominiumObject)) throw null;

            var updateObject = create; 
            updateObject.Academia = true;

             var updateRequest = await repo.Update(updateObject);

            //ASSERT
            Assert.True(updateRequest);

        }
    }
}
