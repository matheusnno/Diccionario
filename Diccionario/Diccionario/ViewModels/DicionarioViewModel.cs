using System.Collections.ObjectModel;
using System.Linq;
using Diccionario.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using Diccionario.Services;

namespace Diccionario.ViewModels
{
    public class DicionarioViewModel : BaseViewModel
    {

        #region GroupListView

        public IList<Dicionario> Items { get; private set; }

        private List<ObservableGroupCollection<string, Dicionario>> _groupedData;
        public List<ObservableGroupCollection<string, Dicionario>> GroupedData
        {
            get { return _groupedData; }
            set
            {
                if (SetProperty(ref _groupedData, value))
                {
                    BuscaPalavras();
                }
            }
        }

        #endregion

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
            Items = res.OrderBy(t => t.Palavra).ToList();

            #region Grouped

            GroupedData = Items.OrderBy(p => p.Palavra)
                               .GroupBy(p => p.Palavra[0].ToString())
                               .Select(p => new ObservableGroupCollection<string, Dicionario>(p)).ToList();

            #endregion

            IsBusy = false;
        }
    }
}
