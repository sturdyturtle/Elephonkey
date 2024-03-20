
using Elephonkey.ViewViewModels.Main.AppContents;

namespace Elephonkey
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePageView());
        }
    }
}