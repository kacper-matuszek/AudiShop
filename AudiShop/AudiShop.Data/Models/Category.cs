using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.Data.Models
{
    //UnderBody Type
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Enter category name.")]
        [StringLength(100, ErrorMessage = "Length of category name cannot be under 100 chars.")]
        public string Name { get; set; }
        public string PictureName { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}