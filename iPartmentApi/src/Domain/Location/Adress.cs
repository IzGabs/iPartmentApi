using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace iPartmentApi.Domain.Location
{

    [Table("Enderecos")]
    public class Adress
    {
        public Adress() { }
        public Adress(int? ID, string cep, string numero, string complemento, string valorIPTU) {
            this.ID = ID;
            this.CEP = cep;
            this.Numero = numero;
            this.Complemento = complemento;
            this.valorIPTU = valorIPTU;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        public string CEP { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string valorIPTU { get; set; }

    }
}