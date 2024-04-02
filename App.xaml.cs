
using Elephonkey.ViewViewModels.AppContents;

namespace Elephonkey
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
