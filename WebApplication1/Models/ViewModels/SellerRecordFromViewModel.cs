using SalesWebMVC.Models.Entities;

namespace SalesWebMVC.Models.ViewModels
{
    public class SellerRecordFromViewModel
    {
        public Seller Seller { get; set; }
        public List<SalerRecord> SalesRecord { get; set; }

    }
}
