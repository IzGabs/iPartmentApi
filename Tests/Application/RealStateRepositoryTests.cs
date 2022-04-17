using API.Domain.Location;
using API.Domain.RealState.Models;
using API.src.Application.RealState;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace Tests.Application
{
    public class RealStateRepositoryTests : IClassFixture<ContextTestClass>
    {
        private RealStateBase realStateObjectExample;
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
            var getAgain = await  repository.GetallComplete();

            //ASSERT
            Assert.NotNull(responseId);
            Assert.IsType<RealStateBase>(responseId);
        }

        [Fact]
        public async void Get()
        {
            //ARRANGE

            //ACT
            await Seed();
            var response = await repository.Get(2);
            var responseUnknowID = await repository.Get(112097);

            //ASSERT
            Assert.Null(responseUnknowID);
            Assert.NotNull(response);
            Assert.IsType<RealStateBase>(response);
        }

        [Fact]
        public async void GetAll()
        {
            //ARRANGE
            await Seed();

            //ACT
            var responseId = await repository.GetallComplete();

            //ASSERT
            Assert.NotNull(responseId);
            Assert.IsType<List<RealStateBase>>(responseId);
        }

        [Fact]
        public async void Delete()
        {
            //ARRANGE
            await Seed();
            var responseId = await repository.GetallComplete();
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

        private RealStateBase getExampleObj()
        {
            var adress = new Address(
                    iD: 1,
                    zipCode: "123",
                    number: "123",
                city: "CTBA",
                state: "lala",
                extraInfo: "123"
                );

            return new RealStateBase(
                   iD: null, tipo: RealStateTypes.HOUSE,
                     tamanho: "1000x500", numeroSalas: 4,
                     numeroBanheiros: 3, suites: 2, mobiliado: true,
                     aceitaPets: true, moradorAtual: null, localicazao: adress, 
                     valores: new RealStateMonetary(valorFixo: 2000)
                    );
        }
    }
}
