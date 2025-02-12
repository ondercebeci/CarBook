using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComementsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public ComementsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
           var values= _repository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Ekleme işlemi barıyla gerçekleşti");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Ekleme işlemi barıyla gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Ekleme işlemi barıyla gerçekleşti");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
          var values=  _repository.GetById(id);
            return Ok(values);
        }

    }
}
