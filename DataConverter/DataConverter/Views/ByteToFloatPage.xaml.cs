using System;
using DataConverter.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ByteToFloatPage : ContentPage
    {
        private ByteData ValueData { get; set; }

        public ByteToFloatPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            try
            {
                BindingContext = new ByteData(dataEntry.Text);
            }
            catch (Exception ex)
            {
                await DisplayAlert("tip", ex.Message, "确认");
            }
        }
    }
}