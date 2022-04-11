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
    public partial class CarouselPage : ContentPage
    {
        public CarouselPage()
        {
            InitializeComponent();

            if (ReviewCarousel.ItemsSource == null)
            {
                ReviewCarousel.RemoveLogicalChild(this);

                Label label = new Label();
                label.Text = "Please add a review";
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.FontSize = 25;
                label.TextColor = Color.Black;
                MainStack.Children.Add(label);
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