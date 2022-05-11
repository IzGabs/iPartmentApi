using API.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.User.Application
{
    public interface IUserRepository
    {
        Task<UserObject> Create(UserObject obj);
        Task<UserObject> Get(int id);
        Task<bool> Delete(UserObject id);
        Task<bool> Update(UserObject obj);
        Task<List<UserObject>> GetAll();
    
    }
}
