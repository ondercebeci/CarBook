using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarListWithBrandNameQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarListWithBrandNameQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarListWithBrandNameQueryResult>Handle(GetCarListWithBrandNameQuery query)
        {
            var values = _repository.GetCarListWithBrandName(query.Id);
            return values.Select(x => new GetCarListWithBrandNameQueryResult
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
