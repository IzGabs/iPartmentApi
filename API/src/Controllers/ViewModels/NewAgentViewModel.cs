using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.src.Controllers.ViewModels
{
    public class NewAgentViewModel
    {
        [Required]
        [FromQuery]
        public string CRECIID { get; set; }

        [Required]
        [FromQuery]
        public int userID { get; set; }

        [Required]
        [FromForm]
        public IFormFile image { get; set; }

    }
}

