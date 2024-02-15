namespace RickAndMorty.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterStatus Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public CharacterGender Gender { get; set; }
        public string Origin { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public string[] Episodes { get; set; }
    }

    public enum CharacterStatus
    {
        Unknown = 0,
        Alive = 1,
        Dead = 2
    }

    public enum CharacterGender
    {
        Unknown = 0,
        Female = 1,
        Male = 2,
        Genderless = 3
    }
}
