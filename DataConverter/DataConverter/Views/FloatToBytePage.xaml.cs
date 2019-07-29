using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConverter.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatToBytePage : ContentPage
    {
        private FloatData ValueData { get; set; }

        public FloatToBytePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                BindingContext = new FloatData(dataEntry.Text);
            }
            catch (Exception ex)
            {
                await DisplayAlert("tip", ex.Message, "确认");
            }
        }
    }
}