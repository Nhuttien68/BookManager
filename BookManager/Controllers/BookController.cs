using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookManager.Models;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();

        // GET: Book
        public ActionResult Index()
        {
            return View(books);
        }

        // POST: Book/AddNewBook
        [HttpPost]
        public ActionResult AddNewBook(string bookName)
        {
            if (!string.IsNullOrEmpty(bookName))
            {
                var newBook = new Book
                {
                    bookID = books.Count + 1,
                    title = bookName,
                };
                books.Add(newBook);
                TempData["Success"] = "Thêm sách thành công!";
            }
            else
            {
                TempData["Error"] = "Tên sách không được để trống.";
            }

            return RedirectToAction("Index");
        }
    }
}
