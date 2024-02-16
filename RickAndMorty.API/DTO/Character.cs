namespace RickAndMorty.API.DTO
{
    public class Character
    {
        // The id of the character.
        public int id { get; set; }

        // The name of the character.
        public string name { get; set; }

        // The status of the character ('Alive', 'Dead' or 'unknown').
        public string status { get; set; }

        // The species of the character.
        public string species { get; set; }

        // The type or subspecies of the character.
        public string type { get; set; }

        // The gender of the character ('Female', 'Male', 'Genderless' or 'unknown').
        public string gender { get; set; }

        // Name and link to the character's origin location.
        public LocationInfo origin { get; set; }

        // Name and link to the character's last known location endpoint.
        public LocationInfo location { get; set; }

        // (url) Link to the character's image. All images are 300x300px and most are medium shots or portraits since they are intended to be used as avatars.
        public string image { get; set; }

        // List of episodes in which this character appeared.            
        public string[] episode { get; set; }

        // (url) Link to the character's own URL endpoint.
        public string url { get; set; }

        // Time at which the character was created in the database.
        public string created { get; set; }
    }

    public class LocationInfo
    {
        // The name of the character
        public string name { get; set; }

        // (url) Link to the location's own URL endpoint.
        public string url { get; set; }
    }
}
