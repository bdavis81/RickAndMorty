using RickAndMorty.API.DTO;

namespace RickAndMorty.API
{
    /// <summary>
    /// Disclaimer: Notable implementations of this API already exist, and in a real-world scenario, 
    /// I would explore these pre-existing solutions as a first step. However, given that this is a 
    /// test project with optional requirements suggesting the use of a specific library, I am 
    /// developing a custom implementation for the purpose of this task.
    /// </summary>
    public interface IRickAndMortyAPI
    {
        Task<CharacterPageResponse> CharacterPage(int page, CancellationToken cancellationToken);
        Task<Character> CharacterSingle(int id, CancellationToken cancellationToken);
    }
}
