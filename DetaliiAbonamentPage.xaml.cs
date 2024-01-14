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

    }
}
