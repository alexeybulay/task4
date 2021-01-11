using System;
using App3.ViewModel;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        internal string _nameExercise;
        private ProcessTrainViewModel processTrainViewModel;
        private readonly int _exerciseID;
        public int _secundes = 10;
        private readonly int Count;

        public TimerPage(int exerciseID, int _Count)
        {
            InitializeComponent();
            btnIncrement.Clicked += (s, e) =>
            {
                _secundes += 20;
                labelTimer.Text = _secundes.ToString();
            };
            Count = _Count;
            Device.StartTimer(TimeSpan.FromSeconds(1),
                OnTimeTick
            );
            _exerciseID = exerciseID;
        }

        bool OnTimeTick()
        {
            _secundes -= 1;
            TimeSpeak(1);
            if(_secundes <= 3) {btnSkip.IsEnabled = false;} else{}
                btnSkip.Clicked += (s, e) =>
            {
                _secundes = 4;
                btnIncrement.IsEnabled = false;
                labelTimer.Text = _secundes.ToString();
            };
            labelTimer.Text = _secundes.ToString();
            if (labelTimer.Text == "0")
            {
                NewPage();
                return false;
            }
            return true;
        }


         void NewPage()
        {
            switch (Count)
            {
                case 0:
                {
                         Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 0), false);
                         break;
                } 
                case 1:
                {
                         Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 1), false);
                         break;
                }
                case 2:
                {
                    Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 2), false);
                    break;
                }
                case 3:
                {
                    Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 3), false);
                    break;
                }
                case 4:
                {
                    Navigation.PushModalAsync(new ProcessTrain(_exerciseID, 4), false);
                    break;
                }

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Go();
        }

        void Go()
        {
            switch (Count)
            {
                case 0:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID);
                    break;
                }
                case 1:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID, "GrudAndBiceps");
                    break;
                }
                case 2:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID, "Press", "Press");
                    break;
                }
                case 3:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID, "NogiAndPlechi", "NogiAndPlechi", "NogiAndPlechi");
                    break;
                }
                case 4:
                {
                    processTrainViewModel = new ProcessTrainViewModel(_exerciseID, "SpinaAndTriceps", "SpinaAndTriceps", "SpinaAndTriceps", "SpinaAndTriceps");
                    break;
                }
            }

            this.BindingContext = processTrainViewModel;
            _nameExercise = processTrainViewModel.NameExercise;
            SpeakTextAsync(_nameExercise);
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushPopupAsync(new ExitInTrain());
            Navigation.PopAllPopupAsync();
            Navigation.PushPopupAsync(new ExitInTrain());
            return true;
        }

        public async void SpeakTextAsync(string nameExercise)
        {
            btnSkip.IsEnabled = false;
            await TextToSpeech.SpeakAsync($"Отдых {_secundes} секунд   Следующее упражнение {nameExercise}",
                new SpeechOptions
                {
                    Volume = 1f
                });
            btnSkip.IsEnabled = true;
            btnSkip.Clicked += (s, e) => { btnSkip.IsEnabled = false; };
        }

        public async void TimeSpeak(float _f)
        { 
            var setting = new SpeechOptions()
            {
                Volume = _f
            };
            if (_secundes == 4)
                await TextToSpeech.SpeakAsync("4", setting);   
            else if (_secundes == 3)
                await TextToSpeech.SpeakAsync("3", setting);
            else if (_secundes == 2)
                await TextToSpeech.SpeakAsync("2", setting);
            else if (_secundes == 1)
                await TextToSpeech.SpeakAsync("1", setting);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopModalAsync(false);
        }
    }
}