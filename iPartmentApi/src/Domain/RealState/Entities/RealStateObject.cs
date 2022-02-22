
using API.Domain.User;
using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.RealState.Models
{

    [Table("Imoveis")]
    public class RealStateObject
    {

        private RealStateObject() { }

        public RealStateObject(int? iD, RealStateTypes tipo, string tamanho, int numeroSalas, int numeroBanheiros, int suites, bool mobiliado, bool aceitaPets, UserObject moradorAtual, Adress localicazao, double valor)
        {
            ID = iD;
            Tipo = tipo;
            Tamanho = tamanho;
            NumeroSalas = numeroSalas;
            NumeroBanheiros = numeroBanheiros;
            Suites = suites;
            Mobiliado = mobiliado;
            AceitaPets = aceitaPets;
            MoradorAtual = moradorAtual;
            this.localicazao = localicazao;
            this.valor = valor;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        [Required]
        public RealStateTypes Tipo { get; set; }
        public string Tamanho { get; set; }
        [Required]
        public int NumeroSalas { get; set; }

        [Required] 
        public int NumeroBanheiros { get; set; }
        
        public int Suites { get; set; }
        public bool Mobiliado { get; set; }
        public bool AceitaPets { get; set; }

        public bool Garagem { get; set; }

        public UserObject? MoradorAtual { get; set; }
        [Required]
        public Adress localicazao { get; set; }

        //De repente, fazer uma lista so de valores
        public double valor { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is RealStateObject)) return false;

            var thisObj = obj as RealStateObject;

            if (this.ID == thisObj.ID) return true;

            return (this.ID == thisObj.ID) &&
                (this.Tipo == thisObj.Tipo) &&
                (this.Tamanho == thisObj.Tamanho) &&
                (this.NumeroSalas == thisObj.NumeroSalas) &&
                (this.NumeroBanheiros == thisObj.NumeroBanheiros) &&
                (this.Suites == thisObj.Suites) &&
                (this.Mobiliado == thisObj.Mobiliado) &&
                (this.AceitaPets == thisObj.AceitaPets) &&
                (this.Garagem == thisObj.Garagem) &&
                (this.localicazao == thisObj.localicazao);
        }


    }
}