using LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.ReturnBookCommand
{
    public class ReturnBookHandler : IRequestHandler<ReturnBookCommand, Response<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReturnBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<Response<bool>> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var loanedBook = await unitOfWork.LoanedBookRepository.GetByIdAsync(request.Id);

            if (loanedBook == null)
            {
                response.IsSuccess = false;
                response.Data = false;
                response.Message = "No se encontro un prestamo del libro solicitado.";
                return response;
            }

            var book = await unitOfWork.BookRepository.GetByIdAsync(loanedBook.BookId);

            book.AvailableCopies = book.AvailableCopies + 1;

            var updateBook = await unitOfWork.BookRepository.UpdateAsync(book);

            var deleteBook = await unitOfWork.LoanedBookRepository.DeleteByIdAsync(loanedBook.Id);

            if (deleteBook)
            {
                response.IsSuccess = true;
                response.Data = deleteBook;
                response.Message = $"Se realizo la devolucion de {loanedBook.Title} prestado a {loanedBook.UserName} {loanedBook.UserLastName}.";
            }
            else
            {
                response.IsSuccess = false;
                response.Data = deleteBook;
                response.Message = "Ocurrio un problema al querer realizar la devolucion del libro.";
            }

            return response;
        }
    }
}
