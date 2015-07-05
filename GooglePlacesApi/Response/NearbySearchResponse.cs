using System;
using System.Collections.Generic;

namespace GooglePlacesApi
{
    public class NearbySearchResponse
    {
        public List<string> Html_Attributions  { get; set; }
        public List<Place> Results { get; set; }
        public string Next_page_token { get; set; }
    }
}