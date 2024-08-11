using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Models.DTO
{
    public class CoffeeShopDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="Coffee Shop Name is Required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.", MinimumLength =5)]
        public string? CoffeeShopName { get; set; }
        [StringLength(150 , ErrorMessage = "Name length can't be more than 150.")]
        public string? CoffeeShopDescription { get; set; }
        public bool IsOpen { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
