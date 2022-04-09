using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using MovieReviewApp.Models;

namespace MovieReviewApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void User_Login(object sender, EventArgs e)
        {
            string email = input_email.Text.Trim();
            string password = input_password.Text.Trim();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();

                User user = conn.Find<User>(email);
                if (user != null && password.Equals(user.Password))
                {
                    Navigation.PushAsync(new CarouselPage());
                }
                else
                {
                    DisplayAlert("Failed", "Account or password is invalid", "OK");
                }
            }
        }
    }
}