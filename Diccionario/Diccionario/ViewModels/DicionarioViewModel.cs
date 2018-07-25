using System;
using System.Collections.ObjectModel;
using System.Linq;
using Diccionario.Models;
using Xamarin.Forms;

namespace Diccionario.ViewModels
{
    public class DicionarioViewModel : BaseViewModel
    {
        public ObservableCollection<Dicionario> Results { get; }

        private string _palavra;
        public string Palavra
        {
            get { return _palavra; }
            set
            {
                if (SetProperty(ref _palavra, value))
                {
                    BuscaPalavras();
                }
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public Command<Dicionario> ShowItemSelectedCommand { get; }

        public Command AdicionarPalavraCommand { get; }

        public Command DeleteItemCommand { get; }

        public DicionarioViewModel()
        {
            AdicionarPalavraCommand = new Command(ExecuteAdicionarPalavraCommand);
            ShowItemSelectedCommand = new Command<Dicionario>(ExecuteShowItemSelectedCommand);
            DeleteItemCommand = new Command<Dicionario>(ExecuteDeleteItemCommand);

            Results = new ObservableCollection<Dicionario>();
            BuscaPalavras();
        }

        public async void ExecuteDeleteItemCommand(Dicionario palavra)
        {
            if (await DisplayAlert(palavra.Palavra, "¿Desea Borrar?", "Sí", "No"))
            {
                App.DAUtil.DeleteData(palavra);
                BuscaPalavras();
            }
        }

        public async void ExecuteAdicionarPalavraCommand()
        {
            await PushAsync<AtualizaDicionarioViewModel>(-1);
        }

        public async void ExecuteShowItemSelectedCommand(Dicionario palavra)
        {
            await PushAsync<AtualizaDicionarioViewModel>(palavra.Id);
        }

        public void BuscaPalavras()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var res = App.DAUtil.GetSomeData(Palavra);
            var resOrdered = res.OrderBy(t => t.Palavra);
            Results.Clear();
            foreach (var i in resOrdered)
            {
                Results.Add(i);
            }

            IsBusy = false;
        }
    }
}
