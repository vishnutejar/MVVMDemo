using MVVMDemo.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMDemo.viewmodels
{
    public class PersonInfViewModel : BaseViewModel
    {
        public ICommand ClickMeCommand { private set; get; }

        public Person  person {set;get;}= new Person { Age = 30, FirstName = "Vishnu", LastName = "theja" };
        public ObservableCollection<Person>  listOfPeople {set;get;}
       public PersonInfViewModel() {
            ClickMeCommand = new Command(() => App.Current.MainPage.DisplayAlert("","clicked Me","0k")); ;

            listOfPeople = new ObservableCollection<Person>();
            var person1 = new Person { Age = 22, FirstName = "Ram", LastName = "theja" };
            listOfPeople.Add(person1);

           var person2 = new Person { Age = 25, FirstName = "siva", LastName = "kumar" };
            listOfPeople.Add(person2);

           var person3= new Person { Age = 21, FirstName = "Praveen", LastName = "Kumar" };
            listOfPeople.Add(person3);

           var person4 = new Person { Age = 30, FirstName = "Vishnu", LastName = "theja" };
            listOfPeople.Add(person4);

        }

        public ObservableCollection<Person> PersonData
        {
            get
            { return listOfPeople; }

        }

        public string name{ get; set; }
        public string Name{


            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");

            }
        }

        public int Age {

            set {
                person.Age = value;
                OnPropertyChanged("Age");

            }
            get { return person.Age; }

        }



    }
}
