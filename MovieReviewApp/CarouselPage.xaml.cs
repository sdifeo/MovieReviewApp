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
    public partial class CarouselPage : ContentPage
    {
        public CarouselPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Review>();
                var reviews = conn.Table<Review>().ToList();
                if (reviews.Count == 0)
                {
                    ReviewCarousel.RemoveLogicalChild(this);

                    Label label = new Label();
                    label.Text = "Please add a review";
                    label.HorizontalTextAlignment = TextAlignment.Center;
                    label.FontSize = 25;
                    label.TextColor = Color.Black;
                    MainStack.Children.Add(label);
                }
                else
                {
                    ReviewCarousel.ItemsSource = reviews;
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void GoToCreateReview(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateReviewPage());
        }
    }
}