using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionByCarIdQueryResults
    {
        public int CarDescriptionID { get; set; }
        public string Details { get; set; }
        public int CarID { get; set; }
    }
}
