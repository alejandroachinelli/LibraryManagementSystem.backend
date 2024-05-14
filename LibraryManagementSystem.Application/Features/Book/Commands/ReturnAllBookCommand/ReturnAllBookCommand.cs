using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.ReturnAllBookCommand
{
    public sealed record class ReturnAllBookCommand : IRequest<Response<bool>>
    {
    }
}
