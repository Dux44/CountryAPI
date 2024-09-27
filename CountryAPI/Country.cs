using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CountryAPI;
using Newtonsoft.Json;

namespace CountryAPI
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("capital")]
        public string Capital { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("population")]
        public long Population { get; set; }
        [JsonProperty("area")]
        public double Area { get; set; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public Country()
        {
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
        }
        public void Edit()
        {

        }
        public void Delete()
        {

        }
    }
}
