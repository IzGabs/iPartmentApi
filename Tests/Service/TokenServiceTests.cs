using API.Application;
using API.Domain.User;
using Xunit;

namespace Tests.Service
{
    public class TokenServiceTests
    {

        private UserObject _thisUser = new UserObject(
            iD: 1,
            name: "",
            email: "",
            password: "",
            phone: ""
            );

        [Fact]
        public void GenerateToken_test()
        {
            var result = TokenService.GenerateToken(_thisUser);



            Assert.IsType<string>(result);
        }
    }
}
