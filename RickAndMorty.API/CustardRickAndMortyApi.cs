using CustardApi.Objects;
using RickAndMorty.API.DTO;

namespace RickAndMorty.API
{
    public class CustardRickAndMortyApi : IRickAndMortyAPI, IDisposable
    {        
        private readonly Service _rickAndMortyService;
        private readonly CancellationTokenSource _cts;

        public CustardRickAndMortyApi(string baseUrl)
        {
            var baseUri = new Uri(baseUrl);

            _rickAndMortyService = new Service(
                baseUri.Host,
                baseUri.Port,
                baseUri.Scheme == Uri.UriSchemeHttps);

            _cts = new CancellationTokenSource();
        }

        public async Task<CharacterPageResponse> CharacterPage(int page, CancellationToken cancellationToken)
        {
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, cancellationToken);

            return await Task.Run(() => _rickAndMortyService.Get<CharacterPageResponse>($"api/character?page={page}"), linkedCts.Token);
        }

        public async Task<Character> CharacterSingle(int id, CancellationToken cancellationToken)
        {
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, cancellationToken);

            return await Task.Run(() => _rickAndMortyService.Get<Character>($"api/character/{id}"), linkedCts.Token);
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();

            _rickAndMortyService.Dispose();
        }
    }
}
