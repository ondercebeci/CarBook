using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        
        List<Car> GetCarListWithBrandName(int id);
        List<Car> GetCarListWithBrands();
        List<Car> GetLast5CarsWithBrandS();
       int GetCarCount();
      
    }
}
