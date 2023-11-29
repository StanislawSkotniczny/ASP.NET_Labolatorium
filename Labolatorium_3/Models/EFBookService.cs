using Data;
using Data.Entities;
using Laboratorium_3.Mappers;

namespace Laboratorium_3.Models
{
    public class EFBookService : IBookService
    {
        private AppDbContext _context;

        public EFBookService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Book book)
        {
            var e = _context.Books.Add(BookMapper.ToEntity(book));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void DeleteById(int id)
        {
            BookEntity? find = _context.Books.Find(id);
            if(find != null)
            {
                _context.Books.Remove(find);
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.Select(e => BookMapper.FromEntity(e)).ToList();
        }

        public List<RentalEntity> FindAllRentalsForVieModel()
        {
            return _context.Rentals.ToList();
        }

        public Book? FindById(int id)
        {
            return BookMapper.FromEntity(_context.Books.Find(id));
        }

        public void Update(Book book)
        {
            _context.Books.Update(BookMapper.ToEntity(book));
        }
    }
}
