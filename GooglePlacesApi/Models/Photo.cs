using System.Collections.Generic;

namespace GooglePlacesApi
{
    public class Photo
    {
        public int Height { get; set; }
        public List<string> Html_attributions { get; set; }
        public string Photo_reference { get; set; }
        public int Width { get; set; }
    }
}