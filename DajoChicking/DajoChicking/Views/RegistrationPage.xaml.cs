using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DajoChicking.Models;

namespace DajoChicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        String name;
        String surname;
        String empID;
        String phone;
        String email;
        String jobTitle;
        String password;
        String user_image;
        String role;

        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/EmployeeRest/addEmp";

        public RegistrationPage()
        {
            InitializeComponent();
            image.Source = Device.OnPlatform(
          iOS: ImageSource.FromResource("DajoChicking.logo.png"),
          Android: ImageSource.FromResource("DajoChicking.logo.png"),
          WinPhone: ImageSource.FromResource("DajoChicking.logo.png"));
        }

        private async Task registerAsync(string data)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl+data);

                //var obj = JObject.Parse(json);
                DisplayAlert("Tapped", json.ToString(), "OK");
                clearLabels();
            }
            catch (Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
            }
        }

        

        public void clearLabels()
        {
            txt_id_number.Text = "";
            txt_name.Text = "";       
            txt_surname.Text = "";
            txt_contact.Text = "";
            txt_email.Text = "";
            txt_job_title.Text = "";
            txt_password.Text = "";
            //await Navigation.PushModalAsync(new MainPage(), false);
        }

        private async void sign_up(object sender, EventArgs e)
        {
            try
            {
                
                if (!String.IsNullOrEmpty(txt_name.Text))
                {
                    if (!String.IsNullOrEmpty(txt_surname.Text))
                    {
                        if (!String.IsNullOrEmpty(txt_id_number.Text))
                        {
                            if(!String.IsNullOrEmpty(txt_contact.Text))
                            {
                                if (!String.IsNullOrEmpty(txt_email.Text))
                                {
                                    if (!String.IsNullOrEmpty(txt_job_title.Text))
                                    {
                                        if (!String.IsNullOrEmpty(txt_password.Text))
                                        {
                                            name = txt_name.Text;
                                            surname = txt_surname.Text;
                                            empID = txt_id_number.Text;
                                            phone = txt_contact.Text;
                                            email = txt_email.Text;
                                            jobTitle = txt_job_title.Text;
                                            password = txt_password.Text;

                                            user_image = "99999";
                                            role = "emp";

                                            string data = "/"+empID+"/"+name+"/"+surname+"/"+ phone+"/"+ email+"/"+jobTitle+"/"+user_image+"/"+password+"/"+role;
                                            registerAsync(data);
                                        }
                                        else
                                        {
                                            DisplayAlert("Empty field required", "Please provide your password", "OK");
                                        }
                                    }
                                    else
                                    {
                                        DisplayAlert("Empty field required", "Please provide your job title", "OK");
                                    }
                                }
                                else
                                {
                                    DisplayAlert("Empty field required", "Please provide your email", "OK");
                                }
                            }
                            else
                            {
                                DisplayAlert("Empty field required", "Please provide your contact number", "OK");
                            }
                        }
                        else
                        {
                            DisplayAlert("Empty field required", "Please provide your ID number", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Empty field required", "Please provide your surname", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Empty field required", "Please provide your name", "OK");
                }
            }
            catch(Exception ee)
            {
                DisplayAlert("Elert", ee.Message, "OK");
            }
        }
    }


}