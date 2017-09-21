using DajoChicking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DajoChicking.Models;

namespace DajoChicking
{
    public partial class ViewWorkersHistory : ContentPage
    {
        public List<Employee> Employees = new List<Employee>();
        public Employee loged_in_employee = MainPage.emp;
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/EmployeeRest/getAllEmp";

        public ViewWorkersHistory()
        {
           // peopleList = MainViewModel.peopleList;
            InitializeComponent();

            getEmployeesAsync();


            //MainListView.ItemsSource = people;
        }

        private async Task getEmployeesAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl);

                var obj = JObject.Parse(json);
                var tempEmployees = (JArray)obj["Employees"];
                bool status = (bool)obj["Status"];
                
                if (status)
                {
                    var data = "";
                    //var list = JsonConvert.DeserializeObject<List<Employee>>(json);
                    //MainListView.ItemsSource = list;
                    foreach (var item in tempEmployees)
                    {
                        data = item.ToString();
                         Employee employee = (Employee)JsonConvert.DeserializeObject<Employee>(data);
                        
                        Employees.Add(employee);
                        MainListView.ItemsSource = Employees;
                    }
                }
                else
                {
                    var label = new Label { Text = "No workers available.", TextColor = Color.FromHex("#77d065"), FontSize = 30, TranslationY = 30 };
                }
            }

            catch (Exception e)
            {
                DisplayAlert("Tapped", e.Message , "OK");
            }
           
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

            await Navigation.PushModalAsync(new Views.MyHistory(e.SelectedItem as Employee), false);

            // DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
