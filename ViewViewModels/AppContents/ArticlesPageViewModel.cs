using System;
using Elephonkey.Models;
using Elephonkey.Services;
using Elephonkey.ViewViewModels;


namespace Elephonkey.ViewViewModels.AppContents
{
    public class ArticlesPageViewModel
    {
        public ArticlesPageViewModel(INewsService news)
        {
            this.Sections = news.GetCategories();
        }

        public ICollection<Category> Sections { get; set; }
    }
}
