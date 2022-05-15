using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Infra.Bucket
{
    public class BucketConnectionObject
    {
        public string type;
        public string project_id;
        public string private_key_id;
        public string private_key;
        public string client_email;
        public string client_id;
        public string auth_uri;
        public string token_uri;
        public string auth_provider_x509_cert_url;
        public string client_x509_cert_url;

        public BucketConnectionObject(string type, string project_id, string private_key_id, string private_key, string client_email, string client_id, string auth_uri, string token_uri, string auth_provider_x509_cert_url, string client_x509_cert_url)
        {
            this.type = type;
            this.project_id = project_id;
            this.private_key_id = private_key_id;
            this.private_key = private_key;
            this.client_email = client_email;
            this.client_id = client_id;
            this.auth_uri = auth_uri;
            this.token_uri = token_uri;
            this.auth_provider_x509_cert_url = auth_provider_x509_cert_url;
            this.client_x509_cert_url = client_x509_cert_url;
        }

        public void InsertEnvValues(IConfiguration conf) {
            this.private_key_id = conf["private_key_id"];
            this.client_email = conf["client_email"];
            this.private_key = conf["private_key"];
            this.client_id = conf["client_id"];
        }
           
    }
}
