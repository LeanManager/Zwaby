using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zwaby.Models;
using Zwaby.ViewModels;
using Zwaby.Views;
using SQLite;
using System.Linq;
using XamarinForms.SQLite.SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Zwaby
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // BookingDetailsViewModel "singleton"
            BookingDetailsViewModel.BookingDetailsViewModelInstance = new BookingDetailsViewModel();
            BookingDetailsViewModel.BookingDetailsViewModelInstance.RestoreState(Current.Properties);

            TermsAndConditions.TermsAndConditionsInstance = new TermsAndConditions();
            TermsAndConditions.TermsAndConditionsInstance.RestoreState(Current.Properties);

            MainPage = new NavigationPage(new MainPage());

            //var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
			//var variable = sqLiteConnection.GetTableInfo(typeof(Customer).Name);
			//if (variable.Count() == 0)
            //{
            //    MainPage = new NavigationPage(new SignUpPage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new MainPage());
            //}
            //sqLiteConnection.Dispose();
        }

        protected override void OnStart()
        {
            // Handle when your app starts; called after App constructor method finishes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps

            var date = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDate;
            var time = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceTime;
            var price = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServicePrice;
            var duration = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceApproximateDuration;
            var street = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceStreet;
            var city = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceCity;
            var state = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceState;
            var zip = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceZipCode;
            var residence = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceResidence;
            var bedrooms = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBedrooms;
            var bathrooms = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceBathrooms;
            var serviceType = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceType;
            var notes = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceNotes;
            var serviceTime = BookingDetailsViewModel.BookingDetailsViewModelInstance.ServiceDateTime;

            BookingDetailsViewModel.BookingDetailsViewModelInstance.SaveState(Current.Properties, date, time,
                                                                             price, duration, street, city,
                                                                             state, zip, residence, bedrooms,
                                                                             bathrooms, serviceType, notes, serviceTime);

            var isAcknowledged = TermsAndConditions.TermsAndConditionsInstance.IsAcknowledged;
            TermsAndConditions.TermsAndConditionsInstance.SaveState(Current.Properties, isAcknowledged);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
