using RickAndMorty.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RickAndMorty.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}