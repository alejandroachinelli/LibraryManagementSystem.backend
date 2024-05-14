using LibraryManagementSystem.Application.Features.Book.Commands.AddBookCommand;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.DeleteBookCommand
{
    public sealed record class DeleteBookCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }

        public DeleteBookCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
