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
    public partial class InciBasePage : ContentPage
    {
        public InciBasePage()
        {
            InitializeComponent();

            inciListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                var item = (Ingredient)e.SelectedItem;
                var itemPage = new ShowItemPage();
                itemPage.BindingContext = item;
                Navigation.PushAsync(itemPage);
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var ings = await App.Database.GetIngsAsync();
            var result = from x in ings orderby x.Type, x.Name select x;
            inciListView.ItemsSource = result; 
            
        }

    }
}