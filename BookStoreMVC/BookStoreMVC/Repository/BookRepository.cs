﻿using BookStoreMVC.Data;
using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Repository
{
    public class BookRepository : IBookRepository
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
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl


            };
            //var gallery = new List<BookGallery>();
            newBook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }


            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;


        }


        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();

            if (allBooks?.Any() == true)
            {
                foreach (var item in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = item.Author,
                        Category = item.Category,
                        Description = item.Description,
                        Id = item.Id,
                        LanguageId = item.LanguageId,
                        Title = item.Title,
                        TotalPages = item.TotalPages,
                        CoverImageUrl = item.CoverImageUrl


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
                       TotalPages = book.TotalPages,
                       CoverImageUrl = book.CoverImageUrl,
                       Gallery = book.bookGallery.Select(b => new GalleryModel()
                       {
                           Id = b.Id,
                           Name = b.Name,
                           URL = b.URL
                       }).ToList(),
                       BookPdfUrl = book.BookPdfUrl

                   }).FirstOrDefaultAsync();


        }






        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }



        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.Take(count).ToListAsync();

            if (allBooks?.Any() == true)
            {
                foreach (var item in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = item.Author,
                        Category = item.Category,
                        Description = item.Description,
                        Id = item.Id,
                        LanguageId = item.LanguageId,
                        Title = item.Title,
                        TotalPages = item.TotalPages,
                        CoverImageUrl = item.CoverImageUrl

                    });
                }
            }

            return books;
        }

    }
}
