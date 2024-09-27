using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace CountryAPI
{
    public class DataBase
    {
        public string connectionString = "Data Source=countries.db;Version=3;";

        public DataBase() 
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Countries (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Capital TEXT, Region TEXT, Population INTEGER, Area NUMERIC)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
        public void AddCountry(Country country)
        {
            using(var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Countries (Name, Capital, Region, Population, Area) VALUES (@Name, @Capital, @Region, @Population, @Area)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", country.Name);
                command.Parameters.AddWithValue("@Capital", country.Capital);
                command.Parameters.AddWithValue("@Region", country.Region);
                command.Parameters.AddWithValue("@Population", country.Population);
                command.Parameters.AddWithValue("@Area", country.Area);
                command.ExecuteNonQuery();
            }
        }
        public void RemoveCountry()
        {

        }
        public void UpdateCountry(string new_country)
        {

        }
        public ObservableCollection<Country> GetCountryList() //this method need more attention
        {
            ObservableCollection<Country> countries = new ObservableCollection<Country>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Name, Capital, Region, Population, Area FROM Countries";
                using(var command = new SQLiteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())   
                        {
                            var country = new Country()
                            {
                                Name = reader["Name"].ToString(),
                                Capital = reader["Capital"].ToString(),
                                Region = reader["Region"].ToString(),
                                Population = Convert.ToInt64(reader["Population"]),
                                Area = Convert.ToDouble(reader["Area"]),
                            };
                            countries.Add(country);
                        }
                    }
                }
            }
            return countries;
        }
    }
}
