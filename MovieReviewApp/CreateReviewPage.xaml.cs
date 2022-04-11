using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieReviewApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateReviewPage : ContentPage
    {
        public CreateReviewPage()
        {
            InitializeComponent();

        }

        private void SaveReviewBtn(object sender, EventArgs e)
        {
            var score = Review_Score.Text;
            var title = Movie_Title.Text;

            if (score == null)
            {
                DisplayAlert("Score", "Please select a score", "OK");
            }

            if (title == null)
            {
                DisplayAlert("Title", "Please enter a movie title", "OK");
            }
        }
    }
}