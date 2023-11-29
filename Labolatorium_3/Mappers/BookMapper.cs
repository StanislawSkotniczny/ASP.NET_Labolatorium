using Data.Entities;
using Laboratorium_3.Models;

namespace Laboratorium_3.Mappers
{
    public class BookMapper
    {
        public static Book FromEntity(BookEntity entity) 
        {
            return new Book()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN,
                PageNumber = entity.PageNumber,
                PublicationYear = entity.PublicationYear,
                Publisher = entity.Publisher
            };
        }

        public static BookEntity ToEntity(Book model) 
        {
            return new BookEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                ISBN = model.ISBN,
                PageNumber = model.PageNumber,
                PublicationYear = model.PublicationYear,
                Publisher = model.Publisher
            };
        }


    }
}
