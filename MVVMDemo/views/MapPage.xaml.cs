
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MVVMDemo.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
        }
        private async void GetPermissions()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                {
                    //  await DisplayAlert("Need Your Location","We need to access your location","Ok");
                }
                var result = CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                if (result.Result.ContainsKey(Permission.LocationWhenInUse))
                {
                    status = result.Result[Permission.LocationWhenInUse];
                }
            }
            if (status == PermissionStatus.Granted)
            {

                locationMap.IsShowingUser = true;
                hasLocationPermission = true;
                GetUserLatestLocation();
            }
            else
            {
                await DisplayAlert("Location Denied", "To Show your Current Location on Map we need this permission", "Ok");

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (hasLocationPermission)
            {
                var geolocator = CrossGeolocator.Current;
                geolocator.PositionChanged += Geolocator_PositionChanged;
                geolocator.StartListeningAsync(TimeSpan.Zero,100);
            }

            GetUserLatestLocation();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Geolocator_PositionChanged;

        }
        private void Geolocator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
          var lat=  e.Position.Latitude;
          var lan=  e.Position.Longitude;
            Position position = new Position(lat,lan);
            MoveMap(position);
        }

        private async void GetUserLatestLocation()
        {

            if (hasLocationPermission)
            {

                var geolocator = CrossGeolocator.Current;
                var Position = await geolocator.GetPositionAsync();

            }
        }
        private void MoveMap(Position position)
        {
            var center = new Position(position.Latitude, position.Latitude);
            var span = new MapSpan(center, 1, 1);
            locationMap.MoveToRegion(span);

        }

    }
}