using LibraryManagementSystem.Application.Features.Book.Commands.AddBookCommand;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.DeleteBookCommand
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Response<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<Response<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var book = await unitOfWork.BookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                response.IsSuccess = false;
                response.Data = false;
                response.Message = "No existe el libro que quiere eliminar.";
                return response;
            }

            var isDelete = await unitOfWork.BookRepository.DeleteByIdAsync(request.Id);

            var loanedBook = await unitOfWork.LoanedBookRepository.GetAsync(x => x.BookId == request.Id);

            if(loanedBook != null)
            {
                foreach (var loaned in loanedBook)
                {
                    await unitOfWork.LoanedBookRepository.DeleteByIdAsync(loaned.Id);
                }
            }

            if (isDelete)
            {
                response.IsSuccess = true;
                response.Data = isDelete;
                response.Message = "El libro se elimino correctamente.";
            }
            else
            {
                response.IsSuccess = false;
                response.Data = isDelete;
                response.Message = "Ocurrio un error al querer eliminar el libro.";
            }

            return response;
        }
    }
}
