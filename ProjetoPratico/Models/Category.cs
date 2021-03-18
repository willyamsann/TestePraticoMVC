using System.ComponentModel.DataAnnotations;

namespace ProjetoPratico.Models
{
    public class Category
    {
        [Key]
        public new int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

    }
}
