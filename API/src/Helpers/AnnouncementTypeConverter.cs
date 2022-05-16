using API.src.Domain.Announcement.Entities;
using Newtonsoft.Json;
using System;

namespace API.src.Helpers
{
    public class AnnouncementTypeConverter : JsonConverter<AnnouncementType>
    {
        public override AnnouncementType ReadJson(JsonReader reader, Type objectType, AnnouncementType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return null;

            //return new AnnouncementSellType();
        }

        public override void WriteJson(JsonWriter writer, AnnouncementType value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
