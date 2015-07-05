using System.Collections.Generic;

namespace GooglePlacesApi
{
    public class Place
    {
        public string Icon { get; set; }
        public Geometry Geometry { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Opening_hours Opening_hours { get; set; }
        public List<Photo> Photos { get; set; }
        public string Place_id { get; set; }
        public string Scope { get; set; }
        public List<Alt_id> Alt_ids { get; set; }
        public string Reference { get; set; }
        public List<string> Types { get; set; }
        public string Vicinity { get; set; }
    }
}