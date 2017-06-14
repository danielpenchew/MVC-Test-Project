using Bytes2you.Validation;
using LibrarySystem.Data.Contracts;
using LibrarySystem.Data.Services.Contracts;
using LibrarySytem.Data.Models.Models;
using System;
using System.Linq;

namespace LibrarySystem.Data.Services
{
    public class ImageServices : IImageServices
    {
        private readonly ILibrarySystemEfWrapper<Image> imageWrapper;

        public ImageServices(ILibrarySystemEfWrapper<Image> imageWrapper)
        {
            Guard.WhenArgument(imageWrapper, "imageWrapper").IsNull().Throw();

            this.imageWrapper = imageWrapper;
        }

        public Image GetById(Guid id)
        {
            var image = this.imageWrapper.GetById(id);

            return image;
        }

        public IQueryable<Image> GetImagesByBookId(Guid bookId)
        {
            var images = this.imageWrapper.All()
                                          .Where(i => i.Id == bookId);

            return images;
        }
    }
}
