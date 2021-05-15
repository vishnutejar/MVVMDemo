using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMDemo.viewmodels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public string BaseUrl = "http://dummy.restapiexample.com/api/v1/";
        HttpClient httpClient;
        public ICommand LoginCommand { get; set; }
        private string userName;
        private string password;
        private string salary;
        private string age;
        public LoginPageViewModel()
        {
            LoginCommand = new Command(ValidateLoginInfo);
        }

        private void ValidateLoginInfo(object obj)
        {
            if (string.IsNullOrEmpty(UserName))
            {

                App.Current.MainPage.DisplayAlert("Error", "Enter your UserName", "Ok");
            }
            else if (string.IsNullOrEmpty(Salary))
            {
                App.Current.MainPage.DisplayAlert("Error", "Enter your Salary", "Ok");

            }
            else if (string.IsNullOrEmpty(Age))
            {
                App.Current.MainPage.DisplayAlert("Error", "Enter your Age", "Ok");

            }
            else
            {
                httpClient = new HttpClient();
                EmplyeeData emplyeeData = new EmplyeeData
                {
                    Age = Age,
                    Name = UserName,
                    Salary = Salary
                };

                string jsonstring = JsonConvert.SerializeObject(emplyeeData);
                var jsonContent = new StringContent(jsonstring);

                 var respons=  httpClient.PostAsync("https://api.foursquare.com/v2/venues/explore?client_id=X0EU3WY3YLI1QMXEBBXVS0F3Z0RIT5A2V5FY4EMGY52AW5GR&client_secret=BSTWN50MTCR1Q2BTIANSN2ZKWBTG1FN0F4SUMNWEMDWITAYL&v=20180323&ll=40.7243,-74.0018&query=coffee&limit=1", jsonContent);

                if (respons.Result.IsSuccessStatusCode)
                {

                    App.Current.MainPage.DisplayAlert("MSG", respons.Result.Content.ReadAsStringAsync().Result, "");
                }
                else {
                  //  App.Current.MainPage.DisplayAlert("MSG", respons.Result.Content.ReadAsStringAsync().Result, "");
                }
                //  EmplyeeData respo=JsonConvert.DeserializeObject(respons);

            }
        }

        public string UserName
        {
            get
            { return userName; }
            set
            {

                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        public string Salary
        {
            get { return salary; }
            set { salary = value; OnPropertyChanged("Salary"); }
        }
        public string Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }
    }
}
