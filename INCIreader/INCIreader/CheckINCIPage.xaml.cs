using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace INCIreader
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckINCIPage : ContentPage
    {
        public CheckINCIPage()
        {
            InitializeComponent();

        }



        async private void CheckButton_Clicked(object sender, EventArgs e)
        {
            string ings = inciListEditor.Text;

            if (ings != null)
            {
                await Navigation.PushAsync(new ResultsPage(ings));
            }
            else
            {
                await DisplayAlert("Your INCI is empty", "Paste your INCI and try again", "OK");
            }
            
        }

    }
}