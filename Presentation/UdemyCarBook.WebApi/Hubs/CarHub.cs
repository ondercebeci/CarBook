using Microsoft.AspNetCore.SignalR;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCount");
                var value = await responseMessage2.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarCount", value);
              
            }
        }
    }

