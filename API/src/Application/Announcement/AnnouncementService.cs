using API.src.Core.Errors;
using API.src.Core.Filters;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Application;
using API.src.Domain.User.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.Announcement
{
    public class AnnouncementService : IAnnouncementService
    {
        protected IAnnouncementRepository repository;
        protected IRealEstateService realStateService;
        protected IUserService userService;

        private readonly IMonetaryService<AnnouncementSellMonetary> monetaryService;

        public AnnouncementService(IAnnouncementRepository repository, IRealEstateService realStateService, IUserService userService, IMonetaryService<AnnouncementSellMonetary> monetaryService)
        {
            this.repository = repository;
            this.realStateService = realStateService;
            this.userService = userService;
            this.monetaryService = monetaryService;
        }

        public async Task<AnnouncementAggregate> Create(int idRealEstate, int idAdvertiser, AnnouncementValueObject announcement, AnnouncementSellMonetary monetary)
        {

            var findRealEstate = await realStateService.GetByID(idRealEstate) ?? throw new TypeNotFound("Imóvel não encontrado!!");
            var findUser = await userService.Get(idAdvertiser) ?? throw new TypeNotFound("User não encontrado!!");
            var values = await monetaryService.Create(monetary) ?? throw CouldNotCreateRealStateValues.Default();

            var announcementToCreate = new AnnouncementAggregate(announcement, findUser, findRealEstate, values);

            return await repository.Create(announcementToCreate);
        }

        public async Task<List<AnnouncementAggregate>> GetListPagineted(string city, int page, AnnouncementsFilter filter, int pageSize = 0)
        {
            return await repository.GetListPagineted(city, page, filter, pageSize);
        }
    }
}
