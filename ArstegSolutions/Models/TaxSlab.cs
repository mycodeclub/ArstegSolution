using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArstegSolutions.Models
{
    public class TaxSlab
    {
        [Key]
        public int SlabId { get; set; }

        [Required]
        [DisplayName("Start Amount")]
        [DataType(DataType.Currency)]
        public decimal StartAmount { get; set; }

        [DisplayName("End Amount")]
        [DataType(DataType.Currency)]
        //        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal EndAmount { get; set; }

        [Required]
        public int Percentage { get; set; }
    }
}