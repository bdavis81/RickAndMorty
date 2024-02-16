using CommunityToolkit.Mvvm.ComponentModel;
using RickAndMorty.Models;
using RickAndMorty.Services;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickAndMorty.ViewModels
{
    [QueryProperty(nameof(CharacterId), nameof(CharacterId))]
    public partial class CharacterDetailViewModel : ObservableObject
    {
        private readonly ICharacterRepository _characterRepository = DependencyService.Get<ICharacterRepository>();

        private int _characterId;

        [ObservableProperty]
        private Character _character;

        public int CharacterId
        {
            get
            {
                return _characterId;
            }
            set
            {
                _characterId = value;

                _ = LoadViewModel(value);
            }
        }

        public async Task LoadViewModel(int characterId)
        {
            try
            {
                Character = await _characterRepository.GetCharacter(characterId, CancellationToken.None);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
