using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RickAndMorty.Models;
using RickAndMorty.Services;
using RickAndMorty.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RickAndMorty.ViewModels
{
    public partial class CharactersViewModel : ObservableObject
    {
        private readonly ICharacterRepository _characterRepository = DependencyService.Get<ICharacterRepository>();

        private int _loadedPagesNumber;
        private bool _isLoadingItems;

        public ObservableCollection<Character> Characters { get; } = new();

        private CancellationTokenSource _cts = new();

        [RelayCommand]
        public async Task LoadCharacters()
        {
            if (_isLoadingItems)
            {
                return;
            }

            _isLoadingItems = true;

            try
            {
                var models = await _characterRepository.GetCharacters(_loadedPagesNumber + 1, _cts.Token);
                foreach (var item in models)
                {
                    Characters.Add(item);
                }

                _loadedPagesNumber++;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _isLoadingItems = false;
            }
        }

        public void OnAppearing()
        {
            Characters.Clear();

            _cts = new();
            _loadedPagesNumber = 0;
            _ = LoadCharacters();
        }

        public void OnDisappearing()
        {
            _isLoadingItems = false;
            _cts.Cancel();
            _cts.Dispose();
        }

        [RelayCommand]
        public async Task InspectCharacter(Character character)
        {
            if (character == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(CharacterDetailPage)}?{nameof(CharacterDetailViewModel.CharacterId)}={character.Id}");
        }
    }
}