using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace LodingPage
{
    class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //false 절대 레이아웃을 사용하고 만든다.
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "Twitter.png",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#50ABF1");
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 1000);
            await splashImage.ScaleTo(0.7, 1200, Easing.Linear);
            await splashImage.ScaleTo(150, 900, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new Page1());
        }
    }
}
