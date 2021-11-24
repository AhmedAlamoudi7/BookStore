using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WEB.Model
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1,100,ErrorMessage ="Dislplay Order must be in range 1 to 100 !")]
        public int DisplayOrder { get; set; }
    }
}
