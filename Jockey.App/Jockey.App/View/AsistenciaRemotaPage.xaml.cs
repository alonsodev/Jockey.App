using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jockey.App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AsistenciaRemotaPage : ContentPage
	{
        public AsistenciaRemotaPage()
        {
            InitializeComponent();

            bslRecordatorio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectRecordatorio()),
            });

            bslAsistencia.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsistencia()),
            });
        }

        private async Task OnConnectRecordatorio()
        {
            await btnRecordatorio.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnRecordatorio.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslDespistajeEmbarazo, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("recordatorio");
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectAsistencia()
        {
            await btnAsistencia.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnAsistencia.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslDespistajeEmbarazo, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("asistencia");
            await Navigation.PushAsync(nextPage);
        }
    }
}