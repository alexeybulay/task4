using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public List<Settings> Settingses { get; set; }

        public Page3()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Settingses = new List<Settings>();
            {
                Settingses.Add(new Settings() {ImagePath = "settings.png", NameSetting = "Настройка 1"});
                Settingses.Add(new Settings() {ImagePath = "settings.png", NameSetting = "Настройка 2"});
                Settingses.Add(new Settings() {ImagePath = "settings.png", NameSetting = "Настройка 3"});
                Settingses.Add(new Settings() {ImagePath = "settings.png", NameSetting = "Настройка 4"});
                Settingses.Add(new Settings() {ImagePath = "settings.png", NameSetting = "Настройка 5"});
            }
            this.BindingContext = this;
            //button1.BackgroundColor =
            //button2.BackgroundColor =
            //button3.BackgroundColor =
            //button4.BackgroundColor =
            //button5.BackgroundColor =
            //button6.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
            //button1.Clicked += (s, e) =>
            //{
            //    var message = CrossMessaging.Current.EmailMessenger;
            //    if (message.CanSendEmail)
            //    {
            //        message.SendEmail("alexbas1304@gmail.com");
            //    }
            //};
            //button6.Clicked += Button78_Clicked;
        }

        //private async void Button78_Clicked(object sender, EventArgs e)
        //{
        //    bool result = await DisplayAlert("Выход", "Выход действительно хотите выйти?", accept: "Да", "Нет"); // await = преобразлвание Task<bool> в bool
        //    if (result == true)
        //        Environment.Exit(0);
        //    else return;
        //}
    }

    public class Settings
    {
        public string ImagePath { get; set; }
        public string NameSetting { get; set; }
    }
}