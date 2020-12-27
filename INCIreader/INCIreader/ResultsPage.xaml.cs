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
            getInci = ingredientes;

            foundInciListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                var item = (Ingredient)e.SelectedItem;
                var itemPage = new ShowItemPage();
                itemPage.BindingContext = item;
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

            string test = myList[4];
            Console.WriteLine(test);

            base.OnAppearing();
            var ings = await App.Database.GetIngsAsync();
            var result = from x in ings where myList.Contains(x.Name) orderby x.Type, x.Name select x;
            foundInciListView.ItemsSource = result;

        }
    }
}