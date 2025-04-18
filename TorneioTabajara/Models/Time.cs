using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorneioTabajara.Models
{
    public class Time
    {
        /*nome
cidade
estado
ano fundação
estádio
capacidade do estádio
Cores do Uniforme (primaria e secundária)
status*/
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int AnoFundacao { get; set; }
        public string Estadio { get; set; }
        public int CapacidadeEstadio { get; set; }
        public string CorPrimaria { get; set; }
        public string CorSecundaria { get; set; }
        public bool Status { get; set; } // Ativo ou Inativo
        public virtual ICollection<Comissao> Comissaos { get; set; } // Lista de comissões técnicas
        public virtual ICollection<Jogador> Jogadores { get; set; } // Lista de jogadores
    }
}