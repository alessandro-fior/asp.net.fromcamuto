using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsoCF.Models
{
    [Table("Aziende")]
    public class Azienda
    {
        [Key]
        public int aziendaID { get; set; }

        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        [StringLength(80, ErrorMessage = "Nome troppo lungo (max 80 caratteri)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il Telefono è obbligatorio")]
        [StringLength(15, ErrorMessage = "Numero telefonico troppo lungo (max 15 caratteri)")]
        public string Telefono { get; set; }

        public ICollection<Impiegato> Impiegati { get; set; }
    }

}