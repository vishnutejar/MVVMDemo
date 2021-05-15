using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMDemo.utils
{
   public static class Constants
    {
       public const string DummyUrl = "https://api.foursquare.com/v2/venues/explore?client_id=X0EU3WY3YLI1QMXEBBXVS0F3Z0RIT5A2V5FY4EMGY52AW5GR&client_secret=BSTWN50MTCR1Q2BTIANSN2ZKWBTG1FN0F4SUMNWEMDWITAYL&v=20180323&ll=40.7243,-74.0018&query=coffee&limit=1";
       public const string VENUESSEARCHURL = "https://api.foursquare.com/v2/venues/explore?client_id={0}&client_secret={1}&v={2}&ll={3},{4}&query={5}&limit={6}";
        public const string client_id = "X0EU3WY3YLI1QMXEBBXVS0F3Z0RIT5A2V5FY4EMGY52AW5GR";
        public const string client_secret = "BSTWN50MTCR1Q2BTIANSN2ZKWBTG1FN0F4SUMNWEMDWITAYL";


      public static string GetVenuSeracgUrl(double latitude,double langtutied) {

            return string.Format(VENUESSEARCHURL, Constants.client_id, Constants.client_secret, "20180323", latitude, langtutied, "coffee", 10);
        }
    }
}
