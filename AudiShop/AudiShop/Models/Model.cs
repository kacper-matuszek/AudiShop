using AudiShop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public int CategoriaID { get; set; }
        public int EngineID { get; set; }

        [Required(ErrorMessage = "Enter model name.")]
        [Column("Name")]
        public string NameString
        {
            get => Name.ToString();
            set
            {
                Name = value.ParseEnum<ModelType>();
            }
        }
        [NotMapped]
        public ModelType Name { get; set; }

        [Required(ErrorMessage = "Car Drive is required.")]
        [Column("CarDrive")]
        public string CarDriveString
        {
            get => CarDrive.ToString();
            set
            {
                CarDrive = value.ParseEnum<CarDriveType>();
            }
        }

        [NotMapped]
        public CarDriveType CarDrive { get; set; }

        [Required(ErrorMessage = "Package is required.")]
        public string PackageString
        {
            get => Package.ToString();
            set
            {
                Package = value.ParseEnum<PackageType>();
            }
        }

        [NotMapped]
        public PackageType Package { get; set; }

        [Required(ErrorMessage = "Created Date is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Enter description.")]
        public string Description { get; set; }
        public string Color { get; set; }
        public string PictureName { get; set; }

        public decimal Price { get; set; }
        public bool Available { get; set; }

        //Categoria == UnderBody
        public virtual Categoria Categoria { get; set; }
        public virtual Engine Engine { get; set; }
    }

    public enum PackageType
    {
        Standard,
        Sportback,
        Advanced,
        [Display(Name = "S-Line")]
        SLine,
        Sport
    }

    public enum CarDriveType
    {
        Quattro,
        FrontAxle
    }

    public enum ModelType
    {
        A1,
        A3,
        A4,
        A5,
        A6,
        A7,
        A8,
        Q3,
        Q5,
        Q8,
        TT,
        R8
    }
}