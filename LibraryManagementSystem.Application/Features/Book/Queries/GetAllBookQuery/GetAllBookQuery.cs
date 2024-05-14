using LibraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery
{
    public class GetAllBookQuery : IRequest<Response<IEnumerable<GetAllBookResponse>>>
    {
    }
}
