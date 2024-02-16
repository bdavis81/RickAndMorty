namespace RickAndMorty.API.DTO
{
    public class LocationResponse
    {
        public class Location
        {
            // The id of the location.
            public int id { get; set; }

            // The name of the location.
            public string name { get; set; }

            // The type of the location.
            public string type { get; set; }

            // The dimension in which the location is located.
            public string dimension { get; set; }

            // (urls) List of character who have been last seen in the location.
            public string[] residents { get; set; }

            // (url) Link to the location's own endpoint.
            public string url { get; set; }

            // Time at which the location was created in the database.
            public string created { get; set; }
        }
    }
}
