using API.src.Controllers.ViewModels;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary;
using API.src.Domain.Monetary.Entities;
using Newtonsoft.Json;
using System;

namespace API.src.Helpers
{
    public class AnnouncementTypeConverter : JsonConverter<AnnouncementViewModel<IMonetaryEntity>>
    {
        public override AnnouncementViewModel<IMonetaryEntity> ReadJson(JsonReader reader, Type objectType, AnnouncementViewModel<IMonetaryEntity> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, AnnouncementViewModel<IMonetaryEntity> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
