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
    public class GetCarCountBySmallerThen1000QueryHandler : IRequestHandler<GetCarCountBySmallerThen1000Query, GetCarCountBySmallerThen1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountBySmallerThen1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountBySmallerThen1000QueryResult> Handle(GetCarCountBySmallerThen1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountBySmallerThen1000();
            return new GetCarCountBySmallerThen1000QueryResult
            {
                CarCountBySmallerThen1000 = value
            };
        }
    
    }
}
