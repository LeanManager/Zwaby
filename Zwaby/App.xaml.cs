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
    // changed iOS Bundle Identifier in Info.plist - removed .Zwaby to be able to install the app on my phone
    // check Apple Developer Center

    public partial class App : Application
    {
        // TODO: Check connectivity in RegistrationPage (and probably each time an SMS must be sent)

        public App()
        {
            InitializeComponent();

            // BookingDetailsViewModel "singleton"
            BookingDetailsViewModel.BookingDetailsViewModelInstance = new BookingDetailsViewModel();
            // TODO: Restore ViewModel State in this App class

            var sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

			var variable = sqLiteConnection.GetTableInfo(typeof(Customer).Name);

			if (variable.Count() == 0)
            {
                MainPage = new NavigationPage(new SignUpPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }

            sqLiteConnection.Dispose();
        }

        protected override void OnStart()
        {
            // Handle when your app starts; called after App constructor method finishes
        }

        protected override void OnSleep()
        {
			// Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
