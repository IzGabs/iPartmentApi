using API.Application;
using API.Domain.User;
using API.src.Core.Errors;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Application;
using API.src.Domain.User.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Announcement
{
    public class AnnouncementService : IAnnouncementService
    {
        protected IAnnouncementRepository repository;

        protected IRealEstateService realStateService;
        protected IUserService userService;

        public AnnouncementService(IAnnouncementRepository repository, IRealEstateService realStateService, IUserService userService)
        {
            this.repository = repository;
            this.realStateService = realStateService;
            this.userService = userService;
        }

        public async Task<AnnouncementAggregate> Create(int idRealEstate, int idAdvertiser, AnnouncementValueObject announcement)
        {

            //var findRealEstate = await realStateService.GetByID(idRealEstate) ?? throw new TypeNotFound("Imóvel não encontrado!!");
            //var findUser = await userService.Get(idAdvertiser) ?? throw new TypeNotFound("User não encontrado!!");

            //var announcementToCreate = new AnnouncementAggregate(announcement, findUser, findRealEstate);

            //return await repository.Create(announcementToCreate);
            return null;
        }
    }
}
