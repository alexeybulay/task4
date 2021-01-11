using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App3.DataAccess;
using App3.Model;
using App3.View;
using Xamarin.Forms;

namespace App3.ViewModel
{
    public class ProcessTrainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region PrivateProperty
        private int id;
        public int trainPressLength;
        private string imagePath;
        private string nameExercise;
        private int count;
        private DateTime timeStartTrain;
        private DateTime timeEndTrain;
        private TimeSpan timeResult;
        private readonly TimerPage timerPage;
        private readonly int _trainID;
        private readonly int _previoustrainID;
        #endregion

        #region PublicProperty
        public string Text { get; set; }
        public string NameTitle { get; set; }
        public string NameTrain { get; set; }

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public int TrainPressLength
        {
            get => trainPressLength;
            set
            {
                trainPressLength = value;
                OnPropertyChanged("TrainPressLength");
            }
        }
        public string ImagePath
        {
            get => imagePath;

            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        public string NameExercise
        {
            get => nameExercise;

            set
            {
                nameExercise = value;
                OnPropertyChanged("NameExercise");
            }
        }
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public DateTime TimeStartTrain
        {
            get => timeStartTrain;
            set
            {
                timeStartTrain = value;
                OnPropertyChanged("TimeStartTrain");
            }
        } 
        public DateTime TimeEndTrain
        {
            get => timeEndTrain;
            set
            {
                timeEndTrain = value;
                OnPropertyChanged("TimeEndTrain");
            }
        }  
        public TimeSpan TimeResult
        {
            get => timeResult;
            set
            {
                timeResult = value;
                OnPropertyChanged("TimeResult");
            }
        }

        #endregion

        #region Generics
        private ObservableCollection<TrainList.AllBody> allBodyList { get; set; }
        private ObservableCollection<TrainList.Press> pressList { get; set; }
        private ObservableCollection<TrainList.GrudAndBiceps> grudAndBicepsList { get; set; }
        private ObservableCollection<TrainList.NogiAndPlechi> nogiAndPlechiList { get; set; }
        public TrainListDbContext _TrainListDbContext { get; set; }
        public ObservableCollection<TrainList.AllBody> AllBodyList
        {
            get => allBodyList;
            set => allBodyList = value;
        } 
        public ObservableCollection<TrainList.Press> PressList
        {
            get => pressList;
            set => pressList = value;
        }
        public ObservableCollection<TrainList.GrudAndBiceps> GrudAndBicepsList
        {
            get => grudAndBicepsList;
            set => grudAndBicepsList = value;
        }  
        public ObservableCollection<TrainList.NogiAndPlechi> NogiAndPlechiList
        {
            get => nogiAndPlechiList;
            set => nogiAndPlechiList = value;
        }
        #endregion

        #region Command
        public ICommand NextExercise { get; set; }
        public ICommand GoToNextExercise { get; set; }
        public ICommand PreviousExercise { get; set; }
        public ICommand ExitInTrain { get; set; }
        #endregion

        #region TrainAllBody
        public ProcessTrainViewModel(int trainID)
        {
            NameTrain = "Всё тело";
            _previoustrainID = trainID;
            _trainID = trainID;
            _trainID++;
            _previoustrainID--;
            _TrainListDbContext = new TrainListDbContext();
            var trainAllBody = _TrainListDbContext.AllBodyDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.AllBodyDbSet.Count();
            ID = trainAllBody.AllBodyID;
            ImagePath = trainAllBody.ImagePath;
            NameExercise = trainAllBody.NameExercise;
            Count = trainAllBody.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            AllBodyList = new ObservableCollection<TrainList.AllBody>(
                _TrainListDbContext.AllBodyDbSet.Where(n => n.AllBodyID == trainID));
            CommandOperation(0);
        }
        #endregion

        #region TrainGrudAndBiceps
        public ProcessTrainViewModel(int trainID,string s)
        {
            NameTrain = "Грудь и бицепс";
            _previoustrainID = trainID;
            _trainID = trainID;
            _trainID++;
            _previoustrainID--;
            _TrainListDbContext = new TrainListDbContext();
            var trainGrudAndBiceps = _TrainListDbContext.GrudAndBicepsesDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.GrudAndBicepsesDbSet.Count();
            ID = trainGrudAndBiceps.GrudAndBicepsID;
            ImagePath = trainGrudAndBiceps.ImagePath;
            NameExercise = trainGrudAndBiceps.NameExercise;
            Count = trainGrudAndBiceps.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            GrudAndBicepsList = new ObservableCollection<TrainList.GrudAndBiceps>(
                _TrainListDbContext.GrudAndBicepsesDbSet.Where(n => n.GrudAndBicepsID == trainID));
            CommandOperation(1);
        }
        #endregion

        #region TrainPress
        public ProcessTrainViewModel(int trainID, string s, string ss)
        {
            NameTrain = "Пресс";
            _trainID = trainID;
            _trainID++;
            _TrainListDbContext = new TrainListDbContext();
            var trainPress = _TrainListDbContext.PressDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.PressDbSet.Count();
            ID = trainPress.PressID;
            ImagePath = trainPress.ImagePath;
            NameExercise = trainPress.NameExercise;
            Count = trainPress.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            PressList = new ObservableCollection<TrainList.Press>(
                _TrainListDbContext.PressDbSet.Where(n => n.PressID == trainID));
            CommandOperation(2);
        }
        #endregion

        #region TrainNogiAndPlechi
        public ProcessTrainViewModel(int trainID, string s, string ss, string sss)
        {
            NameTrain = "Ноги и плечи";
            _trainID = trainID;
            _trainID++;
            _TrainListDbContext = new TrainListDbContext();
            var trainNogiAndPlechi = _TrainListDbContext.NogiAndPlechiDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.NogiAndPlechiDbSet.Count();
            ID = trainNogiAndPlechi.NogiAndPlechiID;
            ImagePath = trainNogiAndPlechi.ImagePath;
            NameExercise = trainNogiAndPlechi.NameExercise;
            Count = trainNogiAndPlechi.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            NogiAndPlechiList = new ObservableCollection<TrainList.NogiAndPlechi>(
                _TrainListDbContext.NogiAndPlechiDbSet.Where(n => n.NogiAndPlechiID == trainID));
            CommandOperation(3);
        }

        #endregion

        #region TrainSpinaAndTriceps
        public ProcessTrainViewModel(int trainID, string s, string ss, string sss, string ssss)
        {
            NameTrain = "Спину и трицепс";
            _trainID = trainID;
            _trainID++;
            _TrainListDbContext = new TrainListDbContext();
            var spinaAndTriceps = _TrainListDbContext.SpinaAndTricepsDbSet.Find(trainID);
            TrainPressLength = _TrainListDbContext.SpinaAndTricepsDbSet.Count();
            ID = spinaAndTriceps.SpinaAndTricepsID;
            ImagePath = spinaAndTriceps.ImagePath;
            NameExercise = spinaAndTriceps.NameExercise;
            Count = spinaAndTriceps.Count;
            Text = String.Format($"Следующее {ID}/{TrainPressLength}");
            NameTitle = String.Format($"{ID}/{TrainPressLength}");
            NogiAndPlechiList = new ObservableCollection<TrainList.NogiAndPlechi>(
                _TrainListDbContext.NogiAndPlechiDbSet.Where(n => n.NogiAndPlechiID == trainID));
            CommandOperation(4);
        }
        #endregion

        internal void CommandOperation(int count)
        {
            if (_trainID == 1)
            {
                timeStartTrain = DateTime.Now;
                timeStartTrain.ToString("t");
            }
            if (_trainID > trainPressLength)
            {
                timeEndTrain = DateTime.Now;
                timeEndTrain.ToString("t");
                timeResult = timeEndTrain - timeStartTrain;
                NextExercise = new Command(
                    async () =>
                    {
                      //  await Application.Current.MainPage.Navigation.PopModalAsync(false);
                        await Application.Current.MainPage.Navigation.PushModalAsync(new EndTrainPage(count), false);
                    });
            }
            else
            {
                NextExercise = new Command(
                    async () =>
                    {
                       // await Application.Current.MainPage.Navigation.PopModalAsync(false);
                        await Application.Current.MainPage.Navigation.PushModalAsync(new TimerPage(_trainID, count), false);
                    });

            }
            //GoToNextExercise = new Command(
            //    async () =>
            //    {
            //        await Application.Current.MainPage.Navigation.PopModalAsync(false);
            //        await Application.Current.MainPage.Navigation.PushModalAsync(new ProcessTrain(_trainID - 1, count),
            //            false);
            //    });
            //PreviousExercise = new Command(
            //    async () =>
            //    {
            //        // await Application.Current.MainPage.Navigation.PopModalAsync(false);
            //        await Application.Current.MainPage.Navigation.PushModalAsync(new TimerPage(_previoustrainID,count),false);
            //    }
            //    );
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
