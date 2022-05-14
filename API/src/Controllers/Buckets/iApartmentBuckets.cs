using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace API.src.Controllers.Buckets
{
    public class iApartmentBuckets
    {
        public void DoTheTest()
        {
            UploadManager mgr;
            mgr = new UploadManager();
            mgr.Initialize_Auth();

            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("Ola mundo - Hello world");
                string linhaDeEntrada = Console.ReadLine();

                if (linhaDeEntrada == "aaa")
                {

                    mgr.UpdateSingleFile();

                }

                if (linhaDeEntrada == "all")
                {

                    mgr.UpdateAllFiles();

                }

                if (linhaDeEntrada == "list")
                    mgr.ListAllFiles();

                if (linhaDeEntrada == "quit")
                    finished = true;
            }
        }

    }
    
    public class UploadFileSample
    {
        private StorageClient storage;
        public object AuthImplicit(string projectId)
        {
            // If you don't specify credentials when constructing the client, the
            // client library will look for credentials in the environment.
            //var credential = GoogleCredential.GetApplicationDefault();


            //string fromFileJSON = @"C:\Users\renato\Downloads\TCC\ipartmenttcc-ada783aee0f4.json";
            string fromFileJSON = @"C:\Users\renato\Downloads\TCC\TOTAL\ipartmenttcc-1623ce01e782.json";
            var credential = GoogleCredential.FromFile(fromFileJSON);

            storage = StorageClient.Create(credential);


            // Make an authenticated API request.
            var buckets = storage.ListBuckets(projectId);
            foreach (var bucket in buckets)
            {
                Console.WriteLine(bucket.Name);
                if (string.IsNullOrEmpty(bucketName))
                {
                    this.bucketName = bucket.Name;
                }
            }

            return null;
        }

        private ListObjectsOptions options;
        public void ListBucketObjects()
        {
            // List only objects with a name starting with "greet"
            Console.WriteLine("list objects in bucketName:" + bucketName);
            var objects = storage.ListObjects(bucketName);
            //var objects = storage.ListObjects(bucketName, "greet");

            //ListObjectsOptions options = new ListObjectsOptions();
            //var objects3 = storage.ListObjects(bucketName, "greet", options);

            foreach (var o in objects)
            {
                if (o is Google.Apis.Storage.v1.Data.Object)
                {
                    Google.Apis.Storage.v1.Data.Object obj;
                    obj = (Google.Apis.Storage.v1.Data.Object)o;

                    Console.WriteLine($"listing {obj.Name}.");
                }
            }
        }

        private string bucketName = "";//"aaa";


        public void UploadFile(
            //string bucketName = "aaa",// your -unique-bucket-name",
            string localPath = "my-local-path/my-file-name",
            string objectName = "my-file-name")
        {

            //credentials_dict = {
            //                    "type": "service_account",
            //      "project_id": "asdf-163219",
            //      "private_key_id": "asdf2938492837498234",
            //}
            //credentials = service_account.Credentials.from_service_ac

            //var storage = StorageClient.Create(credential: credentials);

            using (var fileStream = File.OpenRead(localPath))
            {
                Console.WriteLine("upload to - bucketName:" + bucketName);
                storage.UploadObject(bucketName, objectName, null, fileStream);
                Console.WriteLine($"Uploaded {objectName}.");
            }
        }
    }


    public class UploadManager
    {
        UploadFileSample uploadSample;
        string projectId = "iPartmentTCC";

        public void Initialize_Auth()
        {

            uploadSample = new UploadFileSample();
            uploadSample.AuthImplicit(projectId);
        }

        public void UpdateSingleFile()
        {
            Console.WriteLine("upload file...");


            try
            {




                string bucket_name = "";// aaa";
                string filename = @"C:\TCC\testeDeArquivo.txt";
                string toObjName = "testeDeArquivoUploaded.txt";
                uploadSample.UploadFile(filename, toObjName);

                //testeDeArquivoUploaded
                // request end-point:
                // https://cloud.google.com/storage/docs/request-endpoints?hl=pt_br
                // https://storage.cloud.google.com/BUCKET_NAME/OBJECT_NAME

                Console.WriteLine("upload file...ok");
            }
            catch (Exception e)
            {
                Console.WriteLine("upload file... ERROR:" + e.ToString());
                //throw;
            }
        }

        public void DownloadFile(
            string bucketName = "your-unique-bucket-name",
            string objectName = "my-file-name",
            string localPath = "my-local-path/my-file-name")
        {
            var storage = StorageClient.Create();
            using (FileStream outputFile = File.OpenWrite(localPath))
            {
                storage.DownloadObject(bucketName, objectName, outputFile);
            }
            Console.WriteLine($"Downloaded {objectName} to {localPath}.");

        }


        /// <summary>
        /// retrieve BUCKET files
        /// </summary>
        public void ListAllFiles()
        {
            Console.WriteLine("list all files from BUCKET");


            try
            {

                //string fromPath = @"C:\TCC\images";
                //string[] files = Directory.GetFiles(fromPath);


                // list all files from bucket
                uploadSample.ListBucketObjects();

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed:" + e.ToString());

            }
        }


        public void UpdateAllFiles()
        {
            Console.WriteLine("upload all files...");


            try
            {

                string fromPath = @"C:\TCC\images";
                string[] files = Directory.GetFiles(fromPath);
                //Path.GetFileName

                for (int i = 0; i <= files.Length - 1; i++)
                {
                    string filename = files[i];


                    string bucket_name = "";// aaa";
                                            //string filename = @"C:\TCC\testeDeArquivo.txt";
                    string toObjName = "";// testeDeArquivoUploaded.txt";

                    toObjName = Path.GetFileName(filename);


                    Console.WriteLine("upload file..." + toObjName);

                    uploadSample.UploadFile(filename, toObjName);

                    //testeDeArquivoUploaded
                    // request end-point:
                    // https://cloud.google.com/storage/docs/request-endpoints?hl=pt_br
                    // https://storage.cloud.google.com/BUCKET_NAME/OBJECT_NAME

                    Console.WriteLine("upload file...ok");


                    /*
                     * 
                     * https://storage.googleapis.com/iapartment-bucket/house-sample.jpg
                     * https://storage.googleapis.com/iapartment-bucket/images3.jpeg
                     * https://storage.googleapis.com/iapartment-bucket/images4.jpeg
                     * https://storage.googleapis.com/iapartment-bucket/images5.jpeg
                     * https://storage.googleapis.com/iapartment-bucket/images6.jpeg
                     * https://storage.googleapis.com/iapartment-bucket/images7.jpeg
                     * https://storage.googleapis.com/iapartment-bucket/images8.jpeg
                     * 
                     * */

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("upload file... ERROR:" + e.ToString());
                //throw;
            }
        }
    }
}