using Laboratorium_3.Models;
using System.Reflection;


namespace Labolatorium_3.Models
{
    public class MemoryBookService: IBookService
    {
        private Dictionary<int, Book> _books = new Dictionary<int, Book>()
        {
            {1, new Book() {  } }
        };
        private int id = 2;

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
    }
}
