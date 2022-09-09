using FirebaseAdmin.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Infra.Firebase
{
    public class FirebaseMessageDispacher
    {

        private readonly FirebaseAdminClient Client;

        public FirebaseMessageDispacher(FirebaseAdminClient client)
        {
            Client = client;
        }

        public async Task<bool> Send(string messag, string title, string userToken)
        {
            var message = new Message() {
                Token = userToken,
                Notification = new Notification() {
                    Title = title,
                    Body = messag,
                },
                Data = new Dictionary<string, string>(),
            };


           var dispatcher = FirebaseMessaging.GetMessaging(Client.Instace);
           var messageID = await dispatcher.SendAsync(message);

            return messageID != null;
        }
    }
}
