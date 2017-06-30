using LibrarySytem.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySytem.Data.Models.Models
{
    public class Author : IAuthor
    {
        private ICollection<Book> books;

        public Author()
        {
            this.books = new HashSet<Book>();
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }
    }
}
