using API.src.Domain.RealState.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.src.Controllers.ViewModels
{
    public class RealStateWithCondoViewModels
    {
        [Required]
        public RealStateObject realState { get; set; }

        [Required]
        public int idCondominio { get; set; }
    }
}
