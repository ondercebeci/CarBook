using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarID);
            values.CarID = command.CarID;
            values.BigImageUrl = command.BigImageUrl;
            values.Fuel = command.Fuel;
            values.Km = command.Km;
            values.Laggage = command.Laggage;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Model = command.Model;
            values.Seat = command.Seat;
            values.Transmission = command.Transmission;
            values.BrandID = command.BrandID;
            await _repository.UptdateAsync(values); 
        }
    }
}
