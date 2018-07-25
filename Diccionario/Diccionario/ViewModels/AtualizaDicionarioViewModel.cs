using Diccionario.Models;
using Xamarin.Forms;

namespace Diccionario.ViewModels
{
    public class AtualizaDicionarioViewModel : BaseViewModel
    {
        public Dicionario dici;

        public int Id;

        private string _palavra;
        public string Palavra
        {
            get { return _palavra; }
            set
            {
                if (SetProperty(ref _palavra, value))
                {
                    AtualizaCommand.ChangeCanExecute();
                }
            }
        }

        private string _significado;
        public string Significado
        {
            get { return _significado; }
            set
            {
                if (SetProperty(ref _significado, value))
                {
                    AtualizaCommand.ChangeCanExecute();
                }
            }
        }

        public Command AtualizaCommand { get; }

        public AtualizaDicionarioViewModel(int id)
        {
            AtualizaCommand = new Command(ExecuteAtualizaCommand, CanExecuteAtualizaCommand);
            dici = App.DAUtil.GetDataFromId(id);
            Id = dici.Id;
            Palavra = dici.Palavra;
            Significado = dici.Significado;
        }

        public async void ExecuteAtualizaCommand()
        {
            Dicionario d = new Dicionario();
            d.Id = Id;
            d.Palavra = Palavra;
            d.Significado = Significado;
            if (dici.Id.Equals(0)) App.DAUtil.SaveData(d);
            else App.DAUtil.UpdateData(d);
            await PopAsync<DicionarioViewModel>();
        }

        public bool CanExecuteAtualizaCommand()
        {
            return !(string.IsNullOrWhiteSpace(Palavra) || string.IsNullOrWhiteSpace(Significado));
        }
    }
}
