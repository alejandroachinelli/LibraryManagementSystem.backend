using LibraryManagementSystem.Application.Features.Book.Commands.AddBookCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand
{
    internal class LendBookMapper : Profile
    {
        public LendBookMapper()
        {
            CreateMap<LendBookCommand, LibraryManagementSystem.Domain.Entities.LoanedBook>();
            CreateMap<LibraryManagementSystem.Domain.Entities.LoanedBook, LendBookResponse>();
        }
    }
}
