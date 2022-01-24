using DockerAPIEntity.Controllers;
using DockerAPIEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Controllers
{
    public class UserControllerTests
    {
        private DbContextOptions<BuildContext> options;

        public UserControllerTests()
        {
            options = new DbContextOptionsBuilder<BuildContext>().UseInMemoryDatabase(databaseName: "testDB").Options;

            Seed();
        }

        [Fact]
        public async void Authenticate_test()
        {
            using var context = new BuildContext(options);
            var controller = new UserController(context);

            var response = await controller.Authenticate(email: "gubs@gmail.com", password: "123");

            Assert.NotNull(response.Value);
            Type _returnObject = (response.Value as Object).GetType(); 

            Assert.NotNull(_returnObject.GetProperty("token"));
            Assert.NotNull(_returnObject.GetProperty("user"));
            Assert.IsType<ActionResult<Object>>(response);
        }



        private async void Seed()
        {
            using var context = new BuildContext(options);
            var controller = new UserController(context);

            var _userOne = new User(iD: null,
                name: "Gabriel", email: "gubs@gmail.com",
                password: "123", phone: "");

            var _userTwo = new User(iD: null,
                name: "Bruno", email: "brulim@gmail.com",
                password: "123", phone: "");

            await controller.PostUser(_userOne);
            await controller.PostUser(_userTwo);
        }

    }
}
