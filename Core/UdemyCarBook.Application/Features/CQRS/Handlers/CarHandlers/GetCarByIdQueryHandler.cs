using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult>Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return  new GetCarByIdQueryResult
            {
                CarID = value.CarID,
                BigImageUrl = value.BigImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Laggage = value.Laggage,
                CoverImageUrl = value.CoverImageUrl,
                Model = value.Model,
                Seat = value.Seat,
                Transmission = value.Transmission,
                BrandID = value.BrandID
            };
        }
    }
}
