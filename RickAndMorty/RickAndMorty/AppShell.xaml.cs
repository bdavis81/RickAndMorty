using RickAndMorty.Views;
using Xamarin.Forms;

namespace RickAndMorty
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CharacterDetailPage), typeof(CharacterDetailPage));
        }

    }
}
