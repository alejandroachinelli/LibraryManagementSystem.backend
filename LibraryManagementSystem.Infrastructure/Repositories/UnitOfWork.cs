using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookRepository BookRepository { get; }

        public ILoanedBookRepository LoanedBookRepository { get; }

        private readonly LibraryDbContext libraryDbContext;

        public UnitOfWork(IBookRepository bookRepository,
            ILoanedBookRepository loanedBookRepository,
            LibraryDbContext libraryDbContext)
        {
            BookRepository = bookRepository;
            LoanedBookRepository = loanedBookRepository;
            this.libraryDbContext = libraryDbContext;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
