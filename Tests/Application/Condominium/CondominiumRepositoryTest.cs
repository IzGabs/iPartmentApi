using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Application.Condominium;
using API.src.Domain.Condominium;
using API.src.Domain.RealState.Entities;
using API.src.Domain.Values;
using System.Collections.Generic;
using Xunit;

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
                    iD: 1,
                street: "",
                    zipCode: "123",
                    number: "123",
                city: "CTBA",
                state: "lala",
                extraInfo: "123"
                );

            var monetarySample = new CondominiumMonetary();

            var objectSimple = new CondominiumObject(
                iD: null,
                name: "LALA",
                location: adressSample,
                academia: false,
                Valores: monetarySample,
                realStates: new List<RealEstateBase>()
                );


            //ACT
            var create = await repo.Create(objectSimple);
            if (!(create is CondominiumObject)) throw null;

            var updateObject = create;
            updateObject.Gym = true;

            var updateRequest = await repo.Update(updateObject);

            //ASSERT
            Assert.True(updateRequest);

        }
    }
}
