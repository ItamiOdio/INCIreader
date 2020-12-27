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
            await Navigation.PushAsync(new ResultsPage(ings));
        }
    }
}