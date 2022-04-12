using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using SQLite;
using MovieReviewApp.Models;
using Newtonsoft.Json;

namespace MovieReviewApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateReviewPage : ContentPage
    {
        public CreateReviewPage()
        {
            InitializeComponent();

        }

        private async void SaveReviewBtn(object sender, EventArgs e)
        {
            var score = Review_Score.SelectedItem as string;
            var title = Movie_Title.Text.Trim();
            var notes = Movie_Notes.Text.Trim();

            if (score == null)
            {
                await DisplayAlert("Score", "Please select a score", "OK");
                return;
            }

            if (title == null)
            {
                await DisplayAlert("Title", "Please enter a movie title", "OK");
                return;
            }

            string endPoint = "https://api.themoviedb.org/3/search/movie?api_key=9f6a81c52b3da5625cddf0c0f60e2633&language=en-US&page=1&include_adult=false&query=";
            string queryTitle = title.Replace(" ", "%20");
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(endPoint + queryTitle);

                var movieSearch = JsonConvert.DeserializeObject<MovieSearch>(response);

                Review review = new Review()
                {
                    Score = score,
                    Title = title,
                    MovieNote = notes,
                    ReleaseDate = movieSearch.Results[0].Release_Date,
                    PosterPath = "https://image.tmdb.org/t/p/original/" + movieSearch.Results[0].Poster_Path,
                    Overview = movieSearch.Results[0].Overview
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Review>();
                    int row = conn.Insert(review);
                    if (row > 0)
                    {
                        await DisplayAlert("Success", "Review has been added", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Failed", "Review has not been added", "OK");
                    }
                }
            }
        }
    }
}