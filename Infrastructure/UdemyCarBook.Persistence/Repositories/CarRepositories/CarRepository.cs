﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public List<Car> GetCarListWithBrandName(int id)
        {
            var values = _context.Cars.Where(x => x.CarID == id).Include(y => y.Brand).ToList();
            return values;
        }

        public List<Car> GetCarListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }


        public List<Car> GetLast5CarsWithBrandS()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(y => y.CarID).Take(5).ToList();
            return values;
        }

        
    }
}
