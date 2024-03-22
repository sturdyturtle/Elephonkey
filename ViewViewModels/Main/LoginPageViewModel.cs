using Elephonkey.Models.DataAccess;
using Elephonkey.Models.Entities;
using Elephonkey.ViewViewModels.Base;
using Elephonkey.ViewViewModels.Main.LoginContents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.ViewViewModels.Main
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly DataAccessSQLiteImplementation _sqliteService = new DataAccessSQLiteImplementation();

        public Command CreateAccountCommand
        {
            get
            {
                return new Command<EntityLogin>((EntityLogin Login) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<EntityLogin>(this, "CreateLogin");

                    //Navigate to the LoginAddView, passing a Login if available
                    Application.Current.MainPage.Navigation.PushAsync(new CreateAccountPageView(Login));
                });
            }
        }

        //Command to navigate to the LoginMgmtView and handle Updates
        public Command ForgotPasswordCommand
        {
            get
            {
                return new Command<EntityLogin>((EntityLogin Login) =>
                {
                    //Unsubscribe from events - precautionary step to ensure that there are no existing subscriptions for the specified events
                    MessagingCenter.Unsubscribe<EntityLogin>(this, "ForgotPassword");

                    //Navigate to the LoginAddView, passing a Login if available
                    Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPageView(Login));

                });
            }
        
    }
}
