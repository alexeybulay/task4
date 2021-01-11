using System.Threading.Tasks;
using Xamarin.Forms;
using Easing = Xamarin.Forms.Easing;

namespace App3
{
    public class SplashImage : ContentPage
    {
        private Image splashImage; // название для нашей картинки-приветствия
        private Image bethebest;
        private Image versionofyou; 
        public SplashImage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "start.jpg",
                Aspect = Aspect.Fill

            };
            bethebest = new Image
            {
                Source = "bethebest.png",
                Opacity = 0,
                HeightRequest = 30
            };
            versionofyou = new Image
            {
                Source = "versionofyou.png",
                Opacity = 0,
                HeightRequest = 35
            };

            sub.Children.Add(splashImage);
            sub.Children.Add(bethebest);
            sub.Children.Add(versionofyou);

            this.Content = sub;
   
      AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
      AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.3, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
      AbsoluteLayout.SetLayoutBounds(bethebest, new Rectangle(20, 700, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
      AbsoluteLayout.SetLayoutBounds(versionofyou, new Rectangle(20, 741, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)); }
        protected override async void OnAppearing()
        {
            await Task.Run(async () =>
            {
                await splashImage.ScaleTo(1.07, 1500, Easing.Linear);
                await bethebest.FadeTo(.9, 700, Easing.SpringOut);
                await versionofyou.FadeTo(.9, 700, Easing.SpringOut);
            });
           Application.Current.MainPage = new NavigationPage(new MainPage2()
           {
               BarBackgroundColor = Color.White
           });
        }

       
    }
}
