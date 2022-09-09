using API.src.Core.Errors;
using API.src.Domain.Announcement.Application;
using API.src.Domain.RealState.Application;
using API.src.Domain.ScheduledVisits.Application;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Domain.User.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.ScheduledVisits
{
    public class ScheduledVisitsService : IScheduledVisitsService
    {
        private readonly ScheduleVisitsMessageDispatch messageDispatch;
        private readonly IScheduledVisitsRepository repository;
        private readonly IAnnouncementService announcementService;
        private readonly IUserService userService;

        public ScheduledVisitsService(ScheduleVisitsMessageDispatch messageDispatch, IScheduledVisitsRepository repository, IAnnouncementService announcementService, IUserService userService)
        {
            this.messageDispatch = messageDispatch;
            this.repository = repository;
            this.announcementService = announcementService;
            this.userService = userService;
        }


        public ScheduledVisitsObject GetById(int id) => repository.GetById(id);
        public IEnumerable<ScheduledVisitsObject> GetAllVisitsOfUsers(int id) => repository.GetAllVisitsOfUsers(id);
        public IEnumerable<ScheduledVisitsObject> GetAllVisitsOfAgent(int id) => repository.GetAllVisitsOfAgent(id);
        public IEnumerable<ScheduledVisitsObject> GetAllScheduledVisitsFromAnnounce(int id) => repository.GetAllScheduledVisitsFromAnnounce(id);

        public async Task<bool> Add(ScheduledVisitDTO obj)
        {
            var announcement = await announcementService.GetByID(obj.announcementID) ?? throw new TypeNotFound("Náo foi possivel encontrar o anuncio");
            var user = userService.Get(obj.visitorID) ?? throw new TypeNotFound("Náo foi possivel encontrar o usuario");

            var scheduleVisitObj = new ScheduledVisitsObject(
                date: obj.date,
                announcement: announcement,
                visitor: user
            );

            var request = await repository.Add(scheduleVisitObj);
            if (!request) return false;

            var userToDispatchPushNotification = announcement.Advertiser;
            return await messageDispatch.NotifyAgentOfNewVisit(userToDispatchPushNotification, announcement)
                ?? throw new MessageNotDispatched("Sua visita foi agendada mas não foi possível notificar o corretor");
        }

       
    }
}
