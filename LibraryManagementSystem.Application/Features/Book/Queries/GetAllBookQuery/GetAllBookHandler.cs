using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery
{
    public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, Response<IEnumerable<GetAllBookResponse>>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetAllBookHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<IEnumerable<GetAllBookResponse>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetAllBookResponse>>();
            var books = await unitOfWork.BookRepository.GetAllAsync();
            if (books == null)
            {
                response.IsSuccess = false;
                response.Message = "No existen libros almacenados.";
                return response;
            }

            response.Data = mapper.Map<IEnumerable<GetAllBookResponse>>(books);
            response.IsSuccess = true;

            return response;
        }
    }
}
