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
                TotalPages=model.TotalPages,
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
                        Language=item.Language,
                        Title=item.Title,
                        TotalPages=item.TotalPages

                    });

                }
            }

            return books;
        }


        public async Task<BookModel>  GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book!=null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }

            return null;
            //return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }


        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="Raihan", Description="This is a description section sectionLorem ipsum dolor sit amet consectetur" +
                " adipisicing elit. Ducimus dolores molestiae laborum quaerat exercitationem nesciunt odio ipsum consequuntur. Architecto doloremque natus " +
                "aspernatur" +  " enim rem expedita at mollitia, iure nostrum laborumenim rem expedita at mollitia, iure nostrum laborum", Category="Programming",
                Language="English", TotalPages=765},


                new BookModel(){Id=2, Title="Web APi", Author="Zakaria", Description="This is a description section sectionLorem ipsum dolor sit amet consectetur" +
                " adipisicing elit. Ducimus dolores molestiae laborum quaerat exercitationem nesciunt odio ipsum consequuntur. Architecto doloremque natus " +
                "aspernatur" +  " enim rem expedita at mollitia, iure nostrum laborumenim rem expedita at mollitia, iure nostrum laborum",Category="Programming",
                Language="English", TotalPages=865},

                new BookModel(){Id=3, Title="C#", Author="Tanjeeb", Description="This is a description sectionThis is a description section sectionLorem ipsum " +
                "dolor sit amet consectetur" +
                " adipisicing elit. Ducimus dolores molestiae laborum quaerat exercitationem nesciunt odio ipsum consequuntur. Architecto doloremque natus " +
                "aspernatur" +  " enim rem expedita at mollitia, iure nostrum laborumenim rem expedita at mollitia, iure nostrum laborum",Category="Programming",
                Language="English", TotalPages=595},

                new BookModel(){Id=4, Title="PHP", Author="Mridul",Description="This is a description sectionThis is a description section sectionLorem ipsum dolor" +
                " sit amet consectetur" +
                " adipisicing elit. Ducimus dolores molestiae laborum quaerat exercitationem nesciunt odio ipsum consequuntur. Architecto doloremque natus " +
                "aspernatur" +  " enim rem expedita at mollitia, iure nostrum laborumenim rem expedita at mollitia, iure nostrum laborum",Category="Programming",
                Language="English", TotalPages=788},

                new BookModel(){Id=5, Title="Python", Author="Tanvir", Description="This is a description sectionThis is a description section sectionLorem ipsum" +
                " dolor sit amet consectetur" +
                " adipisicing elit. Ducimus dolores molestiae laborum quaerat exercitationem nesciunt odio ipsum consequuntur. Architecto doloremque natus " +
                "aspernatur" +  " enim rem expedita at mollitia, iure nostrum laborumenim rem expedita at mollitia, iure nostrum laborum",Category="Programming",
                Language="English", TotalPages=965},

                new BookModel(){Id=9, Title="Data Structure", Author="Tanjeeb", Description="This is a description sectionThis is a description section sectionLorem " +
                "ipsum dolor sit amet consectetur" +
                " adipisicing elit. Ducimus dolores molestiae laborum quaerat exercitationem nesciunt odio ipsum consequuntur. Architecto doloremque natus " +
                "aspernatur" +  " enim rem expedita at mollitia, iure nostrum laborumenim rem expedita at mollitia, iure nostrum laborum",Category="Programming",
                Language="English", TotalPages=465},


            };
        }
    }
}
