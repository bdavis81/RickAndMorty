using RickAndMorty.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RickAndMorty.Services
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharacters(int pageIndex, CancellationToken cancellationToken);
        Task<Character> GetCharacter(int characterId, CancellationToken cancellationToken);
    }
}
