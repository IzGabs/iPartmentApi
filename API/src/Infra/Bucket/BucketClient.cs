using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Newtonsoft.Json;
using System.IO;

namespace API.src.Infra.Bucket
{
    public class BucketClient
    {
        public StorageClient Client { get; }

        public BucketClient()
        {
            StreamReader r = new StreamReader("./ipartmenttcc-1623ce01e782.json");
            string json = r.ReadToEnd();

            var bucketConnection = JsonConvert.DeserializeObject<BucketConnectionObject>(json);
            var serialized = JsonConvert.SerializeObject(bucketConnection);

            var credential = GoogleCredential.FromJson(serialized);
            Client = StorageClient.Create(credential);
        }
    }
}
