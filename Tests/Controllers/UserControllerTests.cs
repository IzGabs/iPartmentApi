using API.Domain;
using API.Domain.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using API.Controllers;
using API.src.Infra.EntityFramework;

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
        public async void Authenticate()
        {
            //ARRANGE
            using var context = new BuildContext(options);
            var controller = new UserController(context);

            //ACT   
            var response = await controller.Authenticate(new LoginViewModel(email: "gubs@gmail.com", password: "123"));

            //ASSERT
            Assert.NotNull(response.Value);
            Type _returnObject = (response.Value as Object).GetType();

            Assert.NotNull(_returnObject.GetProperty("token"));
            Assert.NotNull(_returnObject.GetProperty("user"));
            Assert.IsType<ActionResult<Object>>(response);
        }


        [Fact]
        public async void PutUser()
        {
            //ARRANGE
            using var context = new BuildContext(options);
            var controller = new UserController(context);

            var _user = new UserObject(iD: 1,
                name: "Gabriel M", email: "gubs@gmail.com",
                password: "123", phone: "");

            //ACT
            var _requestChangeOne = await controller.PutUser(id: 1, user: _user);
            var _requestDiferentID = await controller.PutUser(id: 20, user: _user);


            //ASSERT
            Assert.IsType<BadRequestResult>(_requestDiferentID);

        }

        [Fact]
        public async void Post()
        {
            //ARRANGE
            using var context = new BuildContext(options);
            var controller = new UserController(context);

            var _user = new UserObject(iD: 1,
                name: "Gabriel M", email: "gubs2@gmail.com",
                password: "123", phone: "41995116689");

            //ACT
            var _postWithID = await controller.PostUser(_user);

            _user.ID = null;
            var _postWithoutID = await controller.PostUser(_user);

            _user.ID = null;
            var _trySameEmailRegister = await controller.PostUser(_user);


            var _user2 = new UserObject(iD: null,
              name: "Gabriel M", email: "diferent@gmail.com",
              password: "123", phone: "41995116689");

            var _trySamePhoneRegister = await controller.PostUser(_user2);

            //ASSERT
            Assert.IsType<BadRequestObjectResult>(_postWithID.Result);
            Assert.IsType<CreatedAtActionResult>(_postWithoutID.Result);
            Assert.IsType<ConflictObjectResult>(_trySameEmailRegister.Result);
            Assert.IsType<ConflictObjectResult>(_trySamePhoneRegister.Result);

            ConflictObjectResult _emailConflict = _trySameEmailRegister.Result as ConflictObjectResult;
            ConflictObjectResult _phoneConflict = _trySamePhoneRegister.Result as ConflictObjectResult;

            Assert.Equal(_emailConflict.Value, UserResponsesEnum.SAME_EMAIL.ToString());
            Assert.Equal(_phoneConflict.Value, UserResponsesEnum.SAME_PHONE_NUMBER.ToString());

        }

        private async void Seed()
        {

            using var context = new BuildContext(options);
            var controller = new UserController(context);

            var _userOne = new UserObject(iD: null,
                name: "Gabriel", email: "gubs@gmail.com",
                password: "123", phone: "1");

            var _userTwo = new UserObject(iD: null,
                name: "Bruno", email: "brulim@gmail.com",
                password: "123", phone: "2");

            await controller.PostUser(_userOne);
            await controller.PostUser(_userTwo);
        }

    }
}
