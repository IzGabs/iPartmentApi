using API.src.Infra.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.RealState.Entities
{
    public enum RealEstateTypesEnum
    {
        APARTMENT= 0,
        HOUSE = 1, 
        KITNET = 2, 
        STUDIO = 3,
    }

    public class TypeRealEstate {
        protected TypeRealEstate() { }

        private TypeRealEstate(RealEstateTypesEnum @enum) {
            this.Id = (int)@enum;
            this.Name = @enum.ToString();
            this.Description = @enum.GetEnumDescription();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public static implicit operator TypeRealEstate(RealEstateTypesEnum @enum) => new TypeRealEstate(@enum);
        public static implicit operator RealEstateTypesEnum(TypeRealEstate estateType) => (RealEstateTypesEnum)estateType.Id;
    }
} 
