using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.ViewModels
{
    public class CarPricingViewModel
    {
        //public CarPricingViewModel()
        //{
        //    Amounts = new List<decimal>();
        //}
        //public string Model { get; set; }
        //public List<Decimal> Amounts { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MontlyAmount { get; set; }
    }
}
