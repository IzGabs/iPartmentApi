using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary;
using API.src.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers.ViewModels
{
    //[JsonConverter(typeof(AnnouncementTypeConverter))]
    public class AnnouncementViewModel<T> where T : IMonetaryEntity
    {
        [Required]
        public int idRealEstate { get; set; }
        [Required]
        public int idAdvertiser { get; set; }
        [Required]
        public AnnouncementValueObject announcement { get; set; }
        [Required]
        public T monetary { get; set; }
    }
}
