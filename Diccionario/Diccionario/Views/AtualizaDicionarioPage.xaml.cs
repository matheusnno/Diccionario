using Diccionario.ViewModels;
using Xamarin.Forms;

namespace Diccionario.Views
{
    public partial class AtualizaDicionarioPage : ContentPage
    {
        private AtualizaDicionarioViewModel ViewModel => BindingContext as AtualizaDicionarioViewModel;

        public AtualizaDicionarioPage()
        {
            InitializeComponent();

            BindingContext = new AtualizaDicionarioViewModel(-1);

            Palavra.Keyboard = Keyboard.Create(0);
            Significado.Keyboard = Keyboard.Create(0);

            Palavra.Focus();
        }

        void PalavraCompleted(object sender, System.EventArgs e)
        {
            Significado.Focus();
        }

        void SignificadoCompleted(object sender, System.EventArgs e)
        {
            if (ViewModel.AtualizaCommand.CanExecute(e)) ViewModel.AtualizaCommand.Execute(e);
            else Significado.Focus();
        }
    }
}
