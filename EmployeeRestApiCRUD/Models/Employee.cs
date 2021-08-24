using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRestApiCRUD.Models
{
    public class Employee
    {
        [key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name can only be 50 characters long")]
        public string Fullname { get; set; }

        public string Email { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Phone number can only be 15 characters long")]
        public string Mobile { get; set; }

        public string Location { get; set; }
    }
}
