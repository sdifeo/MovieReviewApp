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
            Movie_Description.Text = data.Overview;
            Movie_ReleaseDate.Text = data.ReleaseDate;
        }

        private void EditReviewBtn(object sender, EventArgs e)
        {
            
            LblTitle.Text = data.Title.ToString();
            ImgPoster.Source = data.PosterPath.ToString();
            LblScore.Text = data.Score.ToString();
            LblNote.Text = data.MovieNote.ToString();

            Navigation.PushAsync(new EditReviewPage(data));
        }
    }
}