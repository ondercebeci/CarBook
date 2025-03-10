using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            this._mediator = mediator;
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
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var values = _repository.GetCommentsByBlogId(id);
            return Ok(values);
        }
        [HttpGet("CommentCountByBlog")]
        public IActionResult CommentCountByBlog(int id)
        {
            var values = _repository.GetCountCommentByBlg(id);
            return Ok(values);
        }
        [HttpPost("CreateCommentWithMediator")]
        public async Task< IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarıyla eklendi.");
        }

    }
}
