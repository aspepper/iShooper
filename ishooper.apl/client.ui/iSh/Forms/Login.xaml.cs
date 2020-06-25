using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace iSh.Forms
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        void btCadastro_Clicked(System.Object sender, System.EventArgs e)
        {
            Browser.OpenAsync(new Uri("http://www.ishooper.com/enrollment"), new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
        }

        void btLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Forms.Home());
        }

        public void OpenBrowser(Uri uri)
        {
            Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }


    }
}
