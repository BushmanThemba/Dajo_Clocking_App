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
using Xamarin.Forms;



namespace DajoChicking

{

    public partial class Clocking : ContentPage
    {

        //Timer t = new Timer();
        public string id;
        public string date;
        string in_time;
        public string in_location;
        public string in_confirm;
        public string out_location;
        public string out_confirm;
        public string out_time;

        Employee logged_in_employee = MainPage.emp;

        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/ClockingRest/";


        //  public Label intime;
        //  private TimeZoneInfo timeZone;




        public Clocking()
        {

            InitializeComponent();

        }

        private async void clockin(object sender, EventArgs e)
        {


            try
            {

                /* id = txtID.Text;
                 date = lblDate.Text;
                  in_time = txtinTime.Text;
                   in_location = lbllocation.Text;
                 in_confirm = */
                var time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
                DateTime dateTime = DateTime.UtcNow.Date;
                var today = dateTime.ToString("dd-MM-yyyy");

                /*To be selected using Geo location*/
                in_location = "Dajo";

                if (in_location.Equals("Dajo"))
                {
                    in_confirm = "Yes";

                }
                else
                {
                    in_confirm = "No";
                }


                await getclockinAsync(logged_in_employee.emp_id, today, time, in_location, in_confirm);


            }
            catch (Exception ee)
            {
                DisplayAlert("MessageBox", ee.Message, "OK");
            }

        }


        /* DisplayAlert("Else", "Clicked", "OK");*/

        //DateTime date = DateTime.Now;
        //string dateWithFormat = date.ToString("dd - MM - yyyy");

        // string in_time = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone).ToString("HH:mm:ss");
        // string.Format("{0:MMMM dd, yyyy}", DateTime.Now);



        private async Task getclockinAsync(string id, string date, string in_time, string in_location, string in_confirm)
        {
              var link = WebServiceUrl +  "clockIn" + "/" + id + "/" + date + "/" + in_time + "/" + in_location + "/" + in_confirm;

            try

            {
                /* string data = "/" + id + "/" + date + "/" + in_time + "/" + in_location + "/" + in_confirm;
                 string data = "/" + "1234" + "/" + "2017" + "/" + "10:15" + "/" + "Siyabuswa"+"/"+"Yes";*/

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl + "clockIn" + "/" + id + "/" + date + "/" + in_time + "/" + in_location + "/" + in_confirm);

                DisplayAlert("Successfull!!!", json.ToString(), "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Warning!!!", ex.Message, "OK");
            }
        }

        private async void clockout(object sender, EventArgs e)
        {
            try
            {

                var time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
                DateTime dateTime = DateTime.UtcNow.Date;
                var today = dateTime.ToString("dd-MM-yyyy");

                /*To be selected using Geo location*/
                out_location = "Dajo";

                if (out_location.Equals("Dajo"))
                {
                    out_confirm = "Yes";

                }
                else
                {
                    out_confirm = "No";
                }

                // await getclockoutAsync(id, date, in_time, out_location, in_confirm);
                await getclockoutAsync(logged_in_employee.emp_id, today, time, out_location, out_confirm);

            }
            catch (Exception ee)
            {
                DisplayAlert("Warning!!!", ee.Message, "OK");
            }

        }

        private async Task getclockoutAsync(string id, string date, string out_time, string out_location, string out_confirm)
        {

            var link = WebServiceUrl + "clockOut" + "/" + id + "/" + date + "/" + out_time + "/" + out_location + "/" + out_confirm;

            try

            {

                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl + "clockOut" + "/" + id + "/" + date + "/" + out_time + "/" + out_location + "/" + out_confirm);



                DisplayAlert("Successfull!!!", json.ToString(), "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Warning!!!", ex.Message, "OK");
            }
        }

    }
}
