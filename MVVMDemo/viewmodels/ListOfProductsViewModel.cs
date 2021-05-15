using MVVMDemo.utils;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMDemo.viewmodels
{
    public class ListOfProductsViewModel : BaseViewModel
    {
        Root productData { get; set; } = new Root();
        const string BaseUrl = "https://api.foursquare.com/v2/venues/explore?";
        const string client_id = "X0EU3WY3YLI1QMXEBBXVS0F3Z0RIT5A2V5FY4EMGY52AW5GR";
        const string client_secret = "BSTWN50MTCR1Q2BTIANSN2ZKWBTG1FN0F4SUMNWEMDWITAYL";
        const string v = "20180323";
        const string ll = "40.7243,-74.0018";
        const string query = "coffee";
        const string limit = "1";
        public ICommand LoadData { get; set; }

        public ListOfProductsViewModel()
        {
            LoadData = new Command(LoadDataFromREST);
        }

        private void LoadDataFromREST(object da)
        {
            GetPlacesByLatLang();
            getListOfVenues = new ObservableCollection<Venue>();
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
            getListOfVenues.Add(new Venue());
        }

        public string Header
        {
            get
            {
                return productData?.response?.suggestedFilters?.header;
            }
            set
            {

                productData.response.suggestedFilters.header = value;
                OnPropertyChanged("Header");

            }

        }
        public string headerLocation
        {
            get
            {
                return productData?.response?.headerLocation;
            }
            set
            {

                OnPropertyChanged("headerLocation");

            }

        }
        public string headerFullLocation
        {
            get
            {
                return productData?.response?.headerFullLocation;
            }
            set
            {

                OnPropertyChanged("headerFullLocation");

            }

        }

        public ObservableCollection<Venue> getListOfVenues;
        public ObservableCollection<Venue> Level2MenuItems
        {
            get { return getListOfVenues; }
            set
            {
                getListOfVenues = value;
                OnPropertyChanged("getListOfVenues");
            }
        }

        void SetVenuData()
        {

            List<Group2> groupData = productData?.response?.groups;
            getListOfVenues = new ObservableCollection<Venue>();
            foreach (var venuData in groupData[0].items)
            {

                getListOfVenues.Add(new Venue { name = "sample" });
            }
        }

        async void GetPlacesByLatLang()
        {

            HttpClient httpClient = new HttpClient();

            var points = CrossGeolocator.Current.GetPositionAsync().Result;
            if (points == null) {

                return;
            }
            var httpRequestMessage = await httpClient.GetAsync(Constants.GetVenuSeracgUrl(points.Latitude,points.Longitude));
            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var result = httpRequestMessage.Content.ReadAsStringAsync().Result;

                //  var Items = JsonConvert.DeserializeObject<Root>(content);//jsonstring to equ c# class
                // var Items = JsonConvert.SerializeObject(new { });//c# class to jsonstring

                productData = JsonConvert.DeserializeObject<Root>(result);

                InItViewData();
            }
        }

        private void InItViewData()
        {
            Header = productData.response.suggestedFilters.header;
            headerLocation = productData.response.headerLocation;
            headerFullLocation = productData.response.headerFullLocation;
            SetVenuData();
        }
    }

}
