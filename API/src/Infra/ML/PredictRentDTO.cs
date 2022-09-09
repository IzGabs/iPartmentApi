namespace API.src.Infra.ML
{
    public class PredictRentDTO
    {
        public int Area { get; set; }
        public int Quartos { get; set; }
        public int Banheiros { get; set; }
        public int VagaGaregem { get; set; }
        public float IPTU { get; set; }

        public PredictRentDTO(int area, int quartos, int banheiros, int vagaGaregem, float iPTU)
        {
            Area = area;
            Quartos = quartos;
            Banheiros = banheiros;
            VagaGaregem = vagaGaregem;
            IPTU = iPTU;
        }
    }
}
