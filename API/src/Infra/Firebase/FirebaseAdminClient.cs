using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.IO;

namespace API.src.Infra.Firebase
{
    public class FirebaseAdminClient
    {
        public FirebaseApp Instace { get; private set; }

        public FirebaseAdminClient()
        {
            StreamReader r = new StreamReader("./ipartment-firebase-admin.json");
            string json = r.ReadToEnd();

            Instace = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(json),
                ProjectId = "ipartment-79a0b"
            });
        }
    }
}
