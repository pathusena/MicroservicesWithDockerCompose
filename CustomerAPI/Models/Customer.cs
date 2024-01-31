using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    [Table("customer", Schema = "dbo")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Required]
        [Column("customer_email")]
        public string CustomerEmail { get; set; }
    }
}
