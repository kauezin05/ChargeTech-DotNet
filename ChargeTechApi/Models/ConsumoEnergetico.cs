using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChargeTechApi.Models
{
    [Table("CT_CONSUMO_ENERGETICO")]
    public class ConsumoEnergetico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CONSUMO_ENERGETICO { get; set; } 

        [Required]
        public int ID_DISPOSITIVO { get; set; } 

        [Required]
        public DateTime DATA_REGISTRO { get; set; } 

        [Required]
        public double CONSUMO { get; set; } 

        [Required]
        public decimal CUSTO_ESTIMADO { get; set; } 

        [Required]
        public decimal CUSTO_CONSUMO { get; set; } 
    }
}
