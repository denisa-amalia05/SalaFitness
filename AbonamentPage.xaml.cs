using SalaFitness.Models;

namespace SalaFitness
{
    public partial class AbonamentPage : ContentPage
    {
        Abonament abonament;

        public AbonamentPage(Abonament abonament)
        {
            InitializeComponent();
            this.abonament = abonament;
            BindingContext = this.abonament;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            abonament.Date = DateTime.UtcNow;
            await App.Database.SaveAbonamentAsync(abonament);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await App.Database.DeleteAbonamentAsync(abonament);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetaliiAbonamentPage
            {
                BindingContext = new DetaliiAbonament()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Your logic for handling the "Adaugă în listă" (Add to list) button
            // For example, you might want to navigate to a new page to add details to the abonament
            await Navigation.PushAsync(new DetaliiAbonamentPage
            {
                BindingContext = abonament // Pass the current abonament to the new page if needed
            });
        }




    }
}
