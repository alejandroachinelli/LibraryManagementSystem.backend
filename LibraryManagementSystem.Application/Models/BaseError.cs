﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Models
{
    public class BaseError
    {
        public string? PropertyMessage { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
