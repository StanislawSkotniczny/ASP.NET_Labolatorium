using Data.Entities;
using Laboratorium_3.Models;
using System.Reflection;


namespace Laboratorium_3.Models
{
    public class MemoryBookService: IBookService
    {
        //private Dictionary<int, Book> _books = new Dictionary<int, Book>()
        //{
        //    {1, new Book() {  } }
        //};
        //private int id = 2;

        private Dictionary<int, Book> _books = new Dictionary<int, Book>()
        {
            {1, new Book() { Id = 1, Title = "C# Programming", Author = "John Smith", PageNumber = "300", ISBN = "9780123456789", PublicationYear = "2022", Publisher = "Tech Books", RentalId = 1 } },
            {2, new Book() { Id = 2, Title = "Introduction to ASP.NET Core", Author = "Emily Johnson", PageNumber = "250", ISBN = "9789876543210", PublicationYear = "2021", Publisher = "Coding Press", RentalId = 2 } }
        };
        private int id = 3;

        private readonly IDateTimeProvider _timeProvider;

        public MemoryBookService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }


        public int Add(Book model)
        {
           // model.Created = _timeProvider.GetDateTime();
            model.Id = id++;
            _books[model.Id] = model;
            return model.Id;
        }

        public void DeleteById(int id)
        {
            _books.Remove(id);
        }

        public List<Book> FindAll()
        {
            return _books.Values.ToList();
        }

        public Book FindById(int id)
        {
            return _books[id];
        }

        public void Update(Book book)
        {
            if (_books.ContainsKey(book.Id))
            {
                _books[book.Id] = book;
            }
        }

        public List<RentalEntity> FindAllRentalsForVieModel()
        {
            return _books.Values
        .Select(book => new RentalEntity
        {
            Id = book.RentalId ?? 0, // Assuming there is a mapping between Book RentalId and RentalEntity Id
                                     // Map other properties accordingly
        })
        .ToList();
        
        }

        public PagingList<Book> FindPage(int page, int size)
        {
            return PagingList<Book>.Create(
            (p, s) => _books.OrderBy(c => c.Value.Title)
                .Skip((p - 1) * s)
                .Take(s)
                .Select(c => c.Value)
            .ToList(),
                page,
                size,
                _books.Count()
            );
        }
    }
}
