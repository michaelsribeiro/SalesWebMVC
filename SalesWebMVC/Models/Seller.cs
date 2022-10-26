using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size must be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Base Salary")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        public Departments Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentsId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departments department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sale)
        {
            Sales.Add(sale);
        }

        public void RemoveSales(SalesRecord sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales
                   .Where(sale => sale.Date >= initial && sale.Date <= final)
                   .Sum(sale => sale.Amount);
        }
    }
}
