using Flurl;
using Flurl.Http;
using RickAndMorty.API.DTO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace RickAndMorty.API
{
    public class FlurlRickAndMortyApi : IRickAndMortyAPI
    {
        private readonly string _baseUrl;

        public FlurlRickAndMortyApi(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<CharacterPageResponse> CharacterPage(int page, CancellationToken cancellationToken)
        {
            return await _baseUrl.AppendPathSegment("api/character")
                .AppendQueryParam("page", page)
                .GetJsonAsync<CharacterPageResponse>(cancellationToken: cancellationToken);
        }

        public async Task<Character> CharacterSingle(int id, CancellationToken cancellationToken)
        {
            return await _baseUrl.AppendPathSegment("api/character")
                .AppendPathSegment(id)
                .GetJsonAsync<Character>(cancellationToken: cancellationToken);
        }

        public static void OmitCertificateValidation()
        {
            FlurlHttp.Clients.WithDefaults(builder => builder.ConfigureInnerHandler(handler => handler.ServerCertificateCustomValidationCallback = NoOpCertValidationCallback));
        }

        private static bool NoOpCertValidationCallback(HttpRequestMessage message, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors errors) => true;
    }
}
