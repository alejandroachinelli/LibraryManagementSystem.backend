﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand
{
    public class LendBookResponse
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Category { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
    }
}
