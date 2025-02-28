using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResult;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceForMountlyQueryHandler : IRequestHandler<GetAvgRentPriceForMountlyQuery, GetAvgRentPriceForMountlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForMountlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMountlyQueryResult> Handle(GetAvgRentPriceForMountlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForMountly();
            return new GetAvgRentPriceForMountlyQueryResult
            {
                AvgRentPriceForMountly = value
            };
        }
    
    }
}
