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

            // Verifică dacă BindingContext este de tipul așteptat
            if (BindingContext is Abonament abonament)
            {
                // Obține lista de produse asociate acestui abonament
                var listProducts = await App.Database.GetListProductsAsync(abonament.ID);


                // Asigură-te că abonamentListView este definit în fișierul XAML și are x:Name="abonamentListView"
                abonamentListView.ItemsSource = listProducts;
            }
        }


    }
}
