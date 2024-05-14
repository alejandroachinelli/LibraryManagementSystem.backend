using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.AddBookCommand
{
    public class AddBookMapper : Profile
    {
        public AddBookMapper()
        {
            CreateMap<AddBookCommand, LibraryManagementSystem.Domain.Entities.Book>();
            CreateMap<LibraryManagementSystem.Domain.Entities.Book, AddBookResponse>();
        }
    }
}
