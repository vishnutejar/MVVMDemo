using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Response
    {
        public SuggestedFilters suggestedFilters { get; set; }
        public Warning warning { get; set; }
        public int suggestedRadius { get; set; }
        public string headerLocation { get; set; }
        public string headerFullLocation { get; set; }
        public string headerLocationGranularity { get; set; }
        public string query { get; set; }
        public int totalResults { get; set; }
        public SuggestedBounds suggestedBounds { get; set; }
        public List<Group2> groups { get; set; }
    }
