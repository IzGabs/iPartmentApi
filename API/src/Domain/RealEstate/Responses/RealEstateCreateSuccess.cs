namespace API.src.Domain.Announcement.Application
{
    public class RealEstateCreateSuccess
    {
        public int id { get; set; }
        public double predictedValue { get; set; }

        public RealEstateCreateSuccess(int id, double predictedValue)
        {
            this.id = id;
            this.predictedValue = predictedValue;
        }
    }
}
