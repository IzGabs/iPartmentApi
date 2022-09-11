using API.Domain.User;
using API.src.Core.Errors;
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
        private readonly IUserImageRepository userImage;

        public UserService(IUserRepository repository, IUserImageRepository userImage)
        {
            this.repository = repository;
            this.userImage = userImage;
        }

        public UserObject Create(UserObject obj)
        {
            obj.UserType = UserTypeEnum.CUSTOMER;
            return repository.Create(obj);
        }

        public UserObject Get(int id) => repository.Get(id);

        public IEnumerable<UserObject> GetAll() => repository.GetAll();
        public void Update(UserObject obj) => repository.Update(obj);
        public void Delete(UserObject body) => repository.Delete(body);

        public async Task<bool> CreateAgent(NewAgentDTO obj)
        {
            var searchUser = repository.Get(obj.userID) ?? throw new TypeNotFound("Usuário não encontrado!!");
            var requestInsertImage = await userImage.InsertAgentImage(obj.image, searchUser) ?? throw new ImageNotUploaded("Nao foi possivel armazenar a referencia");

            var agentDocuments = new AgentDocument(
                creciID: obj.CRECIID,
                image: requestInsertImage,
                user: searchUser
            );

            searchUser.UserType = UserTypeEnum.ADMIN;
            repository.Update(searchUser);

            return await repository.CreateAgent(agentDocuments);

        }
    }
}

