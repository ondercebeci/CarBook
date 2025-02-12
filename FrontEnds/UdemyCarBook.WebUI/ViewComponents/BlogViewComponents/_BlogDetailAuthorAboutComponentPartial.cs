using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.TagCloudDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorAboutComponentPartial:ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7254/api/Blogs/GetBlogByAuthorId?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetAuthorByBlogIdDto>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
