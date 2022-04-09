using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieReviewApp.Models;
using SQLite;

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
            string email = input_email.Text.Trim();
            string password = input_password.Text.Trim();

            if (email.Length == 0)
            {
                input_email.Focus();
                DisplayAlert("Email", "Email must not be empty", "OK");
                return;
            }

            if (password.Length == 0)
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
                User user = new User()
                {
                    Email = email,
                    Password = password
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<User>();
                    int row = conn.Insert(user);
                    if (row > 0)
                    {
                        DisplayAlert("Success", "You may now log in", "OK");
                    }
                    else
                    {
                        DisplayAlert("Failed", "Could not create new account", "OK");
                    }
                }
            }   
        }
    }
}