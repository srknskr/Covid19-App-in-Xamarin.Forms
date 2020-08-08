using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Covid
{
    public class APIViewModel : BaseViewModel
    {
        private List<Attributes> attributeList { get; set; }
        public List<Attributes> attributes
        {
            get
            {
                return attributeList;
            }

            set
            {
                if (value != attributeList)
                {
                    attributeList = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public APIViewModel()
        {
            GetDataAsync();
        }


        string url = "https://services1.arcgis.com/0MSEUqKaxRlEPj5g/arcgis/rest/services/ncov_cases/FeatureServer/1/query?f=json&where=(Confirmed%3E%200)%20OR%20(Deaths%3E0)%20OR%20(Recovered%3E0)&returnGeometry=false&outFields=*&orderByFields=Country_Region%20asc,Province_State%20asc&resultOffset=0&resultRecordCount=250";

        private async void GetDataAsync()
        {
            IsLoading = true;
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<Example>(content);
                //attributes = new List<Posts>(posts);
              List<Attributes>  data = new List<Attributes>();
              
                for (int i = 0; i < posts.features.Count; i++)
                {
                    data.Add(new Attributes
                    {
                        Country_Region = posts.features[i].attributes.Country_Region,
                        Confirmed = posts.features[i].attributes.Confirmed,
                        Recovered = posts.features[i].attributes.Recovered,
                        Deaths = posts.features[i].attributes.Deaths,

                    });
                }
                attributes = data;
            }
            else
            {
                Debug.WriteLine("Error when get data!");
            }
            IsLoading = false;
        }
    }
}
