using API.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.User.Application
{
    public interface IUserService
    {
        Task<UserObject> Create(UserObject obj);
        Task<UserObject> Get(int id);
        Task<bool> Update(UserObject obj);
        Task<bool> Delete(UserObject obj);
        Task<List<UserObject>> GetAll();
    }
}
