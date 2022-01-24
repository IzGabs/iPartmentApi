using API.Domain.User;
using DockerAPIEntity.Models;
using iPartmentApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Service
{
    public class TokenServiceTests
    {

        private User _thisUser = new User(
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
