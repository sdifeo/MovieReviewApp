using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieReviewApp.Models;

namespace MovieReviewApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();

            Navigation.PushAsync(new SignIn());
        }

        private void signUp_Clicked(object sender, EventArgs e)
        {
            Validation validation = new Validation();
            string email = input_email.Text;
            string password = input_password.Text;

            if (input_email.Text.Length == 0)
            {
                input_email.Focus();
                DisplayAlert("Email", "Email must not be empty", "OK");
                return;
            }

            if (input_password.Text.Length == 0)
            {
                input_email.Focus();
                DisplayAlert("Password", "Password must not be empty", "OK");
                return;
            }

            if (password.Length < 5)
            {
                input_password.Focus();
                DisplayAlert("Password", "Password must be greater than 5 characters", "OK");
                return;
            }

            if (validation.email_verification(email) == true)
            {
                User user = new User(email, password);

                DisplayAlert("Success", "You may now log in", "OK");
            }
            else
            {

            }    
        }
    }
}