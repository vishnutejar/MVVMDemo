using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMDemo.models
{
   public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonInfo()
        { return $"{FirstName} {LastName} Age:{Age}"; }

    }
}
