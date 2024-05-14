using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookRepository BookRepository { get; }
        public ILoanedBookRepository LoanedBookRepository { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
