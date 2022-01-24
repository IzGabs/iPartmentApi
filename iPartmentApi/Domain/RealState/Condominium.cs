using iPartmentApi.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iPartmentApi.Domain.RealState
{

    [Table("Condominios")]
    public class Condominium
    {
        public Condominium(int iD, Adress localicazao, bool academia)
        {
            ID = iD;
            this.localicazao = localicazao;
            Academia = academia;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public Adress localicazao { get; set; }

        public bool Academia { get; set; }

    }
}