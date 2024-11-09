using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChargeTechApi.Models
{
    [Table("CT_AMBIENTE")]
    public class Ambiente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_AMBIENTE { get; set; }

        [Required]
        public string NM_AMBIENTE { get; set; } 

        public string DESC_AMBIENTE { get; set; }
    }
}
