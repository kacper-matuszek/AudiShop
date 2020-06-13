using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.Data.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Enter your name.")]
        [StringLength(50, ErrorMessage = "Length of customer name cannot be under 50 chars.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your last name.")]
        [StringLength(50, ErrorMessage = "Length of customer last name cannot be under 50 chars.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your city.")]
        [StringLength(100, ErrorMessage = "Length of city cannot be under 100 chars.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your address.")]
        [StringLength(100, ErrorMessage = "Length of street cannot be under 100 chars.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter your postal code.")]
        [StringLength(6, ErrorMessage = "Length of postal code cannot be under 6 chars.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Enter your phone number")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "The format of phone number is incorrect")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Value { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Completed
    }
}