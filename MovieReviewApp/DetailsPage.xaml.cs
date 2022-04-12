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
    public partial class DetailsPage : ContentPage
    {
        private Review data { get; set; }
        public DetailsPage()
        {
            InitializeComponent();
        }

        public DetailsPage(Object ObjectData)
        {
            InitializeComponent();
            data = (Review)ObjectData;

            LblTitle.Text = data.Title.ToString();
            ImgPoster.Source = data.PosterPath.ToString();
            LblScore.Text = data.Score.ToString();
            LblNote.Text = data.MovieNote.ToString();

        }

        private void EditReviewBtn(object sender, EventArgs e)
        {
            
            LblTitle.Text = data.Title.ToString();
            ImgPoster.Source = data.PosterPath.ToString();
            LblScore.Text = data.Score.ToString();
            LblNote.Text = data.MovieNote.ToString();

            Review review = new Review();

            review.Score = data.Score;
            review.MovieNote = data.MovieNote;


            Navigation.PushAsync(new EditReviewPage(review));
        }
    }
}