using SalesWebMVC.Models.Entities;

namespace SalesWebMVC.Models.ViewModels
{
    public class SellerFromViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }


    }
}
