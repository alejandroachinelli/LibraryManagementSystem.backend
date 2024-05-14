using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery
{
    public class GetAllBookMapper : Profile
    {
        public GetAllBookMapper()
        {
            CreateMap<LibraryManagementSystem.Domain.Entities.Book, GetAllBookResponse>()
                .ReverseMap();
        }
    }
}
