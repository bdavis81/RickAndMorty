using RickAndMorty.ViewModels;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public partial class CharacterDetailPage : ContentPage
    {
        public CharacterDetailPage()
        {
            InitializeComponent();

            BindingContext = new CharacterDetailViewModel();
        }
    }
}