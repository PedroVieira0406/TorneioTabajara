using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TorneioTabajara.Models
{
    public enum Posicao
    {
        goleiro,
        zagueiro,
        lateral,
        volante,
        meioCampista,
        meiasAtacante,
        ponta,
        atacante
    }
    public enum PePreferido
    {
        Esquerdo,
        Direito,
        Ambidestro
    }
    public class Jogador
    {
        /*nome
data de nascimento
nacionalidade
posição (enum: goleiro, zagueiro, volante, meia, atacante etc)
número da camisa
altura
peso
pé preferido (enum: esquerdo, direito, ambidestro)
Time*/
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public int Camisa { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public int TimeId { get; set; } // Isso é a foreign key
        public virtual Time Time { get; set; } // Isso é a navigation property
        public PePreferido PePreferido { get; set; }
    }
}