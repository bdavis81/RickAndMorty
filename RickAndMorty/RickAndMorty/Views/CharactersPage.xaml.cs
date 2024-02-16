using RickAndMorty.ViewModels;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public partial class CharactersPage : ContentPage
    {
        CharactersViewModel _viewModel;

        public CharactersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CharactersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.OnDisappearing();
        }
    }
}