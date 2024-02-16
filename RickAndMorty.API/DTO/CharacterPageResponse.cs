namespace RickAndMorty.API.DTO
{
    public class CharacterPageResponse
    {
        public PageInfo info { get; set; }

        public Character[] results { get; set; }
    }
}
