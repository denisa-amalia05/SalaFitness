using SalaFitness.Models;

namespace SalaFitness
{
    public partial class AbonamentEntryPage : ContentPage
    {
        public AbonamentEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetAbonamenteAsync();
        }

        async void OnAdaugaAbonamentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AbonamentPage(new Abonament())); // Aici adăugăm un nou obiect Abonament
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AbonamentPage(e.SelectedItem as Abonament));
            }
        }
    }
}
