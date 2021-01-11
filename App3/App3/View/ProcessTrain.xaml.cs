using System.Threading;
using App3.ViewModel;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessTrain : ContentPage
    {
        private ProcessTrainViewModel processTrainViewModel;
        private readonly int _trainID;
        private readonly int Count;
        internal string _nameExercise;
        internal int _count;
        internal int _countExercise;
        public ProcessTrain(int trainID, int _Count)
        {
            InitializeComponent();
            Count = _Count;
            _trainID = trainID;
        }

        public ProcessTrain(int trainID)
        {
            InitializeComponent();
            _trainID = trainID;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Count)
            {
                case 0:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_trainID);
                        break;
                } 
                case 1:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_trainID, "GrudAndBiceps");
                        break;
                }
                case 2:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_trainID, "Press","Press");
                        break;
                }
                case 3:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_trainID, "NogiAndPlechi", "NogiAndPlechi", "NogiAndPlechi");
                        break;
                }
                case 4:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_trainID, "SpinaAndTriceps", "SpinaAndTriceps", "SpinaAndTriceps", "SpinaAndTriceps");
                        break;
                }
            }

            this.BindingContext = processTrainViewModel;
            _nameExercise = processTrainViewModel.NameExercise;
            _count = processTrainViewModel.Count;
            SpeakTextAsync(_nameExercise);
        }
        public async void SpeakTextAsync(string nameExercise)
        {
          checkButton.IsEnabled = false;
          var setting = new SpeechOptions()
            {
                Volume = 1f
            };
            await TextToSpeech.SpeakAsync($"{nameExercise}", setting);
            Thread.Sleep(150);
            await TextToSpeech.SpeakAsync($"сделайте {_count} повторений", setting);
          checkButton.IsEnabled = true;
          checkButton.Clicked += (s, e) => { checkButton.IsEnabled = false;};
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushPopupAsync(new ExitInTrain());
            Navigation.PopAllPopupAsync();
            Navigation.PushPopupAsync(new ExitInTrain());
            return true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopModalAsync(false);
        }
    }
}