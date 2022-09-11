using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Infra.ML
{
    public class PredictSellDTO
    {

        public int AvgAreaIncome { get; set; }
        public int AvgAreaHouseAge { get; set; }
        public int NumberRooms { get; set; }
        public int AvgAreaBumberBedrooms { get; set; }
        public double AreaPopulation { get; set; }

        public PredictSellDTO(int avgAreaIncome, int avgAreaHouseAge, int numberRooms, int avgAreaBumberBedrooms, double areaPopulation)
        {
            AvgAreaIncome = avgAreaIncome;
            AvgAreaHouseAge = avgAreaHouseAge;
            NumberRooms = numberRooms;
            AvgAreaBumberBedrooms = avgAreaBumberBedrooms;
            AreaPopulation = areaPopulation;
        }
    }
}
