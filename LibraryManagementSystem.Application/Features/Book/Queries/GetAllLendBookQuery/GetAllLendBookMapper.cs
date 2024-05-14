using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllLendBookQuery
{
    public class GetAllLendBookMapper : Profile
    {
        public GetAllLendBookMapper()
        {
            CreateMap<LibraryManagementSystem.Domain.Entities.LoanedBook, GetAllLendBookResponse>()
                .ReverseMap();
        }
    }
}
