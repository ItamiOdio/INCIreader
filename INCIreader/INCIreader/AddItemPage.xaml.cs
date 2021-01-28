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
    public partial class AddItemPage : ContentPage
    {
        List<Ingredient> ingredientsList;
        public AddItemPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ingredientsList = await App.Database.GetIngsAsync();           
        }

        async private void saveButton_Clicked(object sender, EventArgs e)
        {
            var ings = await App.Database.GetIngsAsync();
            if (nameEntry.Text != null && nameEntry.Text !="")
            {
                Ingredient newIngredient = (Ingredient)BindingContext; ;

                newIngredient.Name = nameEntry.Text;
                newIngredient.Type = typeEntry.Text;
                newIngredient.Harshness = harshnessEntry.Text;
                newIngredient.CG = cgEntry.Text;
                newIngredient.Vegan = veganEntry.Text;
                newIngredient.Notes = notesEditor.Text;

                if(newIngredient.ID !=0)
                {
                    await App.Database.UpdateIngAsync(newIngredient);
                    await Navigation.PopAsync();
                    await Navigation.PopAsync();
                }

                else
                {
                    if (!ExistsInDatabase(nameEntry.Text, ingredientsList))
                    {

                       await App.Database.SaveIngAsync(newIngredient);
                       await Navigation.PopAsync();
                     }
                    else
                     {
                    await DisplayAlert("You already have it!", "Your database already includes this ingredient. Try to edit it instead.", "OK");
                      }

                }
                
            }

            else
            {
                await DisplayAlert("Name field cannot be empty", "Ingredient cannot be saved", "OK");
            }
        }

        public bool ExistsInDatabase(string name, List<Ingredient> dbList)
        {
            var result = from x in dbList where x.Name.ToUpper() == name.ToUpper() select x;
            if (result.Count() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
          
        }

    }
}