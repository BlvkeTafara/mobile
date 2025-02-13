using Microsoft.Maui.Controls; 
using TransactionTrackerUI.ViewModel;

namespace TransactionTrackerUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginViewModel(this.Navigation);
	}
}