using RickAndMorty.API;
using RickAndMorty.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RickAndMorty.Services
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IRickAndMortyAPI _rickAndMortyAPI;

        /*
         * If the data were subject to frequent changes, implementing expiration logic would be necessary. 
         * However, since this data is retrieved through a GET request, which is inherently idempotent, 
         * I will opt for using dictionaries to facilitate caching without the need for expiration mechanisms.
         */
        private readonly ConcurrentDictionary<int, Character> _characterCache = new();
        private readonly ConcurrentDictionary<int, Character[]> _pageCache = new();

        public CharacterRepository(IRickAndMortyAPI rickAndMortyAPI)
        {
            _rickAndMortyAPI = rickAndMortyAPI;
        }

        public async Task<IEnumerable<Character>> GetCharacters(int pageIndex, CancellationToken cancellationToken)
        {
            if (_pageCache.TryGetValue(pageIndex, out var page))
            {
                return page;
            }
            else
            {
                var response = await _rickAndMortyAPI.CharacterPage(pageIndex, cancellationToken);

                page = response.results
                    .Select(CacheCharacter)
                    .ToArray();

                return _pageCache.AddOrUpdate(pageIndex, page, (id, node) => page);
            }
        }

        public async Task<Character> GetCharacter(int characterId, CancellationToken cancellationToken)
        {
            if (_characterCache.TryGetValue(characterId, out var character))
            {
                return character;
            }
            else
            {
                var response = await _rickAndMortyAPI.CharacterSingle(characterId, cancellationToken);

                return CacheCharacter(response);
            }
        }

        public Character CacheCharacter(API.DTO.Character dto)
        {
            var model = CharacterFactory(dto);

            return _characterCache.AddOrUpdate(model.Id, CharacterFactory(dto), (id, node) =>
            {
                node.Name = dto.name;
                node.Name = dto.name;
                node.Status = (CharacterStatus)Enum.Parse(typeof(CharacterStatus), dto.status, true);
                node.Species = dto.species;
                node.Type = dto.type;
                node.Gender = (CharacterGender)Enum.Parse(typeof(CharacterGender), dto.gender, true);
                node.Origin = dto.origin.name;
                node.Location = dto.location.name;
                node.Image = dto.image;
                node.Episodes = dto.episode;

                return node;
            });
        }

        private static Character CharacterFactory(API.DTO.Character dto)
        {
            return new Character
            {
                Id = dto.id,
                Name = dto.name,
                Status = (CharacterStatus)Enum.Parse(typeof(CharacterStatus), dto.status, true),
                Species = dto.species,
                Type = dto.type,
                Gender = (CharacterGender)Enum.Parse(typeof(CharacterGender), dto.gender, true),
                Origin = dto.origin.name,
                Location = dto.location.name,
                Image = dto.image,
                Episodes = dto.episode,
            };
        }
    }
}
