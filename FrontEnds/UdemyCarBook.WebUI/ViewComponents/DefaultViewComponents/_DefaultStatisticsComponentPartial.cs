using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region Araç Sayısı İstatistik 
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.carCount = values.carCount;
            }
            #endregion
            #region Lokasyon Sayısı İstatistik 
            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.LocationCount = values.locationCount;
            }
            #endregion

            #region Marka Sayısı İstatistik 
            var responseMessage5 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.brandCount = values.brandCount;
            }
            #endregion

            #region Elektrikli araba sayısı İstatistik 
            var responseMessage14 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData14);
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectric;
            }
            #endregion
            return View();
        }
    }
}
