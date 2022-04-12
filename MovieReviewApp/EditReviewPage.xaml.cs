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
    public partial class EditReviewPage : ContentPage
    {
        private Review data { get; set; }
        public EditReviewPage()
        {
            InitializeComponent();
        }

        public EditReviewPage(object ObjectData)
        {
            InitializeComponent();
            data = (Review)ObjectData;

            Review_Score.SelectedItem = data.Score.ToString();
            LblNote.Text = data.MovieNote.ToString();
        }

        private void SaveBtnReview(object sender, EventArgs e)
        { 
            var newScore = Review_Score.SelectedItem.ToString();
            var newNote = LblNote.Text.ToString().Trim();

            data.Score = newScore;
            data.MovieNote = newNote;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Review>();
                int row = conn.Update(data);
                if (row > 0)
                {
                    DisplayAlert("Success", "review updated", "OK");
                }
                else
                {
                    DisplayAlert("Failed", "review not updated", "OK");
                }
            }
        }
    }
}