using LibrarySytem.Data.Models.Contracts;
using System;

namespace LibrarySytem.Data.Models.Models
{
    public class Image : IImage
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public virtual Book Book { get; set; }

        public Guid? BookId { get; set; }

        public byte[] ImageData { get; set; }
    }
}
