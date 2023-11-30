using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        
        [Display(Name = "Membership Name")]
        public int memebrshiptypesId { get; set; }
        public ICollection<Movies>? Movies { get; set; }
        public memebrshiptypes? memebrshiptypes { get; set; }
    }
}
