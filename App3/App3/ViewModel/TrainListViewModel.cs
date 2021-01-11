using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App3.DataAccess;
using App3.Model;
using App3.View;
using Xamarin.Forms;

namespace App3.ViewModel
{
    public class TrainListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<TrainList.AllBody> allBodyList { get; set; }
        private ObservableCollection<TrainList.GrudAndBiceps> grudAndBicepsesList { get; set; }
        private ObservableCollection<TrainList.Press> pressList { get; set; }
        private ObservableCollection<TrainList.NogiAndPlechi> nogiAndPlechiList { get; set; }
        private ObservableCollection<TrainList.SpinaAndTriceps> spinaAndTricepsList { get; set; }
        public TrainListDbContext _TrainListDbContext { get; set; }

        public ObservableCollection<TrainList.AllBody> AllBodyList
        {
            get => allBodyList;
            set => allBodyList = value;
        } 
        public ObservableCollection<TrainList.GrudAndBiceps> GrudAndBicepsList
        {
            get => grudAndBicepsesList;
            set => grudAndBicepsesList = value;
        }
        public ObservableCollection<TrainList.Press> PressList
        {
            get => pressList;
            set => pressList = value;
        }
        public ObservableCollection<TrainList.NogiAndPlechi> NogiAndPlechiList
        {
            get => nogiAndPlechiList;
            set => nogiAndPlechiList = value;
        }
        public ObservableCollection<TrainList.SpinaAndTriceps> SpinaAndTricepsList
        {
            get => spinaAndTricepsList;
            set => spinaAndTricepsList = value;
        }
        public ICommand StartTrain { get; set; }
        public TrainListViewModel(int trainCount)
        {
            _TrainListDbContext = new TrainListDbContext();
            var listAllBody = _TrainListDbContext.AllBodyDbSet.ToList();
            var listGrudAndBiceps = _TrainListDbContext.GrudAndBicepsesDbSet.ToList();
            var listPress = _TrainListDbContext.PressDbSet.ToList();
            var listSpinaAndTriceps = _TrainListDbContext.SpinaAndTricepsDbSet.ToList();
            var listNogiAndPlechi = _TrainListDbContext.NogiAndPlechiDbSet.ToList();
            AllBodyList = new ObservableCollection<TrainList.AllBody>(listAllBody);
            GrudAndBicepsList = new ObservableCollection<TrainList.GrudAndBiceps>(listGrudAndBiceps);
            PressList = new ObservableCollection<TrainList.Press>(listPress);
            SpinaAndTricepsList = new ObservableCollection<TrainList.SpinaAndTriceps>(listSpinaAndTriceps);
            NogiAndPlechiList = new ObservableCollection<TrainList.NogiAndPlechi>(listNogiAndPlechi);
            StartTrain = new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProcessTrain(1,trainCount),false);
                }
            );
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
