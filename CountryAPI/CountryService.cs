using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Media.Animation;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace CountryAPI
{
    public class CountryService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Country> GetCountryByName(string country_name)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "0DurM4xC7NfEx6EHWN67JaZcWaHh0wgnXj7CoqkT");
            try
            {
                string url = $"https://countryapi.io/api/name/{country_name}";    
                
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var jsonObject = JObject.Parse(jsonResponse);
                    var name = jsonObject.Properties().Select(p => p.Name).FirstOrDefault();
                    var countryJson = jsonObject[name].ToString(); //first two chars of country needed here

                    var country = JsonConvert.DeserializeObject<Country>(countryJson);

                    return country;
                }
                else
                {
                    throw new Exception("Failed to retrive country data");
                }
            }
            catch(Exception ex)
            {

                throw new Exception($"An error ocurred: {ex}");

            }
        }
    }
}
