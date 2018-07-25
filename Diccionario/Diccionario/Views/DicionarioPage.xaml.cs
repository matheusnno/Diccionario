using Diccionario.ViewModels;
using Xamarin.Forms;

namespace Diccionario.Views
{
    public partial class DicionarioPage : ContentPage
    {
        private DicionarioViewModel ViewModel => BindingContext as DicionarioViewModel;

        public DicionarioPage()
        {
            InitializeComponent();

            BindingContext = new DicionarioViewModel();

        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ShowItemSelectedCommand.Execute(e.SelectedItem);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new DicionarioViewModel();
        }

        void OnDelete(object sender, System.EventArgs e)
        {
            var it = ((MenuItem)sender);
            ViewModel.DeleteItemCommand.Execute(it.BindingContext);
        }
    }
}
