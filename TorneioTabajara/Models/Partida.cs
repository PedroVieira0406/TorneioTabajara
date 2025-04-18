using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneioTabajara.Models
{
    public class Partida
    {
        public int Id { get; set; }
        public int Rodada { get; set; }
        public int Time1Id { get; set; }
        public virtual Time Time1 { get; set; }
        public int Time2Id { get; set; }
        public virtual Time Time2 { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataHora { get; set; }
        public int EstatisticaJogoId { get; set; }
        public virtual EstatisticaJogo EstatisticaJogo { get; set; }
    }
}
