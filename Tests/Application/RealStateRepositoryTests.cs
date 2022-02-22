using API.Domain.Models;
using API.Domain.RealState.Models;
using API.src.Application.RealState;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Location;
using Xunit;
using API.src.Domain.RealState.repository;


namespace Tests.Application
{
    public class RealStateRepositoryTests : IClassFixture<ContextTestClass>
    {
        private RealStateObject realStateObjectExample;
        private IRealStateRepository repository;


        public RealStateRepositoryTests(ContextTestClass seed)
        {
            realStateObjectExample = getExampleObj();
            repository = new RealStateRepository(seed.buildContext);
        }

        [Fact]
        public async void Create()
        {
            //ARRANGE

            //ACT
            var responseId = await repository.Create(realStateObjectExample);

            //ASSERT
            Assert.NotNull(responseId);
            Assert.IsType<int>(responseId);
        }

        [Fact]
        public async void Get()
        {
            //ARRANGE

            //ACT
            await Seed();
            var responseId = await repository.Getall();
            var response = await repository.Get(2);
            var responseUnknowID = await repository.Get(112097);
            Func<Task> responseWithNull = async () => await repository.Get(null);

            //ASSERT
            Assert.Null(responseUnknowID);
            Assert.NotNull(response);
            Assert.IsType<RealStateObject>(response);
            await Assert.ThrowsAsync<NullReferenceException>(responseWithNull);
        }

        [Fact]
        public async void GetAll()
        {
            //ARRANGE
            await Seed();

            //ACT
            var responseId = await repository.Getall();

            //ASSERT
            Assert.NotNull(responseId);
            Assert.IsType<List<RealStateObject>>(responseId);
        }

        [Fact]
        public async void Delete()
        {
            //ARRANGE
            await Seed();
            var responseId = await repository.Getall();
            var exampleObj = realStateObjectExample;
            exampleObj.ID = 1;

            //ACT
            var response = await repository.Delete(exampleObj);

            //ASSERT
            Assert.IsType<bool>(response);
        }

        private async Task Seed()
        {
            await repository.Create(getExampleObj());
            await repository.Create(getExampleObj());
        }

        private RealStateObject getExampleObj()
        {
            var adress = new Adress(ID: null, cep: "23", numero: "2", complemento: "123");

            return new RealStateObject(
                   iD: null, tipo: RealStateTypes.HOUSE,
                     tamanho: "1000x500", numeroSalas: 4,
                     numeroBanheiros: 3, suites: 2, mobiliado: true,
                     aceitaPets: true, moradorAtual: null, localicazao: adress, valor: 2000
                    );
        }
    }
}
