using SalesWebMVC.Models.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models.Entities
{
    public class SalerRecord
    {
        public int Id { get; set; }

        [Display]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public int SellerId { get; set;}

        public SalerRecord() { }
        public SalerRecord(DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Seller = seller;
            Date = date;
            Amount = amount;
            Status = status;
        }
    }
}
