using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMDemo.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfPlacesAndProducts : ContentPage
    {
        public ListOfPlacesAndProducts()
        {
            InitializeComponent();
        }
    }
}