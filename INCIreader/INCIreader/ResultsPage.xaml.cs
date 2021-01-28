using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace INCIreader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        string getInci;

        public ResultsPage(string ingredientes)
        {
            InitializeComponent();
            getInci = ingredientes.ToUpper();

            foundInciListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                var item = (Ingredient)e.SelectedItem;
                var itemPage = new ShowItemPage();
                itemPage.BindingContext = item.ID;
                Navigation.PushAsync(itemPage);
            };
        }

        protected override async void OnAppearing()
        {
            var myList = getInci.Split(',');

            for (int i = 0; i < myList.Length; i++)
            {
                myList[i] = myList[i].Trim();
            }

            base.OnAppearing();
            var ings = await App.Database.GetIngsAsync();
            var result = from x in ings where myList.Contains(x.Name.ToUpper()) orderby x.Type, x.Name select x;
            foundInciListView.ItemsSource = result;
            if (result.Count() == 0)
            {
                if (!await DisplayAlert("No ingredientes found", "Make sure your ingredientes are divided by coma or insert missing ones into your database", null, "OK"))
                {
                    await Navigation.PopAsync();
                };

            }

        }
    }
}