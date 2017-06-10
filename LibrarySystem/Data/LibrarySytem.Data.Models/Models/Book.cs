using LibrarySytem.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySytem.Data.Models.Models
{
    public class Book : IBook
    {
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }

        [MinLength(2)]
        [MaxLength(400)]
        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
