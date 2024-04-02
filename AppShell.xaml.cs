using Elephonkey.ViewViewModel;
namespace Elephonkey
{
    public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("article", typeof(ArticlesPageView));

		this.HomeTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.home.png", this.GetType().Assembly);
        this.BiasSurveyTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.categories.png", this.GetType().Assembly);
        this.ArticlesTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.bookmarks.png", this.GetType().Assembly);
        this.ResultsTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.results.png", this.GetType().Assembly);
        this.SettingsTab.Icon = ImageSource.FromResource("MAUIDemo.Resources.Images.settings.png", this.GetType().Assembly);
    }
}
