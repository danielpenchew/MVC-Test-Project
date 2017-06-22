﻿using System;

namespace LibrarySystem.Web.Models.Book
{
    public class BookImageViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageData { get; set; }
    }
}