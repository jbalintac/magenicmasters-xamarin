using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ContactManager.ViewModels;
using Newtonsoft.Json.Serialization;

namespace ContactManager.Services
{
    class DataService
    {
        static HttpClient client = new HttpClient();

        public async Task<ContactDataViewModel> GetContacts()
        {
            client.Timeout = TimeSpan.FromSeconds(5);

            var result = new ContactDataViewModel() { Contacts = new List<Contact>() };

            // Issue a request
            await client.GetAsync("http://10.155.64.110:8080/retrieve/contacts").ContinueWith(
                async getTask =>
                {
                    if (getTask.IsCanceled)
                    {
                        result.IsSuccessStatusCode = false;
                    }
                    else if (getTask.IsFaulted)
                    {
                        result.IsSuccessStatusCode = false;
                    }
                    else
                    {
                        var stringResult = await getTask.Result.Content.ReadAsStringAsync();
                        result.Contacts = JsonConvert.DeserializeObject<List<Contact>>(stringResult, new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            ObjectCreationHandling = ObjectCreationHandling.Auto
                        });
                        result.IsSuccessStatusCode = true;
                    }
                });

            return result;
        }
    }
}
