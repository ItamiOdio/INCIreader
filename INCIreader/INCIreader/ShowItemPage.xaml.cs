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
    public partial class ShowItemPage : ContentPage
    {
        public ShowItemPage()
        {
            InitializeComponent();

        }

        private void editButton_Clicked(object sender, EventArgs e)
        {
            Ingredient item = (Ingredient)BindingContext;
            var addItem = new AddItemPage();
            addItem.BindingContext = item;
            Navigation.PushAsync(addItem);
        }

        async private void deletetButton_Clicked(object sender, EventArgs e)
        {
            var ing = (Ingredient)BindingContext;
            var result = await DisplayAlert("Are you sure?", "The ingredient will be deleted", "OK", "Cancel");
            if(result)
            {
                await App.Database.DeleteIngAsync(ing);
                await Navigation.PopAsync();
            }

        }
    }
}