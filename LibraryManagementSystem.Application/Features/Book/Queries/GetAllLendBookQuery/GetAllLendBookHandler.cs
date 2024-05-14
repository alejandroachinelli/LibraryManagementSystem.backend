using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllLendBookQuery
{
    public class GetAllLendBookHandler : IRequestHandler<GetAllLendBookQuery, Response<IEnumerable<GetAllLendBookResponse>>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetAllLendBookHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<IEnumerable<GetAllLendBookResponse>>> Handle(GetAllLendBookQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GetAllLendBookResponse>>();
            var loanedBooks = await unitOfWork.LoanedBookRepository.GetAllAsync();
            if (loanedBooks == null)
            {
                response.IsSuccess = false;
                response.Message = "No existen prestamos de libros almacenados.";
                return response;
            }

            response.Data = mapper.Map<IEnumerable<GetAllLendBookResponse>>(loanedBooks);
            response.IsSuccess = true;

            return response;
        }
    }
}
