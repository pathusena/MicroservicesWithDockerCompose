using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    [Table("product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Column("product_name")]
        [Required]
        public string ProductName { get; set; }

        [Column("price")]
        [Required]
        public decimal ProductPrice { get; set; }
    }
}
