
using API.Domain.User;
using iPartmentApi.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iPartmentApi.Domain.RealState
{

    [Table("Imoveis")]
    public class RealState
    {
        

        public RealState(int iD, RealStateTypes tipo, string tamanho, int numeroSalas, int numeroBanheiros, int suites, bool mobiliado, bool aceitaPets, User moradorAtual, Adress localicazao, double valor)
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
        public int ID { get; set; }
        public RealStateTypes Tipo { get; set; }
        public string Tamanho { get; set; }
        public int NumeroSalas { get; set; }
        public int NumeroBanheiros { get; set; }
        public int Suites { get; set; }
        public bool Mobiliado { get; set; }
        public bool AceitaPets { get; set; }

        public bool Garagem { get; set; }

        public User? MoradorAtual { get; set; }
        public Adress localicazao { get; set; }

        //De repente, fazer uma lista so de valores
        public double valor { get; set; }



    }
}