using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand
{
    public sealed record class LendBookCommand : IRequest<Response<LendBookResponse>>
    {
        public Guid BookId { get; set; }
    }
}
