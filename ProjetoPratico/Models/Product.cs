using System.ComponentModel.DataAnnotations;

namespace ProjetoPratico.Models
{
    public class Product
    {
        [Key]
        public new int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preencha o campo Descrição")]


        public string Description { get; set; }

        [Display(Name = "Ativo")]

        public bool Active { get; set; }

        [Display(Name = "Peresivel")]

        public bool Perishable { get; set; }

        [Display(Name = "Id Categoria")]

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
