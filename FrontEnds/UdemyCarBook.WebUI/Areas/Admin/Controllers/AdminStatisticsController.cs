using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        
        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region Yazar Sayısı İstatistik 
            var responseMessage3 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.AuthorCountRandom = AuthorCountRandom;
                ViewBag.authorCount = values.authorCount;
            }
            #endregion

            #region Blog Sayısı İstatistik 
            var responseMessage4 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = rnd.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.blogCountRandom = blogCountRandom;
                ViewBag.blogCount = values.blogCount;
            }
            #endregion

            #region Marka Sayısı İstatistik 
            var responseMessage5 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = rnd.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.brandCountRandom = brandCountRandom;
                ViewBag.brandCount = values.brandCount;
            }
            #endregion

            #region Ortalama Günlük Kiralama Ücreti İstatistik 
            var responseMessage6 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = rnd.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
                ViewBag.avgRentPriceForDaily = values.avgRentPriceForDaily.ToString("0.00");
            }
            #endregion

            #region Ortalama Haftalık Kiralama Ücreti İstatistik 
            var responseMessage8 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = rnd.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
                ViewBag.avgRentPriceForWeekly = values.avgRentPriceForWeekly.ToString("0.00");
            }
            #endregion

            #region Ortalama Aylık Kiralama Ücreti İstatistik 
            var responseMessage7 = await client.GetAsync("https://localhost:7254/api/Statistics/GetAvgRentPriceForMountly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgRentPriceForMountlyRandom = rnd.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
                ViewBag.avgRentPriceForMountlyRandom = avgRentPriceForMountlyRandom;
                ViewBag.avgRentPriceForMountly = values.avgRentPriceForMountly.ToString("0.00");
            }
            #endregion

            #region Otomatik vites olan araba sayısı İstatistik 
            var responseMessage9 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByTransmissionIsAutoRandom = rnd.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData9);
                ViewBag.carCountByTransmissionIsAutoRandom = carCountByTransmissionIsAutoRandom;
                ViewBag.carCountByTransmissionIsAuto = values.carCountByTransmissionIsAuto;
            }
            #endregion

            #region En Pahalı Günlük Kiralık Araba İstatistik 
            var responseMessage10 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMaxRandom = rnd.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData10);
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
                ViewBag.carBrandAndModelByRentPriceDailyMax = values.carBrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region En Ucuz Günlük Kiralık Araba İstatistik 
            var responseMessage11 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMinRandom = rnd.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData11);
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
                ViewBag.carBrandAndModelByRentPriceDailyMin = values.carBrandAndModelByRentPriceDailyMin;
            }
            #endregion

            #region Km'si 1000Km'den Az araba sayısı İstatistik 
            var responseMessage12 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountBySmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountBySmallerThen1000Random = rnd.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData12);
                ViewBag.carCountBySmallerThen1000Random = carCountBySmallerThen1000Random;
                ViewBag.carCountBySmallerThen1000 = values.carCountBySmallerThen1000;
            }
            #endregion

            #region Benzin veya Dizel araba sayısı İstatistik 
            var responseMessage13 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselRandom = rnd.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData13);
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
                ViewBag.carCountByFuelGasolineOrDiesel = values.carCountByFuelGasolineOrDiesel;
            }
            #endregion

            #region Elektrikli araba sayısı İstatistik 
            var responseMessage14 = await client.GetAsync("https://localhost:7254/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = rnd.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData14);
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectric;
            }
            #endregion

            #region En Fazla Araçlı Marka Adı İstatistik 
            var responseMessage15 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int brandNameByMaxCarRandom = rnd.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData15);
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
                ViewBag.brandNameByMaxCar = values.brandNameByMaxCar;
            }
            #endregion

            #region En Fazla Yorum Alan Blog Adı İstatistik 
            var responseMessage16 = await client.GetAsync("https://localhost:7254/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int blogTitleByMaxBlogCommentRandom = rnd.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData16);
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
                ViewBag.blogTitleByMaxBlogComment = values.blogTitleByMaxBlogComment;
            }
            #endregion

            return View();
        }
    }
}
