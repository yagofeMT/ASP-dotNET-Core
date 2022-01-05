using SalesWebMVC.Models.Entities;
using SalesWebMVC.Models.Entities.Enum;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public string Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalerRecord.Any())
            {
                return "Ja populado";
            }

            Department d1 = new Department("Computers");
            Department d2 = new Department("Electronics");
            Department d3 = new Department("Fashion");
            Department d4 = new Department("Books");

            Seller s1 = new Seller("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalerRecord r1 = new SalerRecord(new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalerRecord r2 = new SalerRecord(new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, s5);
            SalerRecord r3 = new SalerRecord(new DateTime(2018, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            SalerRecord r4 = new SalerRecord(new DateTime(2018, 09, 1), 8000.0, SaleStatus.Billed, s1);
            SalerRecord r5 = new SalerRecord(new DateTime(2018, 09, 21), 3000.0, SaleStatus.Billed, s3);
            SalerRecord r6 = new SalerRecord(new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, s1);
            SalerRecord r7 = new SalerRecord(new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, s2);
            SalerRecord r8 = new SalerRecord(new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, s4);
            SalerRecord r9 = new SalerRecord(new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pending, s6);
            SalerRecord r10 = new SalerRecord(new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, s6);
            SalerRecord r11 = new SalerRecord(new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, s2);
            SalerRecord r12 = new SalerRecord(new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pending, s3);
            SalerRecord r13 = new SalerRecord(new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s4);
            SalerRecord r14 = new SalerRecord(new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, s5);
            SalerRecord r15 = new SalerRecord(new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, s1);
            SalerRecord r16 = new SalerRecord(new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, s4);
            SalerRecord r17 = new SalerRecord(new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, s1);
            SalerRecord r18 = new SalerRecord(new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, s3);
            SalerRecord r19 = new SalerRecord(new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, s5);
            SalerRecord r20 = new SalerRecord(new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, s6);
            SalerRecord r21 = new SalerRecord(new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, s2);
            SalerRecord r22 = new SalerRecord(new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, s4);
            SalerRecord r23 = new SalerRecord(new DateTime(2018, 10, 19), 11000.0, SaleStatus.Canceled, s2);
            SalerRecord r24 = new SalerRecord(new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, s5);
            SalerRecord r25 = new SalerRecord(new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, s3);
            SalerRecord r26 = new SalerRecord(new DateTime(2018, 10, 6), 5000.0, SaleStatus.Billed, s4);
            SalerRecord r27 = new SalerRecord(new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pending, s1);
            SalerRecord r28 = new SalerRecord(new DateTime(2018, 10, 7), 4000.0, SaleStatus.Billed, s3);
            SalerRecord r29 = new SalerRecord(new DateTime(2018, 10, 23), 12000.0, SaleStatus.Billed, s5);
            SalerRecord r30 = new SalerRecord(new DateTime(2018, 10, 12), 5000.0, SaleStatus.Billed, s2);


            _context.Department.AddRange(d1,d2,d3,d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalerRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();

            return "OK";
        }
    }
}
