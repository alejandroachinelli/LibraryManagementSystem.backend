using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<LoanedBook> LoanedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedInitialData(modelBuilder);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Title = "Harry Potter y la Piedra Filosofal",
                    Authors = "J.K. Rowling",
                    Publisher = "Bloomsbury Publishing",
                    PublicationYear = 1997,
                    PageCount = 223,
                    Category = "Fantasía",
                    AvailableCopies = 10,
                    TotalCopies = 10
                },
                new Book
                {
                    Title = "Dune",
                    Authors = "Frank Herbert",
                    Publisher = "Ace Books",
                    PublicationYear = 1965,
                    PageCount = 412,
                    Category = "Ciencia Ficción",
                    AvailableCopies = 10,
                    TotalCopies = 10
                },
                new Book
                {
                    Title = "Orgullo y Prejuicio",
                    Authors = "Jane Austen",
                    Publisher = "Thomas Egerton",
                    PublicationYear = 1813,
                    PageCount = 279,
                    Category = "Romance",
                    AvailableCopies = 8,
                    TotalCopies = 8
                },
                new Book
                {
                    Title = "1984",
                    Authors = "George Orwell",
                    Publisher = "Secker & Warburg",
                    PublicationYear = 1949,
                    PageCount = 328,
                    Category = "Distopía",
                    AvailableCopies = 8,
                    TotalCopies = 8
                },
                new Book
                {
                    Title = "Cien años de soledad",
                    Authors = "Gabriel García Márquez",
                    Publisher = "Editorial Sudamericana",
                    PublicationYear = 1967,
                    PageCount = 417,
                    Category = "Realismo Mágico",
                    AvailableCopies = 6,
                    TotalCopies = 6
                },
                new Book
                {
                    Title = "Crónica de una muerte anunciada",
                    Authors = "Gabriel García Márquez",
                    Publisher = "Editorial La Oveja Negra",
                    PublicationYear = 1981,
                    PageCount = 120,
                    Category = "Ficción",
                    AvailableCopies = 10,
                    TotalCopies = 10
                },
                new Book
                {
                    Title = "El Principito",
                    Authors = "Antoine de Saint-Exupéry",
                    Publisher = "Reynal & Hitchcock",
                    PublicationYear = 1943,
                    PageCount = 93,
                    Category = "Infantil",
                    AvailableCopies = 9,
                    TotalCopies = 9
                },
                new Book
                {
                    Title = "El Alquimista",
                    Authors = "Paulo Coelho",
                    Publisher = "HarperCollins",
                    PublicationYear = 1988,
                    PageCount = 163,
                    Category = "Ficción Espiritual",
                    AvailableCopies = 11,
                    TotalCopies = 11
                },
                new Book
                {
                    Title = "El Hobbit",
                    Authors = "J.R.R. Tolkien",
                    Publisher = "George Allen & Unwin",
                    PublicationYear = 1937,
                    PageCount = 310,
                    Category = "Fantasía",
                    AvailableCopies = 7,
                    TotalCopies = 7
                },
                new Book
                {
                    Title = "El Extranjero",
                    Authors = "Albert Camus",
                    Publisher = "Gallimard",
                    PublicationYear = 1942,
                    PageCount = 123,
                    Category = "Filosofía",
                    AvailableCopies = 8,
                    TotalCopies = 8
                }
            );
        }
    }
}
