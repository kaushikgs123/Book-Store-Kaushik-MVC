using BookStoreMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreMVC.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}