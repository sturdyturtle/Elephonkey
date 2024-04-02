using Elephonkey.Services;

namespace Elephonkey.ViewViewModels.AppContents;

public partial class HomePageView : ContentPage
{
    public HomePageView(INewsService news)
    {
        InitializeComponent();
        this.BindingContext = new HomePageViewModel(news);
    }
}