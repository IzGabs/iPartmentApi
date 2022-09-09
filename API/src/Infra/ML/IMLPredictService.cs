using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.src.Infra.ML
{
    public interface IMLPredictService
    {
        public Task<double> Rent(PredictRentDTO obj);
        public Task<double> Sell(PredictSellDTO obj);

    }

    public class MLPredictService : IMLPredictService
    {
        private HttpClient client = new HttpClient();

        private string APiPath = "http://167.172.136.170:5000/";


        public async Task<double> Rent(PredictRentDTO obj)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync($"{APiPath}/predict_aluguel", obj);

                var value = await response.Content.ReadAsStringAsync();

                return double.Parse(value);
            }
            catch (Exception e)
            {
                return 0;
            }


        }



        public async Task<double> Sell(PredictSellDTO obj)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync($"{APiPath}/predict_venda", obj);

                var value = await response.Content.ReadAsStringAsync();

                return double.Parse(value);
            }
            catch
            {
                return 0;
            }

        }
    }
}
