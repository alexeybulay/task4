using App3.DataAccess;
using App3.Model;
using App3.ViewModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainListPage : ContentPage
    {
        private TrainListViewModel _trainListViewModel;
        const string zero = "Всё тело";
        const string one = "Грудь и бицепс";
        const string two = "Пресс";
        const string three = "Ноги и плечи";
        const string fourth = "Спина и трицепс";
        public int Count { get; set; }
        public TrainListPage(int _Count)
        {
            InitializeComponent();
            Count = _Count;
            mylist.ItemTapped += (s, e) => { ((ListView) s).SelectedItem = null; };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _trainListViewModel = new TrainListViewModel(Count);
            switch (Count)
            {
                case 0:
                    {
                        Title = zero;
                        mylist.ItemsSource = _trainListViewModel.AllBodyList;
                        #region AddedParametersAllBody
                        using (var _TrainListDbContext = new TrainListDbContext())
                        {
                            if (_TrainListDbContext.AllBodyDbSet.Count() == 0)
                            {
                                _TrainListDbContext.AllBodyDbSet.Add(
                                new TrainList.AllBody() { ImagePath = "firstGrud.gif", NameExercise = "Отжимания на коленях", Count = 10 }
                            );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "firstNogi.gif", NameExercise = "Перекаты", Count = 10 }
                                );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "firstPress.gif", NameExercise = "Подъем туловища на пресс", Count = 20 }
                                );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "firstSpina.gif", NameExercise = "Тяга гантелей в полусогнутом виде", Count = 10 }
                                );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "fivePress.gif", NameExercise = "Подтягивание локтей к коленям", Count = 20 }
                                );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "fourthGrud.gif", NameExercise = "Отжимания", Count = 10 }
                                );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "fourthPlechi.gif", NameExercise = "Тяга гантелей в наклоне", Count = 10 }
                                );
                                _TrainListDbContext.AllBodyDbSet.Add(
                                    new TrainList.AllBody() { ImagePath = "secondSpina.gif", NameExercise = "Подъем гантели с упором на колено", Count = 10 }
                                );
                                _TrainListDbContext.SaveChanges();
                            }
                        }
                        #endregion
                        break;
                    }
                case 1:
                    {
                        Title = one;
                        mylist.ItemsSource = _trainListViewModel.GrudAndBicepsList;

                        #region AddedParametersGrudAndBiceps

                        using (var _TrainListDbContext = new TrainListDbContext())
                        {
                            if (_TrainListDbContext.GrudAndBicepsesDbSet.Count() == 0)
                            {
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "firstBiceps.gif", NameExercise = "Подъем на бицепс", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "firstGrud.gif", NameExercise = "Отжимания на коленях", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "secondBiceps.gif", NameExercise = "Подъем гантели с упором на колено", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "secondGrud.gif", NameExercise = "Тяга гантели из за головы лежа", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "thrirdBiceps.gif", NameExercise = "Подъем гантелей сидя с отрицательным наклоном", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "thrirdGrud.gif", NameExercise = "Жим гантелей лежа на скамье", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "fourthBiceps.gif", NameExercise = "Молот", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "fourthGrud.gif", NameExercise = "Отжимания", Count = 10 }
                                );
                                _TrainListDbContext.GrudAndBicepsesDbSet.Add(
                                    new TrainList.GrudAndBiceps() { ImagePath = "sixthGrud.gif", NameExercise = "Подъём гантелей над головой сидя на скамье", Count = 10 }
                                );
                                _TrainListDbContext.SaveChanges();
                            }
                        }

                        #endregion

                        break;
                    }
                case 2:
                    {
                        Title = two;
                        mylist.ItemsSource = _trainListViewModel.PressList;

                        #region AddedParametersPress

                        using (var _TrainListDbContext = new TrainListDbContext())
                        {
                            if (_TrainListDbContext.PressDbSet.Count() == 0)
                            {
                                _TrainListDbContext.PressDbSet.Add(
                                new TrainList.Press() { ImagePath = "firstPress.gif", NameExercise = "Подъем туловища на пресс", Count = 20 }
                            );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "secondPress.gif", NameExercise = "Сгибания на пресс", Count = 20 }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press()
                                    {
                                        ImagePath = "thrirdPress.gif",
                                        NameExercise = "Подъём туловища к прямым ногам на пресс",
                                        Count = 20
                                    }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "fourthPress.gif", NameExercise = "Обратный пресс", Count = 20 }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "fivePress.gif", NameExercise = "Подтягивание локтей к коленям", Count = 20 }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "sixthPress.gif", NameExercise = "Сворачивание туловища", Count = 20 }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "sevensPress.gif", NameExercise = "Повороты торса с отягощением на пресс", Count = 20 }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "eightPress.gif", NameExercise = "Диагональный подъём туловища", Count = 20 }
                                );
                                _TrainListDbContext.PressDbSet.Add(
                                    new TrainList.Press() { ImagePath = "tensPress.gif", NameExercise = "Поочередный подъём ног на пресс", Count = 20 }
                                );
                                _TrainListDbContext.SaveChanges();
                            }

                        }

                        #endregion

                        break;
                    }
                case 3:
                    {
                        Title = three;
                        mylist.ItemsSource = _trainListViewModel.NogiAndPlechiList;

                        #region AddedParametersNogiAndPlechi

                        using (var _TrainListDbContext = new TrainListDbContext())
                        {
                            if (_TrainListDbContext.NogiAndPlechiDbSet.Count() == 0)
                            {
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                new TrainList.NogiAndPlechi() { ImagePath = "firstNogi.gif", NameExercise = "Перекаты", Count = 10 }
                            );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "firstPlechi.gif", NameExercise = "Подъем гантелей над головой", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "secondNogi.gif", NameExercise = "Приседание Пистолет", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "thrirdPlechi.gif", NameExercise = "Подъём гантелей через стороны", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "thrirdNogi.gif", NameExercise = "Приседание со штангой", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "fourthPlechi.gif", NameExercise = "Тяга гантелей в наклоне", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "fourthNogi.gif", NameExercise = "Приседание с гантелями", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "sixthPlechi.gif", NameExercise = "Поочередный подъём гантелей над головой", Count = 10 }
                                );
                                _TrainListDbContext.NogiAndPlechiDbSet.Add(
                                    new TrainList.NogiAndPlechi() { ImagePath = "secondPlechi.gif", NameExercise = "Шраги", Count = 10 }
                                );
                                _TrainListDbContext.SaveChanges();
                            }

                        }
                        #endregion

                        break;
                    }
                case 4:
                    {
                        Title = fourth;
                        mylist.ItemsSource = _trainListViewModel.SpinaAndTricepsList;

                        #region AddedParametersSpinaAndTriceps

                        using (var _TrainListDbContext = new TrainListDbContext())
                        {
                            if (_TrainListDbContext.SpinaAndTricepsDbSet.Count() == 0)
                            {
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                new TrainList.SpinaAndTriceps() { ImagePath = "firstSpina.gif", NameExercise = "Тяга гантелей в полусогнутом виде", Count = 10 }
                            );
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                    new TrainList.SpinaAndTriceps() { ImagePath = "firstTriceps.gif", NameExercise = "Разгибания рук назад с гантелями", Count = 10 }
                                );
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                   new TrainList.SpinaAndTriceps() { ImagePath = "secondSpina.gif", NameExercise = "Подъем гантели с упором на колено", Count = 10 }
                               );
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                   new TrainList.SpinaAndTriceps() { ImagePath = "secondTriceps.gif", NameExercise = "Тяга гантели из за головы лежа", Count = 10 }
                               );
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                    new TrainList.SpinaAndTriceps() { ImagePath = "thrirdSpina.gif", NameExercise = "Подъем гантелей сидя с отрицательным наклоном", Count = 10 }
                                );
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                    new TrainList.SpinaAndTriceps() { ImagePath = "thrirdTriceps.gif", NameExercise = "Французский жим лёжа сидя на скамье", Count = 10 }
                                );
                                _TrainListDbContext.SpinaAndTricepsDbSet.Add(
                                    new TrainList.SpinaAndTriceps() { ImagePath = "fourthSpina.gif", NameExercise = "Тяга штанги к поясу мышццы", Count = 10 }
                                );
                                _TrainListDbContext.SaveChanges();
                            }

                        }

                        #endregion

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            this.BindingContext = _trainListViewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopAsync(false);
        }
    }
}