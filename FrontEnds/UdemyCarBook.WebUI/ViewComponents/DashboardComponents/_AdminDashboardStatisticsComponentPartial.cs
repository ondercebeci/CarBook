using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random rnd = new Random();
            var client = _httpClientFactory.CreateClient();

            #region Araç Sayısı İstatistik 
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int carCountRandom = rnd.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.carCountRandom = carCountRandom;
                ViewBag.carCount = values.carCount;
            }
            #endregion

            #region Lokasyon Sayısı İstatistik 
            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = rnd.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.locationCountRandom = locationCountRandom;
                ViewBag.LocationCount = values.locationCount;
            }
            #endregion


            #region Marka Sayısı İstatistik 
            var responseMessage3 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int brandCountRandom = rnd.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.brandCountRandom = brandCountRandom;
                ViewBag.brandCount = values.brandCount;
            }
            #endregion

            #region Ortalama Günlük Kiralama Ücreti İstatistik 
            var responseMessage4 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = rnd.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
                ViewBag.avgRentPriceForDaily = values.avgRentPriceForDaily.ToString("0.00");
            }
            #endregion


            return View();
        }
    }
}
