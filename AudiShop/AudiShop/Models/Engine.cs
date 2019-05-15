using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class Engine
    {
        public int EngineID { get; set; }

        [Required(ErrorMessage = "Enter engine capacity.")]
        public float Capacity { get; set; }

        [Required(ErrorMessage = "Enter engine horse power.")]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = "Enter kilowatt.")]
        public int KiloWat { get; set; }

        [Required(ErrorMessage = "Enter engine type.")]
        public EngineType Type { get; set; }
        public string Emblem { get; set; }  //Tdi, TFSI, FSI
        public bool Turbo { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }

    public enum EngineType
    {
        Diesel,
        Petrol,
        Eletrical
    }
}