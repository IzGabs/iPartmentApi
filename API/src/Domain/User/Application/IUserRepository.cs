using API.Domain.User;
using API.src.Domain.Images;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.User.Application
{
    public interface IUserRepository
    {
        IEnumerable<UserObject> GetAll();
        UserObject Get(int id);
        UserObject Create(UserObject obj);
        void Update(UserObject obj);
        void Delete(UserObject id);
        Task<bool> CreateAgent(AgentDocument obj);
    }

    public interface IUserImageRepository
    {
        Task<UsersImages> InsertSingle(ImageFile image, UserObject user);
        Task<AgentDocumentImage> InsertAgentImage(ImageFile image, UserObject user);

    }
}
