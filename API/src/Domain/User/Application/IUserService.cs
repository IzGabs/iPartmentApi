using API.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.User.Application
{
    public interface IUserService
    {
        IEnumerable<UserObject> GetAll();
        UserObject Get(int id);
        void Create(UserObject obj);
        void Update(UserObject obj);
        void Delete(UserObject obj);
    }
}
