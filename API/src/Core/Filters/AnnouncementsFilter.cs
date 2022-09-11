using API.src.Domain.Announcement.Entities;
using API.src.Domain.RealState.Entities;

namespace API.src.Core.Filters
{
    public class AnnouncementsFilter
    {
        public AnnouncementTypeEnum AnnouncementType { get; set; }

        public FilterInterval<float> ValueFilter { get; set; }
        public FilterInterval<int> AreaFilter { get; set; }

        public int dorms { get; set; }
        public int bathrooms { get; set; }
        public bool garage { get; set; }

        public RealEstateTypesEnum Type { get; set; }
        public bool pets { get; set; }
        public bool furnished { get; set; }

        public AnnouncementsFilter(AnnouncementTypeEnum announcementType, FilterInterval<float> valueFilter, FilterInterval<int> areaFilter, int dorms, int bathrooms, bool garage, RealEstateTypesEnum type, bool pets, bool furnished)
        {
            AnnouncementType = announcementType;
            ValueFilter = valueFilter;
            AreaFilter = areaFilter;
            this.dorms = dorms;
            this.bathrooms = bathrooms;
            this.garage = garage;
            Type = type;
            this.pets = pets;
            this.furnished = furnished;
        }
    }
}
