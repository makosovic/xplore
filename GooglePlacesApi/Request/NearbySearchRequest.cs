using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace GooglePlacesApi
{
    public class NearbySearchRequest
    {
        public string ApiKey { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string Radius { get; private set; }
        public string Types { get; private set; }

        public string Url
        {
            get
            {
                    return string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius={2}&types={3}&key={4}",
                        Latitude,
                        Longitude,
                        Radius,
                        Types,
                        ApiKey
                    );
            }
        }

        public NearbySearchRequest(string apiKey, string latitude, string longitude, string radius, string types)
        {
            ApiKey = apiKey;
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
            Types = types;
        }

        public NearbySearchResponse Execute()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                throw new ApplicationException("Request was not successful!");
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                NearbySearchResponse placeSearchResponse;
                using (Stream s = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    placeSearchResponse = serializer.Deserialize<NearbySearchResponse>(reader);
                }

                response.Close();
                return placeSearchResponse;
            }
            throw new ApplicationException("Response did not containt OK Status code!");
        }

    }
}
