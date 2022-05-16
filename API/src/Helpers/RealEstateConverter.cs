using API.src.Domain.RealState.Entities;
using Newtonsoft.Json;
using System;

namespace API.src.Infra
{
    public class ConverterTypeRealEstate : JsonConverter<TypeRealEstate>
    {
        public override TypeRealEstate ReadJson(JsonReader reader, Type objectType, TypeRealEstate existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var @enum = (RealEstateTypesEnum)Enum.ToObject(typeof(RealEstateTypesEnum), reader.Value);

            return new TypeRealEstate(@enum);
        }

        public override void WriteJson(JsonWriter writer, TypeRealEstate value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
