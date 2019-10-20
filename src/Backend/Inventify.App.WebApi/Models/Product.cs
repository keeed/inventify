using System.ComponentModel.DataAnnotations;

namespace Inventify.App.WebApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}