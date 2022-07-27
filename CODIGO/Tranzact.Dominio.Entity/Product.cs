using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tranzact.Dominio.Entity
{
    [Table("PRODUCTS")]
    public class Products
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Column("product_name")]
        public string? Name { get; set; }
        [Column("brand_name")]
        public string? Brand { get; set; }
        public decimal Price { get; set; }
    }
}