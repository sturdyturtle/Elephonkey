namespace Elephonkey.ViewViewModels.Main;

public partial class LoginPageView : ContentPage
{
	public LoginPageView()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
	}
}