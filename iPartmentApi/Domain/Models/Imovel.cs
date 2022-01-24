using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPIEntity.Models
{
    [Table("Imoveis")]
    public class Imovel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public User Corretor { get; set; }


        public bool Status { get; set; }


        public decimal Valor { get; set; }

        public int Area { get; set; }
        public int Dormitorios { get; set; }
        public int Banheiros { get; set; }
        public int Vagas { get; set; }

        //public TipoImovel Tipo { get; set; }


        //      [ForeignKey("CaracteristicaImovelFK")]
        //    public List<CaracteristicaImovel> Caracteristicas { get; set; }


        //  public List<PropostaImovel> Propostas { get; set; }
    }
}
