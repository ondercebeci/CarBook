using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResults>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResults> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCarDescriptionByCarId(request.Id);
            return new GetCarDescriptionByCarIdQueryResults
            {
                Details=values.Details,
                CarDescriptionID=values.CarDescriptionID,
                CarID=values.CarID
                
                
            };
        }
    }
}
