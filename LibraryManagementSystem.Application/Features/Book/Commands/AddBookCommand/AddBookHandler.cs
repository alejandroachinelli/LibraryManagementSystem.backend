using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.AddBookCommand
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, Response<AddBookResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<Response<AddBookResponse>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<AddBookResponse>();

            var existBook = await unitOfWork.BookRepository.GetFirstOrDefaultAsync(x => x.Title == request.Title && x.Authors == request.Authors);

            if (existBook != null)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = "El libro ya se encuentra registrado.";
                return response;
            }

            var newBook = mapper.Map<LibraryManagementSystem.Domain.Entities.Book>(request);

            newBook.CreatedAt = DateTime.UtcNow;
            newBook.LastModifiedAt = DateTime.UtcNow;

            var book = await unitOfWork.BookRepository.AddAsync(newBook);

            response.IsSuccess = true;
            response.Data = mapper.Map<AddBookResponse>(book);
            response.Message = "Libro agregado exitosamente.";

            return response;
        }
    }
}
