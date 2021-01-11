using App3.ViewModel;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndTrainPage : ContentPage
    {
        private ProcessTrainViewModel processTrainViewModel;
        internal string _nameTrain;
        private int Count;
        public EndTrainPage(int _Count)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            btnExit.BackgroundColor = Color.FromRgba(255, 255, 140, 80);
            Count = _Count;
            btnExit.Clicked += (s, e) =>
            {
                Navigation.PushModalAsync(new MainPage2(), false);
                Navigation.PopModalAsync(false);
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Count)
            {
                case 0:
                {
                    processTrainViewModel = new ProcessTrainViewModel(1);
                    break;
                }
                case 1:
                {
                    processTrainViewModel = new ProcessTrainViewModel(1, "GrudAndBiceps");
                    break;
                }
                case 2:
                {
                    processTrainViewModel = new ProcessTrainViewModel(1, "Press", "Press");
                    break;
                }
                case 3:
                {
                    processTrainViewModel = new ProcessTrainViewModel(1, "NogiAndPlechi", "NogiAndPlechi", "NogiAndPlechi");
                    break;
                }
                case 4:
                {
                    processTrainViewModel = new ProcessTrainViewModel(1, "SpinaAndTriceps", "SpinaAndTriceps", "SpinaAndTriceps", "SpinaAndTriceps");
                    break;
                }
            }
            this.BindingContext = processTrainViewModel;
            _nameTrain = processTrainViewModel.NameTrain;
            SpeakAboutEndTrain(_nameTrain);
        }

        async void SpeakAboutEndTrain(string nameTrain)
        {
            var setting = new SpeechOptions()
            {
                Volume = 1f
            };
            await TextToSpeech.SpeakAsync($"Тренировка на {nameTrain} успешно завершена");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopModalAsync(false);
        }
    }
}