using Elephonkey.ViewViewModels.AppContents;

namespace Elephonkey;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("article", typeof(ArticleView));

        this.HomeTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.home.png", this.GetType().Assembly);
        this.SurveyTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.categories.png", this.GetType().Assembly);
        this.ArticlesTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.bookmarks.png", this.GetType().Assembly);
        this.ResultsTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.results.png", this.GetType().Assembly);
        this.SettingsTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.settings.png", this.GetType().Assembly);
    }
}

