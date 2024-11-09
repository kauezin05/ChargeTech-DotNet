using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChargeTechApi.Models
{
    [Table("CT_DISPOSITIVO")]
    public class Dispositivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_DISPOSITIVO { get; set; }

        [Required]
        public string NM_DISPOSITIVO { get; set; }

        public string IMAGEM_DISPOSITIVO { get; set; } 

        [Required]
        public double CONSUMO_MEDIO { get; set; }

        [Required]
        public string STATUS { get; set; } 

        [Required]
        public int ID_USUARIO { get; set; } 

        [Required]
        public int ID_AMBIENTE { get; set; } 
    }
}
