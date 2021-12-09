using BookStoreMVC.Models;
using BookStoreMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Controlers
{
    
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
       public async Task<ViewResult> GetAllBooks()
        {
           var data=await _bookRepository.GetAllBooks();
            return View(data);
        }

        //[Route("book-detail/{id}")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data= await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess=false, int bookId=0)
        {

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");


            //ViewBag.ListOflanguage = new List<string>() { "Bangla", "English", "Arabic" }; // New list at CSHTML File
            // ViewBag.ListOflanguage = new SelectList( new List<string>() { "Bangla", "English", "Arabic" });
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
      
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList( await _languageRepository.GetLanguages(),"Id","Name");
            // ViewBag.ListOflanguage = new List<string>() { "Bangla", "English", "Arabic" };
            //ViewBag.ListOflanguage = new SelectList(new List<string>() { "Bangla", "English", "Arabic" });
            return View();
        }
    }
}
