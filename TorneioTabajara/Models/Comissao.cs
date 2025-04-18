using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TorneioTabajara.Models
{
    public class Comissao
    {/*nome
cargo (enum: treinador, auxiliar, preparador físico, fisiologista, treinador de goleiros e fisioterapeuta)
data nascimento
time*/
        public int Id { get; set; }

        public int TimeId { get; set; } // Isso é a foreign key
        public virtual Time Time { get; set; } // Isso é a navigation property

        public string Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
    }
}