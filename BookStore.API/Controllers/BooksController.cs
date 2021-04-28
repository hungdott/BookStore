using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.API.ModelDTO;
using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }

        // GET: api/<Books>
        [HttpGet("getall")]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _unitOfWork.Books.GetAll();
        }

        [HttpGet]
        public IEnumerable<Book> GetByGenre([FromQuery] string Genre)
        {
            return _unitOfWork.Books.GetBooksByGenre(Genre);
        }

        // GET api/<Books>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _unitOfWork.Books.Get(id);
        }

        // POST api/<Books>
        [HttpPost]
        public IActionResult Post([FromBody] BookDto bookReq)
        {

            var bookDto = _mapper.Map<Book>(bookReq);
            _unitOfWork.Books.Add(bookDto);
           
            _unitOfWork.Complete();
            return Ok();
        }

        // PUT api/<Books>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromQuery] BookDto bookReq)
        {
            var book = await _unitOfWork.Books.Get(id);
            if (book==null)
            {
                return BadRequest("Wrong ip book");
            }
            await _unitOfWork.Books.Add(_mapper.Map<Book>(bookReq));
            _unitOfWork.Complete();
            return Ok("update complete");
        }

        // DELETE api/<Books>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _unitOfWork.Books.Get(id);
            if (book == null)
            {
                return BadRequest("Wrong ip book");
            }
            _unitOfWork.Books.Delete(book);
            _unitOfWork.Complete();
            return Ok(new { status= "delete ok"});
        }
    }
}
