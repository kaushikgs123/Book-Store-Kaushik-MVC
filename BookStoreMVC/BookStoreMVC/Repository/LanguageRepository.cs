using BookStoreMVC.Data;
using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Repository
{
    public class LanguageRepository
    {

        private readonly BookStoreContext _context=null;
        public LanguageRepository(BookStoreContext 
            context)
        {
            _context = context;
        }


        public async Task<List<LanguageModel>> GetLanguages()
        {
            var languages = await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();

            return languages;
        }
    };
}
