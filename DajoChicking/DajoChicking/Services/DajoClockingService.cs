using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.Services
{
    class DajoClockingService
    {
        public async Task<List<Person>> getHelloAsync()
        {
            RestClient<Person> restClient = new RestClient<Person>();
            var person = await restClient.GetAsync();

            return person;
        }
    }
}
