using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EXAMENP4119450112.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLocalizacion : ContentPage
    {

        Location location = null;
        public PageLocalizacion()
        {
            InitializeComponent();
        }

        private async void btguardar_Clicked(object sender, EventArgs e)
        {
            
            try
            {

                if (location != null &&
                    !string.IsNullOrEmpty(descripcion_corta.Text) &&
                    !string.IsNullOrEmpty(descripcion_larga.Text))
                {
                    Latitud.Text = Convert.ToString(location.Latitude);
                    Longitud.Text = Convert.ToString(location.Longitude);

                    var loca = new Models.Localizacion
                    {
                        Latitud = location.Latitude,
                        Longitud = location.Longitude,
                        descripcion_corta = descripcion_corta.Text,
                        descripcion_larga = descripcion_larga.Text
                    };

                    if (await App.Database.SaveGeo(loca) > 0)
                    {
                        await DisplayAlert("Aviso", "Localizacion Guardada", "ok");

                    }

                }
                else
                {
                    if (location == null)
                    {
                        await DisplayAlert("Error", "Error no esta activo el gps", "ok");
                    }
                    else if (string.IsNullOrEmpty(descripcion_corta.Text))
                    {
                        await DisplayAlert("Error", "Error sin descripcion corta", "ok");
                    }
                    else if (string.IsNullOrEmpty(descripcion_larga.Text))
                    {
                        await DisplayAlert("Error", "Error sin descripcion larga", "ok");
                    }
                }

            }
            catch (Exception ex)
            {
                if (location == null)
                {
                    await DisplayAlert("Error", "Error no esta activo el gps", "ok");
                }
            }
        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            var page = new Views.PageListGeo();
            await Navigation.PushAsync(page);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Latitud.Text = Convert.ToString(location.Latitude);
                    Longitud.Text = Convert.ToString(location.Longitude);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}