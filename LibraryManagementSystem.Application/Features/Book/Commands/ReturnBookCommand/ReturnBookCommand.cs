using LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.ReturnBookCommand
{
    public sealed record class ReturnBookCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
