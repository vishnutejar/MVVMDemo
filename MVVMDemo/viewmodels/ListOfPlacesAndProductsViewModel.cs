using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace MVVMDemo.viewmodels
{
    public class ListOfPlacesAndProductsViewModel : BaseViewModel
    {
        public ListOfPlacesAndProductsViewModel()
        {

            GetListOfData();
        }

        async void GetListOfData()
        {

            try
            {
                HttpClient httpClient = new HttpClient();

                var respons = httpClient.GetAsync("https://api.foursquare.com/v2/venues/explore?client_id=X0EU3WY3YLI1QMXEBBXVS0F3Z0RIT5A2V5FY4EMGY52AW5GR&client_secret=BSTWN50MTCR1Q2BTIANSN2ZKWBTG1FN0F4SUMNWEMDWITAYL&v=20180323&ll=40.7243,-74.0018&query=coffee&limit=1");

                if (respons.Result.IsSuccessStatusCode)
                {
                        var content = await respons.Result.Content.ReadAsStringAsync();
                   var Items = JsonConvert.DeserializeObject<Root>(content);


                }

                else
                {
                    //  App.Current.MainPage.DisplayAlert("MSG", respons.Result.Content.ReadAsStringAsync().Result, "");
                }
                //  EmplyeeData respo=JsonConvert.DeserializeObject(respons);

            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("", "" + e.Message, "ok");
            }

        }
    }
}
