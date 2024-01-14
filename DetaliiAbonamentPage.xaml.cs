using SalaFitness.Models;
using System;

namespace SalaFitness
{
    public partial class DetaliiAbonamentPage : ContentPage
    {
        private DetaliiAbonament detaliiAbonament;
        public DetaliiAbonamentPage()
        {
            InitializeComponent();
            detaliiAbonament = new DetaliiAbonament();
            BindingContext = detaliiAbonament;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var detaliiAbonament = (DetaliiAbonament)BindingContext;
            await App.Database.SaveDetaliiAbonamentAsync(detaliiAbonament);
            listView.ItemsSource = await App.Database.GetDetaliiAbonamenteAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var detaliiAbonament = (DetaliiAbonament)BindingContext;
            await App.Database.DeleteDetaliiAbonamentAsync(detaliiAbonament);
            listView.ItemsSource = await App.Database.GetDetaliiAbonamenteAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetDetaliiAbonamenteAsync();
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            var detaliiAbonament = (DetaliiAbonament)BindingContext;

            // Assuming you have a list of DetaliiAbonament items in your database
            // You might need to adapt this based on your actual data structure
            var existingList = await App.Database.GetDetaliiAbonamenteAsync();

            // Add the current detaliiAbonament to the list
            existingList.Add(detaliiAbonament);

            // Save the updated list to the database
            await App.Database.SaveDetaliiAbonamenteListAsync(existingList);

            // Refresh the listView to display the updated list
            listView.ItemsSource = existingList;
        }

    }
}
