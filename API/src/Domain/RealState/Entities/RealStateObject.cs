
using API.Domain.User;
using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.src.Core.Swagger;
using API.Domain.RealState.Models;
using API.src.Domain.Monetary.Entities;

namespace API.src.Domain.RealState.Entities
{

    [Table("Imoveis")]
    public class RealStateObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public RealStateTypes Tipo { get; set; }
        [Required]
        public string Tamanho { get; set; }
        [Required]
        public int NumeroSalas { get; set; }
        [Required]
        public int NumeroBanheiros { get; set; }
        public int Suites { get; set; }
        [Required]
        public bool Mobiliado { get; set; }
        [Required]
        public bool AceitaPets { get; set; }
        [Required]
        public bool Garagem { get; set; }

        [SwaggerIgnore]
        public UserObject MoradorAtual { get; set; }

        [Required]
        public Address localizacao { get; set; }

        [Required]
        public RealStateMonetary valores { get; set; }

        public RealStateObject() { }
        public RealStateObject(
            int? iD,
            RealStateTypes tipo,
            string tamanho,
            int numeroSalas,
            int numeroBanheiros,
            int suites,
            bool mobiliado,
            bool aceitaPets,
            UserObject moradorAtual,
            Address localicazao,
            RealStateMonetary valores)
        {

            this.ID = iD;
            this.Tipo = tipo;
            this.Tamanho = tamanho;
            this.NumeroSalas = numeroSalas;
            this.NumeroBanheiros = numeroBanheiros;
            this.Suites = suites;
            this.Mobiliado = mobiliado;
            this.AceitaPets = aceitaPets;
            this.MoradorAtual = moradorAtual;
            this.localizacao = localicazao;
            this.valores = valores;
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is RealStateObject)) return false;

            var thisObj = obj as RealStateObject;

            if (ID == thisObj.ID) return true;

            return ID == thisObj.ID &&
                Tipo == thisObj.Tipo &&
                Tamanho == thisObj.Tamanho &&
                NumeroSalas == thisObj.NumeroSalas &&
                NumeroBanheiros == thisObj.NumeroBanheiros &&
                Suites == thisObj.Suites &&
                Mobiliado == thisObj.Mobiliado &&
                AceitaPets == thisObj.AceitaPets &&
                Garagem == thisObj.Garagem &&
                localizacao == thisObj.localizacao;
        }

        public bool isCondoRequired() => Tipo == RealStateTypes.APARTMENT;
    }
}