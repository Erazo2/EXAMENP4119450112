using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXAMENP4119450112.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListGeo : ContentPage
    {
        public PageListGeo()
        {
            InitializeComponent();
        }

        private void listloca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seleccion = (Models.Localizacion)e.CurrentSelection[0];


            var page = new Views.PageMap();
            page.BindingContext = seleccion;
            Navigation.PushAsync(page);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listloca.ItemsSource = await App.Database.GetlistLocalizaciones();
        }
    }
}