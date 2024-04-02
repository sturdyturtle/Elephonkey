using Elephonkey.Models;
using Elephonkey.Services;

namespace Elephonkey.ViewViewModels.AppContents
{
    public class ArticleViewModel
    {
        public ArticleViewModel(INewsService news, Article a)
        {
            this.Title = a.Title;
            this.ImageURL = a.ImageURL;
            this.Body = news.GetArticleBody(a.Id);
            this.Time = a.Time;
        }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public string Body { get; set; }

        public string Time { get; set; }
    }
}
