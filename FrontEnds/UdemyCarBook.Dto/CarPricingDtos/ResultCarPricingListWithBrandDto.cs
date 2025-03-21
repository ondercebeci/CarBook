﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingListWithBrandDto
    {
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MontlyAmount { get; set; }
    }
}
