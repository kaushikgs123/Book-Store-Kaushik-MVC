using BookStoreMVC.Data;
using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author=model.Author,
                CreatedOn=DateTime.UtcNow,
                Description=model.Description,
                Title=model.Title,
                LanguageId=model.LanguageId,             
                TotalPages=model.TotalPages.HasValue?model.TotalPages.Value:0,
                UpdatedOn=DateTime.UtcNow
            };

           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();
            return newBook.Id;

          
        }


        public async Task<List<BookModel>>  GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();

            if (allBooks?.Any()==true)
            {
                foreach (var item in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author=item.Author,
                        Category=item.Category,
                        Description=item.Description,
                        Id=item.Id,
                        LanguageId=item.LanguageId,                       
                        Title=item.Title,
                        TotalPages=item.TotalPages

                    });

                }
            }

            return books;
        }


        public async Task<BookModel> GetBookById(int id)
        {
         return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();

        
        }

    
            
    


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }


       
    }
}
