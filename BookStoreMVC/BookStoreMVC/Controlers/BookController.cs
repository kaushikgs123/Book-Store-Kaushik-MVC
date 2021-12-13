using BookStoreMVC.Models;
using BookStoreMVC.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Controlers
{

 [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment=null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("~/all-books")]
       public async Task<ViewResult> GetAllBooks()
        {
           var data=await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("~/book-detail/{id}")]
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
                #region Single Image

                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover";
                    bookModel.CoverImageUrl = await UploadImage(folder, bookModel.CoverPhoto);
                }

                #endregion


                #region Multiple Images

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery";
                    bookModel.Gallery = new List<GalleryModel>();


                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);

                    }

                }

                #endregion


                #region Pdf Fie

                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }

                #endregion

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

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
           folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

           string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

           await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
           return "/" + folderPath;


        }
    }
}
