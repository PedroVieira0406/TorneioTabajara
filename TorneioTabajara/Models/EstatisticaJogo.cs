using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TorneioTabajara.Models
{
    public class EstatisticaJogo
    {
        [Key, ForeignKey("Partida")]
        public int PartidaId { get; set; }

        public virtual Partida Partida { get; set; }

        [Display(Name = "Placar Time 1")]
        public int PlacarTime1 { get; set; }

        [Display(Name = "Placar Time 2")]
        public int PlacarTime2 { get; set; }

        // Lista de gols feitos durante o jogo
        public virtual ICollection<Gol> Gols { get; set; } = new List<Gol>();
    }
    public class Gol
    {
        public int Id { get; set; }

        // Jogador que fez o gol
        [ForeignKey("Jogador")]
        public int JogadorId { get; set; }
        public virtual Jogador Jogador { get; set; }

        // FK para a estatística (opcional, mas recomendável para navegação inversa)
        [ForeignKey("EstatisticaJogo")]
        public int EstatisticaJogoId { get; set; }
        public virtual EstatisticaJogo EstatisticaJogo { get; set; }

        // Tempo em que o gol foi marcado (ex: 23 minutos)
        public int Minuto { get; set; }

        // Pode ser útil saber se foi contra, pênalti etc. (opcional)
        public string TipoGol { get; set; } // Ex: "Normal", "Pênalti", "Contra"
    }
}