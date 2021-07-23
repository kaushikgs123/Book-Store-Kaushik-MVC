﻿using BookStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }


        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }


        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="Raihan", Description="This is a description section"},
                new BookModel(){Id=2, Title="Web APi", Author="Zakaria", Description="This is a description section"},
                new BookModel(){Id=3, Title="C#", Author="Tanjeeb", Description="This is a description section"},
                new BookModel(){Id=4, Title="PHP", Author="Mridul",Description="This is a description section"},
                new BookModel(){Id=5, Title="Python", Author="Tanvir", Description="This is a description section"},
                new BookModel(){Id=6, Title="Data Structure", Author="Tanjeeb", Description="This is a description section"},

            };
        }
    }
}
