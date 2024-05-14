using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class LoanedBookRepository : GenericRepository<LoanedBook>, ILoanedBookRepository
    {
        public LoanedBookRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
