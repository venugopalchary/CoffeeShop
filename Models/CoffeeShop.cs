using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopAPI.Models
{
    public class CoffeeShop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CoffeeShopName { get; set; } 
        public string? CoffeeShopDescription { get; set; }
        public bool IsOpen { get; set; }
        public DateTime CreationDateTime { get; set; }

        public bool IsActive { get; set;}
    }
}
