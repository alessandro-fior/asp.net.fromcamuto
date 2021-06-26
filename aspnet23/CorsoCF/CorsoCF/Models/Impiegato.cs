using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CorsoCF.Models
{
    [Table("Impiegati")]
    public class Impiegato
    {
        [Key]
        public int ImpiegatoID { get; set; }

        [Required(ErrorMessage = "Il Nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Nome troppo lungo (max 50 caratteri)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il Cognome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Cognome troppo lungo (max 50 caratteri)")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [DataType(DataType.EmailAddress, ErrorMessage = "L'email non è valida")]
        public string Email { get; set; }

        [Required]
        [Range(0, 5)]
        public int Livello { get; set; }

        public Nullable<int> FKaziendaID { get; set; }

        [ForeignKey("FKaziendaID")]
        public Azienda Azienda { get; set; }
    }


}