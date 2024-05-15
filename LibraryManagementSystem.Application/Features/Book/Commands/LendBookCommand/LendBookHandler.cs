using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand
{
    public class LendBookHandler : IRequestHandler<LendBookCommand, Response<LendBookResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LendBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<Response<LendBookResponse>> Handle(LendBookCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<LendBookResponse>();

            var book = await unitOfWork.BookRepository.GetByIdAsync(request.BookId);

            if(book == null || book.AvailableCopies <= 0)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "No se puede realizar el prestamo del libro.";
                return response;
            }

            book.AvailableCopies = book.AvailableCopies - 1;

            var updateBook = await unitOfWork.BookRepository.UpdateAsync(book);

            var lend = new LibraryManagementSystem.Domain.Entities.LoanedBook();

            lend.BookId = request.BookId;
            lend.Title = book.Title;
            lend.Authors = book.Authors;
            lend.Category = book.Category;
            lend.DateFrom = DateTime.Now;
            lend.DateTo = request.DateTo;
            lend.UserName = request.UserName;
            lend.UserLastName = request.UserLastName;

            var newLend = await unitOfWork.LoanedBookRepository.AddAsync(lend);

            var lendBook = mapper.Map<LendBookResponse>(newLend);

            if (newLend != null)
            {
                response.IsSuccess = true;
                response.Data = lendBook;
                response.Message = $"Se realizo el prestamo de {lendBook.Title} a {lendBook.UserName} {lendBook.UserLastName}.";
            }
            else
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "Ocurrio un problema al querer realizar el prestamo.";
            }

            return response;
        }
    }
}
