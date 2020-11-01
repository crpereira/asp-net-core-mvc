using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;
        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // a base de dados já foi pupulado
            }

            Department d1 = new Department(1, "Financial");
            Department d2 = new Department(2, "HR");
            Department d3 = new Department(3, "Legal");
            Department d4 = new Department(4, "Comunication");

            Seller s1 = new Seller(1, "Bob", "bob@gmail.com", new DateTime(1998, 4, 22), 1000.0, d1);
            Seller s2 = new Seller(2, "Marta", "marta@gmail.com", new DateTime(1965, 7, 22), 500.0, d1);
            Seller s3 = new Seller(3, "Filipa", "filipa@gmail.com", new DateTime(1998, 12, 7), 1200.0, d4);
            Seller s4 = new Seller(4, "Zorro", "zorro@gmail.com", new DateTime(1994, 6, 22), 1350.0, d3);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 9, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 11, 25), 11500.0, SaleStatus.Canceled, s1);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2018, 9, 7), 100.0, SaleStatus.Pending, s2);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2018, 12, 25), 1000.0, SaleStatus.Billed, s3);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2018, 12, 7), 11600.0, SaleStatus.Billed, s4);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2018, 4, 2), 11070.0, SaleStatus.Billed, s3);
            SalesRecord sr7 = new SalesRecord(7, new DateTime(2018, 9, 1), 12000.0, SaleStatus.Canceled, s2);
            SalesRecord sr8 = new SalesRecord(8, new DateTime(2018, 1, 13), 100.0, SaleStatus.Billed, s2);
            SalesRecord sr9 = new SalesRecord(9, new DateTime(2018, 8, 25), 1800.0, SaleStatus.Billed, s1);
            SalesRecord sr10 = new SalesRecord(10, new DateTime(2018, 9, 25), 800.0, SaleStatus.Billed, s3);

            _context.Department.AddRangeAsync(d1, d2, d3, d4);
            _context.Seller.AddRangeAsync(s1, s2, s3, s4);
            _context.SalesRecord.AddRangeAsync(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10);

            _context.SaveChangesAsync();
        }

    }
}
