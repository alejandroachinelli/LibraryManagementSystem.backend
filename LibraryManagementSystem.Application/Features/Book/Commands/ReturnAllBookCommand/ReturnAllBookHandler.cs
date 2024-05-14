using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.ReturnAllBookCommand
{
    internal class ReturnAllBookHandler : IRequestHandler<ReturnAllBookCommand, Response<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReturnAllBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<Response<bool>> Handle(ReturnAllBookCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var loanedBooks = await unitOfWork.LoanedBookRepository.GetAllAsync();

            if (loanedBooks == null)
            {
                response.IsSuccess = false;
                response.Data = false;
                response.Message = "No se encontraron prestamos de libros solicitados.";
                return response;
            }

            foreach (var loaned in loanedBooks)
            {
                var book = await unitOfWork.BookRepository.GetByIdAsync(loaned.BookId);

                book.AvailableCopies = book.AvailableCopies + 1;

                var updateBook = await unitOfWork.BookRepository.UpdateAsync(book);

                await unitOfWork.LoanedBookRepository.DeleteByIdAsync(loaned.Id);
            }
            
            response.IsSuccess = true;
            response.Data = true;
            response.Message = "Se realizo la devolucion de todos los libros prestados.";

            return response;
        }
    }
}
