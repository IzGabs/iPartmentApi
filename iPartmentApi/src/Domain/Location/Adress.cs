using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace API.Domain.Location
{

    [Table("Enderecos")]
    public class Adress
    {

        private Adress() { }

        public Adress(int? ID, string cep, string numero, string complemento) {
            this.ID = ID;
            this.Cep = cep;
            this.Numero = numero;
            this.Complemento = complemento;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        public string Cep { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

    }
}