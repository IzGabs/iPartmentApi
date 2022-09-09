using API.Domain.User;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Entities;
using API.src.Infra.Firebase;
using System.Threading.Tasks;

namespace API.src.Application.ScheduledVisits
{
    public class ScheduleVisitsMessageDispatch
    {

        private readonly FirebaseMessageDispacher messageDispacher;

        public ScheduleVisitsMessageDispatch(FirebaseMessageDispacher messageDispacher)
        {
            this.messageDispacher = messageDispacher;
        }

        public async Task<bool?> NotifyAgentOfNewVisit(UserObject user, AnnouncementAggregate announcement)
        {
            var message = "Uma nova visita foi marcada para o imovel "
                + announcement.RealEstate.Adress.FullAddress;

            var request =  await messageDispacher.Send(
                 messag: message,
                 title: "Nova visita marcada",
                 userToken: user.PushToken
                 );

            if (!request) return null;

            return true;
        }

    }
}
