using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.Data.Models
{
    public class Engine
    {
        public int EngineID { get; set; }

        public int Code { get; set; }

        [Required(ErrorMessage = "Enter engine capacity.")]
        public float Capacity { get; set; }

        [Required(ErrorMessage = "Enter engine horse power.")]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = "Enter kilowatt.")]
        public int KiloWat { get; set; }

        [Required(ErrorMessage = "Enter engine type.")]
        public string Type { get; set; }
        public string Emblem { get; set; }  //Tdi, TFSI, FSI, 20V itp.
        public int AmountCylinders { get; set; }
        public bool Turbo { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }

}