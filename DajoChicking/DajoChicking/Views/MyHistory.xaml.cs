using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DajoChicking.Models;

namespace DajoChicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyHistory : ContentPage
    {
        List<ClockingObject> Clockings = new List<ClockingObject>();
        private string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/ClockingRest/getAllByID/";
        public Label HelloWorldLabel;
        String fullname = "";

        public MyHistory(Employee employee)
        {

            InitializeComponent();
            historyPreogressBar.IsRunning = true;
            historyPreogressBar.IsVisible = true;
            WebServiceUrl = WebServiceUrl + "" + employee.emp_id;
            fullname = employee.name + " " + employee.surname;
            lblName.Text = fullname;
            getClockingAsync();

        }

        private async Task getClockingAsync()
        {
            historyPreogressBar.IsRunning = true;
            historyPreogressBar.IsVisible = true;


            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl);

                var obj = JObject.Parse(json);
                var tempClockings = (JArray)obj["Clockings"];
                bool status = (bool)obj["Status"];

                if (status)
                {
                    var data = "";
                    // var plist = JsonConvert.DeserializeObject<List<Person>>(json);
                    foreach (var item in tempClockings)
                    {
                        data = item.ToString();
                        var clocking = JsonConvert.DeserializeObject<ClockingObject>(data);
                        Clockings.Add(clocking);

                        // DisplayAlert("Tapped", data, "OK");
                        MainListView.ItemsSource = Clockings;
                    }
                }
                else
                {
                    var label = new Label { Text = "No History available.", TextColor = Color.FromHex("#77d065"), FontSize = 30, TranslationY = 30 };
                }

                historyPreogressBar.IsRunning = false;
                historyPreogressBar.IsVisible = false;
            }
            catch (Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
                historyPreogressBar.IsRunning = false;
                historyPreogressBar.IsVisible = false;
            }
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

            //await Navigation.PushModalAsync(new Views.MyHistory(e.SelectedItem as Clocking), false);

            // DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}