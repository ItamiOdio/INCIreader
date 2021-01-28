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
        Ingredient item;

        public ShowItemPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            int id = (int)BindingContext;
            item = await App.Database.GetSingleIng(id);           
            itemName.Text = item.Name;
            itemType.Text = item.Type;
            itemHarshness.Text = item.Harshness;
            itemCG.Text = item.CG;
            itemVegan.Text = item.Vegan;
            itemNotes.Text = item.Notes;

        }



        private void editButton_Clicked(object sender, EventArgs e)
        {
            var addItem = new AddItemPage();
            addItem.BindingContext = item;
            Navigation.PushAsync(addItem);
        }

        async private void deletetButton_Clicked(object sender, EventArgs e)
        {           
            var result = await DisplayAlert("Are you sure?", "The ingredient will be deleted", "OK", "Cancel");
            if(result)
            {
                await App.Database.DeleteIngAsync(item);
                await Navigation.PopAsync();
            }

        }
    }
}