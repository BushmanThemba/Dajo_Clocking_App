using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DajoChicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        string email;
        public ForgotPassword()
        {
            InitializeComponent();
            image.Source = Device.OnPlatform(
           iOS: ImageSource.FromResource("DajoChicking.logo.png"),
           Android: ImageSource.FromResource("DajoChicking.logo.png"),
           WinPhone: ImageSource.FromResource("DajoChicking.logo.png"));
        }

        private async void submit_email(object sender, EventArgs e)
        {
            try
            {
                email = txt_email_address.Text;
                if(!String.IsNullOrEmpty(txt_email_address.Text))
                {
                    DisplayAlert("Tapped", "Password sumbitted to you email", "OK");
                }
                else
                {
                    DisplayAlert("Tapped", "Please enter email address", "OK");
                }
                              
            }
            catch (Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
            }
        }
    }
}