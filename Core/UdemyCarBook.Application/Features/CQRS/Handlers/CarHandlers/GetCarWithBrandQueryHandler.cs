using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetCarListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Laggage = x.Laggage,
                CoverImageUrl = x.CoverImageUrl,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,
                BrandID = x.BrandID

            }).ToList();
        }
    }
}
