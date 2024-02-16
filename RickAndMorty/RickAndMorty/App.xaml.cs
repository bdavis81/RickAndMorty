using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using RickAndMorty.API;
using RickAndMorty.Services;
using Xamarin.Forms;

namespace RickAndMorty
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            const string rickAndMortyServiceUrl = "https://rickandmortyapi.com/";

            /*
             * I initially began working with the library you recommended but encountered issues with the certificate chain in my local environment.
             * Opting not to invest time in resolving this, I switched to using Flurl instead. This alternative allows for customization of the handler,
             * enabling me to bypass certificate validation.
             * 
             * TODO: Resolve the SSL certificate chain issue in the local environment.
             */
            //var rickAndMortyApi = new CustardRickAndMortyApi(rickAndMortyServiceUrl);
            var rickAndMortyApi = new FlurlRickAndMortyApi(rickAndMortyServiceUrl);
#if DEBUG
            FlurlRickAndMortyApi.OmitCertificateValidation();
#endif

            var characterRepository = new CharacterRepository(rickAndMortyApi);

            DependencyService.RegisterSingleton<ICharacterRepository>(characterRepository);

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios={Your App secret here};" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here};" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
