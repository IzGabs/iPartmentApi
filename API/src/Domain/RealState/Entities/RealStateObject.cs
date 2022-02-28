
using API.Domain.User;
using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System;
using API.src.Core.Swagger;

namespace API.Domain.RealState.Models
{

    [Table("Imoveis")]
    public class RealStateObject
    {

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
            UserObject? moradorAtual,
            CondominiumObject? condominium,
            Address localicazao,
            double valor)
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
            this.localizacao = localicazao;
            this.valor = valor;
            this.Condominio = condominium;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public  int? ID { get; set; }

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

#pragma warning disable CS8632
        [SwaggerIgnore]
        public UserObject? MoradorAtual { get; set; }

        [SwaggerIgnore]
        public CondominiumObject? Condominio { get; set; } 

        [Required]
        public Address localizacao { get; set; }

        //De repente, fazer uma lista so de valores
        [Required]
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
                (this.localizacao == thisObj.localizacao);
        }

        public bool isCondoRequired() => this.Tipo == RealStateTypes.APARTMENT;
    }
}