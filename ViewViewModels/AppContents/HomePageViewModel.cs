﻿using System;
using Elephonkey.Models;
using Elephonkey.Services;

namespace Elephonkey.ViewViewModels.AppContents
{
    public class HomePageViewModel
    {
        public HomePageViewModel(INewsService news)
        {
            Tags = news.GetTags();

            LatestArticles = news.GetLatestArticles();

            RecommendedArticles = news.GetRecommendedArticles();

            PopularArticles = news.GetPopularArticles();

            TappedCommand = new Command<Article>((article) =>
            {
                var query = new Dictionary<string, object>()
                {
                    { "article", article }
                };
                Shell.Current.GoToAsync("//home/article", query);
            });
        }

        public ICollection<string> Tags { get; set; }

        public ICollection<Article> LatestArticles { get; set; }

        public ICollection<Article> PopularArticles { get; set; }

        public ICollection<Article> RecommendedArticles { get; set; }

        public Command<Article> TappedCommand { get; set; }
    }
}