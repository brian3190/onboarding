using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onboarding.Models
{
    public class Customer
    {
        public Customer()
        {
            ProductSold = new HashSet<Sales>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Customer Address is required")]
        [StringLength(250)]
        public string Address { get; set; }

        public ICollection<Sales> ProductSold { get; set; }
    }
}
