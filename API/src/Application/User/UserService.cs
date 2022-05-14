using API.Domain.User;
using API.src.Domain.User;
using API.src.Domain.User.Application;
using API.src.Infra.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.User
{

    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Create(UserObject obj)
        {
            obj.UserType = UserTypeEnum.CUSTOMER;
             repository.Create(obj);
        }

        public UserObject Get(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<UserObject> GetAll()
        {
            return repository.GetAll();
        }
        public void Update(UserObject obj)
        {
            repository.Update(obj);
        }
        public void Delete(UserObject body)
        {
            repository.Delete(body);
        }
    }
}
