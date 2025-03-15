using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarListWithBrandNameQuery
    {
        public int Id { get; set; }

        public GetCarListWithBrandNameQuery(int id)
        {
            Id = id;
        }
    }
}
