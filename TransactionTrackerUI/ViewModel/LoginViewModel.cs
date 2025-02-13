using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TransactionTrackerUI.Models;

namespace TransactionTrackerUI.ViewModel
{
    public class LoginViewModel
    {
        private string _userName, _password;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public ICommand RegisterCommand { private set; get; }
        public ICommand LoginCommand { private set; get; }
        private INavigation Navigation;
        public LoginViewModel(INavigation navigation) 
        {
            RegisterCommand = new Command(OnRegisterCommand);
            LoginCommand = new Command(OnLoginCommand);
            Navigation = navigation;

        }

        private async void OnLoginCommand(object obj)
        {
            var loginData = await App.Database.GetLoginDataAsync(UserName);
            if (loginData == null)
            {
                if (string.Equals(loginData.Password, Password))
                {

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("failure", "Invalid Password", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("failure", "Invalid UserName", "Ok");
            }
            }
        
        private async void OnRegisterCommand(object obj)
        {
            LoginModel lm = new LoginModel();
            lm.UserName = UserName;
            lm.Password = Password;
            App.Database.SaveLoginDataAsnyc(lm);
            App.Current.MainPage.DisplayAlert("Success", "Registration Successful", "Ok");
        }
    }
}
