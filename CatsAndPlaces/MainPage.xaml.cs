using System.Diagnostics.Metrics;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CatsAndPlaces
{
    public partial class MainPage : ContentPage
    {
        public class Api
        {
            public Place place;
        }
      public class Place
        {
           [JsonPropertyName("post code")]
           public string? postCode { get; set; }
            public string? country { get; set; }
            [JsonPropertyName("country abbreviation")]
            public string? country_abbreviation { get; set; }
            public IList<Places> places { get; set; }
}
    public class Places
    {
            [JsonPropertyName("place name")]
            public string? placeName { get; set; }
        public string? longitude { get; set; }
        public string? state { get; set; }
            [JsonPropertyName("state abbreviation")]
            public string? state_abbreviation { get; set; }
            public string? latitude { get; set; }
        }


        public MainPage()
        {
            InitializeComponent();
        }
        private void PostalCode(object sender, EventArgs e)
        {
            string json;
            string url= "http://api.zippopotam.us/"+Country.Text+"/"+postalCode.Text;
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            Place p = JsonSerializer.Deserialize<Place>(json);

            string s = "Post code :" +p.postCode +"\n";
            s += "Country :" +p.country +"\n";
            s += "Country Abbreviation :" +p.country_abbreviation +"\n";
            s += "Place Name :" +p.places[0].placeName +"\n";
            s += "Longitude :" +p.places[0].longitude +"\n";
            s += "State :" +p.places[0].state +"\n";
            s += "State abbreviation :" +p.places[0].state_abbreviation +"\n";
            s += "Latitude :" +p.places[0].latitude +"\n";
            TheWholePlace.Text = s;
        }
    }

}
