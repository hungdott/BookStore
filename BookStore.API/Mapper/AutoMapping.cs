using AutoMapper;
using BookStore.API.ModelDTO;
using BookStore.Domain.BooksAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BookDto,Book>();
        }
    }
}
