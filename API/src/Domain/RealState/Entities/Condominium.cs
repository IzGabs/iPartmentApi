using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.RealState.Models
{

    [Table("Condominios")]
    public class Condominium
    {

        private Condominium() { }
        public Condominium(int iD, Address endereco, bool academia)
        {
            ID = iD;
            this.localizacao = endereco;
            Academia = academia;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public Address localizacao { get; set; }

        public bool Academia { get; set; }

    }
}