using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace EXAMENP4119450112.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMap : ContentPage
    {
        public PageMap()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var seleccion = (Models.Localizacion)this.BindingContext;

            var centromap = new Xamarin.Forms.Maps.Position(seleccion.Latitud, seleccion.Longitud);
            mapa.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(centromap, 1, 1));

            Pin ubicacion = new Pin();
            ubicacion.Label = seleccion.descripcion_corta;
            ubicacion.Address = seleccion.descripcion_larga;
            ubicacion.Position = new Xamarin.Forms.Maps.Position(seleccion.Latitud, seleccion.Longitud);
            mapa.Pins.Add(ubicacion);

        }
    }
}