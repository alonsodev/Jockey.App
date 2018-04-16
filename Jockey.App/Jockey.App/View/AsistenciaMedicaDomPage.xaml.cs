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
	public partial class AsistenciaMedicaDomPage : ContentPage
	{
        public AsistenciaMedicaDomPage()
        {
            InitializeComponent();

            bslAmbulancia.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAmbulancia()),
            });

            biAmbulancia.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAmbulancia()),
            });

            bslMedicoDomicilio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectMedicoDomicilio()),
            });

            biMedicoDomicilio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectMedicoDomicilio()),
            });

            bslEnfermeraDomicilio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectEnfermeraDomicilio()),
            });

            biEnfermeraDomicilio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectEnfermeraDomicilio()),
            });

            bslChoferReemplazo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectChoferReemplazo()),
            });

            biChoferReemplazo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectChoferReemplazo()),
            });

            bslDespistajeEmbarazo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectDespistajeEmbarazo()),
            });

            biDespistajeEmbarazo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectDespistajeEmbarazo()),
            });
        }

        private async Task OnConnectDespistajeEmbarazo()
        {
            await btnDespistajeEmbarazo.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnDespistajeEmbarazo.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslDespistajeEmbarazo, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("despistaje_embarazo");
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectChoferReemplazo()
        {
            await btnChoferReemplazo.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnChoferReemplazo.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslChoferReemplazo, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("chofer_reemplazo");
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectEnfermeraDomicilio()
        {
            await btnEnfermeraDomicilio.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnEnfermeraDomicilio.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslEnfermeraDomicilio, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("enfermera_domicilio");
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectMedicoDomicilio()
        {
            await btnMedicoDomicilio.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnMedicoDomicilio.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslMedicoDomicilio, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("medico_domicilio");
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectAmbulancia()
        {
            await btnAmbulancia.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnAmbulancia.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslAmbulancia, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("ambulancia");
            await Navigation.PushAsync(nextPage);
        }

        private void AnimateButtonTouched(Xamarin.Forms.View view, uint duration, Color hexColorInitial, Color hexColorFinal, int repeatCountMax)
        {
            var repeatCount = 0;
            view.Animate("changedBG", new Animation((val) => {
                if (repeatCount == 0)
                {
                    view.BackgroundColor = hexColorInitial;
                }
                else
                {
                    view.BackgroundColor = hexColorFinal;
                }
            }), duration, finished: (val, b) => {
                repeatCount++;
            }, repeat: () => {
                return repeatCount < repeatCountMax;
            });

            view.BackgroundColor = hexColorInitial;
        }
    }
}