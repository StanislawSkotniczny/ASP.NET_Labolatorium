using Laboratorium_3.Controllers;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labolatorium9_test
{
    public class BookControllerTest
    {
        private BookController _controller;
        private IBookService _service;

        public BookControllerTest()
        {
            _service = new MemoryBookService(new CurrentDateTimeProvider());
            _service.Add(new Book() { Title = "Test1" }); // id 1
            _service.Add(new Book() { Title = "Test2" }); // id 2 

            _controller = new BookController(new CurrentDateTimeProvider(), _service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);

            var view = result as ViewResult;
            Assert.IsType<List<Book>>(view?.Model);
            List<Book>? list = view.Model as List<Book>;
            Assert.NotNull(list);
            Assert.Equal(2, list.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingBooks(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);

            var view = result as ViewResult;
            Assert.IsType<Book>(view?.Model);
            Book? model = view.Model as Book;
            Assert.NotNull(model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTestForNonExistingBook()
        {
            var result = _controller.Details(3);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateTest()
        {
            Book model = new Book { Title = "test", Author = "Author1", ISBN = "1234567890123" };
            var prevCount = _service.FindAll().Count;
            var result = _controller.Create(model);
            Assert.Equal(prevCount + 1, _service.FindAll().Count);
        }

        [Fact]
        public void UpdateTest()
        {
            Book model = new Book { Id = 1, Title = "UpdatedTitle", Author = "Author2", ISBN = "9876543210987" };
            var result = _controller.Update(model);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void DeleteTest()
        {
            var model = _service.FindById(1);
            var result = _controller.Delete(model);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void CreateApiTest()
        {
            Book model = new Book { Title = "ApiTest", Author = "ApiAuthor", ISBN = "1111222233334" };
            var prevCount = _service.FindAll().Count;
            var result = _controller.CreateApi(model);
            Assert.Equal(prevCount + 1, _service.FindAll().Count);
        }
    }
}
