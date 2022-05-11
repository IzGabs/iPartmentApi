using API.Domain.User;
using API.src.Domain.User;
using API.src.Domain.User.Application;
using API.src.Infra.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.User
{

    public class UserService : IUserService
    {
        private readonly BuildContext _context;
        private readonly IUserRepository repository;

        public UserService(BuildContext context, IUserRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        public async Task<UserObject> Create(UserObject obj) 
        {
            obj.UserType = UserTypeEnum.CUSTOMER;
            return await repository.Create(obj); 
        }

        public async Task<bool> Delete(UserObject body) => await repository.Delete(body);

        public async Task<UserObject> Get(int id) => await repository.Get(id);

        public async Task<List<UserObject>> GetAll() => await repository.GetAll();

        public async Task<bool> Update(UserObject obj) => await repository.Update(obj);   
    }
}
