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
        public EmblemType Emblem { get; set; }  //Tdi, TFSI, FSI
        public int AmountCylinders { get; set; }
        public bool Turbo { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }

    public enum EngineType
    {
        Diesel,
        Petrol,
        Eletrical
    }

    public enum EmblemType
    {
        TFSI,
        TSI,
        FSI,
        TDI
    }
}