using Elephonkey.ViewViewModels.Base;
using Elephonkey.Models.Titles;
using System.Windows.Input;
using Elephonkey.ViewViewModels.Main.LoginContents;
using Elephonkey.ViewViewModels.Main.AppContents;
using Elephonkey.Models.Entities;

namespace Elephonkey.ViewViewModels.Main
{
    public class LoginPageViewModel : BaseViewModel
    {
        public class MainViewModel : BaseViewModel
        {
            //Button + Field Texts
            public String EmailFieldText { get; set; } = TitleLoginPage.MyEmailFieldText;
            public String PasswordFieldText { get; set; } = TitleLoginPage.MyPasswordFieldText;
            public String ForgotPasswordButtonText { get; set; } = TitleLoginPage.MyForgotPasswordButtonText;
            public String CreateAccountButtonText { get; set; } = TitleLoginPage.MyCreateAccountButtonText;
            public String LoginButtonText { get; set; } = TitleLoginPage.MyLoginButtonText;

            //
            public string Email { get; set; }
            public string Password { get; set; }

            //Button Commands
            public ICommand OnForgotPasswordButtonClicked { get; set; }
            public ICommand OnCreateAccountButtonClicked { get; set; }
            public Command<EntityLogin> PerformLogin
            {
                get
                {
                    return new Command<EntityLogin>(async (EntityLogin Login) =>
                    {
                        try
                        {
                            //Check for required data before save or update
                            if (string.IsNullOrEmpty(Parlor) || string.IsNullOrEmpty(Flavor))
                            {
                                await Application.Current.MainPage.DisplayAlert("Email and Password are required.", "Ok");
                                return;
                            }

                            
                            {
                                //Creating a new Milkshakes instance with ViewModel properties for an update
                                Milkshakes = new EntityMilkshakes
                                {
                                    Id = Id,
                                    Parlor = Parlor,
                                    Flavor = Flavor,
                                    WouldRecommend = WouldRecommend
                                };

                                //Update the existing Milkshakes details
                                bool result = await _sqliteService.UpdateMilkshakes(Milkshakes);

                                if (result)
                                {
                                    //Send a message to notify about the update of the Milkshakes
                                    MessagingCenter.Send<EntityMilkshakes>(Milkshakes, "UpdateMilkshakes");
                                    await Application.Current.MainPage.Navigation.PopAsync();
                                }
                                else
                                {
                                    await Application.Current.MainPage.DisplayAlert("Message", "Data Failed To Update", "Ok");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                        }
                    });
                }
            }

            //Constructor
            public MainViewModel()
            {
                //Set Command
                OnForgotPasswordButtonClicked = new Command(OnForgotPasswordButtonClickedAsync);
                OnCreateAccountButtonClicked = new Command(OnCreateAccountButtonClickedAsync);
            }

            //Button Navigation To New Pages
            private async void OnForgotPasswordButtonClickedAsync()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPageView());
            }

            private async void OnCreateAccountButtonClickedAsync()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CreateAccountPageView());
            }
            private async void OnLoginButtonClickedAsync()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new HomePageView());
            }
        }
    }
}
