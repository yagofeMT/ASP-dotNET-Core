

using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models.Entities
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "{0} Size Should Be Between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalerRecord> SalesRecords { get; set; } = new List<SalerRecord>();

        public Seller() { }
        public Seller(string name, string email, DateTime birthdate, double salary, Department department)
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
            Salary = salary;
            Department = department;
        }

        public void AddSalary(SalerRecord salesRecord)
        {
            SalesRecords.Add(salesRecord);
        }

        public void RemoveSalary(SalerRecord salesRecord)
        {
            SalesRecords.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
