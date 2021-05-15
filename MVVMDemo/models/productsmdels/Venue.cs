using System.Collections.Generic;

public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public List<Category> categories { get; set; }
        public bool verified { get; set; }
        public Stats stats { get; set; }
        public Delivery delivery { get; set; }
        public BeenHere beenHere { get; set; }
        public Photos photos { get; set; }
        public HereNow hereNow { get; set; }
    }
