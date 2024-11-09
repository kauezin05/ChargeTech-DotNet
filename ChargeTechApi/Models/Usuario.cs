using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChargeTechApi.Models
{
    [Table("CT_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_USUARIO { get; set; }

        [Required]
        public string NM_USUARIO { get; set; }

        [Required]
        public string EMAIL_USUARIO { get; set; }

        [Required]
        public DateTime DT_NASCIMENTO_USUARIO { get; set; }

        [Required]
        public string SENHA_USUARIO { get; set; }

       
    }
}
