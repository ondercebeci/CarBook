using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Enum;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {

            var values = _context.CarPricings.Include(x => x.Pricing).Include(y => y.Car).ThenInclude(x => x.Brand).Where(z => z.PricingID == 2).ToList();
            return values;
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            var values = from cp in _context.CarPricings
                         join c in _context.Cars on cp.CarID equals c.CarID
                         join b in _context.Brands on c.BrandID equals b.BrandID
                         group cp by new { b.Name, c.Model, c.CoverImageUrl } into grouped
                         select new CarPricingViewModel
                         {
                             Model = grouped.Key.Name + " " + grouped.Key.Model,
                             CoverImageUrl = grouped.Key.CoverImageUrl,
                             DailyAmount = grouped.Where(x => x.PricingID == (int)PricingType.Daily).Sum(y => y.Amount),
                             WeeklyAmount = grouped.Where(x => x.PricingID == (int)PricingType.Weekly).Sum(y => y.Amount),
                             MontlyAmount = grouped.Where(x => x.PricingID == (int)PricingType.Mountly).Sum(y => y.Amount),
                         };
            return values.ToList();

            //List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            //using (var command = _context.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = "Select * From (Select Model,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPiricings.CarID Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
            //    command.CommandType = System.Data.CommandType.Text;
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while(reader.Read())
            //        {
            //            CarPricingViewModel carPricingViewModel = new CarPricingViewModel();
            //            Enumerable.Range(1, 3).ToList().ForEach(x =>
            //            {
            //                if (DBNull.Value.Equals(reader[x]))
            //                {
            //                    carPricingViewModel.Amounts.Add(0);
            //                }
            //                else
            //                {
            //                    carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
            //                }
            //            });
            //            values.Add(carPricingViewModel);
            //        }
            //    }
            //    _context.Database.CloseConnection();
            //    return values;
            //}
        }
    }
}
