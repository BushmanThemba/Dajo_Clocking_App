using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DajoChicking.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DajoChicking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerHistory : ContentPage
    {
        public Employee loged_in_employee = MainPage.emp;
        public List<ClockingObject> Clockings = new List<ClockingObject>();
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/ClockingRest/getAllByID/";

        public WorkerHistory()
        {
            InitializeComponent();
                    
            getClockingAsync(loged_in_employee.emp_id);
        }
        
        private async Task getClockingAsync(string emp_id)
        {
            try
            {
                //DisplayAlert("Display Employee ID", emp_id, "OK");
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl+""+emp_id);

                var obj = JObject.Parse(json);
                var tempClockings = (JArray)obj["Clockings"];
                bool status = (bool)obj["Status"];

                //DisplayAlert("Tapped", obj.ToString(), "OK");

                if (status)
                {
                    var data = "";
                    // var plist = JsonConvert.DeserializeObject<List<Person>>(json);
                    foreach (var item in tempClockings)
                    {
                            data = item.ToString();
                            ClockingObject clocking = (ClockingObject)JsonConvert.DeserializeObject<ClockingObject>(data);                            
                            Clockings.Add(clocking);
                            HistoryListView.ItemsSource = Clockings;                                 
                    }

                    
                }
                else
                {
                    var label = new Label { Text = "No History available.", TextColor = Color.FromHex("#77d065"), FontSize = 30, TranslationY = 30 };
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
            }
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

            //await Navigation.PushModalAsync(new Views.MyHistory(e.SelectedItem as Clocking), false);

            ClockingObject clocked = e.SelectedItem as ClockingObject;
             DisplayAlert("Tapped", clocked.in_location + "  was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}