using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery;
using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllLendBookQuery
{
    public class GetAllLendBookQuery : IRequest<Response<IEnumerable<GetAllLendBookResponse>>>
    {
    }
}
