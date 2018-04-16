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
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();

            //_bslAsisMedDom = this.FindByName<StackLayout>("bslAsisMedDom");
            this.bslAsisMedDom.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsisMedDom()),
            });

            this.biAsisMedDom.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsisMedDom()),
            });

            this.bslAsisMedRem.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsisMedRem()),
            });

            this.biAsisMedRem.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsisMedRem()),
            });

            this.bslAsisSepelio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsisSepelio()),
            });

            this.biAsisSepelio.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectAsisSepelio()),
            });

            this.bslOferMed.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectOferMed()),
            });

            this.biOferMed.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectOferMed()),
            });

            this.imgOferMed.Source = ImageSource.FromUri(new Uri("http://desarrolladores.guru/jockey/oferta_medica.png"));
        }

        private async Task OnConnectAsisMedDom()
        {
            await btnAsisMedDom.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnAsisMedDom.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslAsisMedDom, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new AsistenciaMedicaDomPage();
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectAsisMedRem()
        {
            await btnAsisMedRem.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnAsisMedRem.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslAsisMedRem, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            //await Task.Delay(100);
            var nextPage = new AsistenciaRemotaPage();
            await Navigation.PushAsync(nextPage);
        }
        private async Task OnConnectAsisSepelio()
        {
            await btnAsisSepelio.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnAsisSepelio.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslAsisSepelio, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            var nextPage = new FormularioDatosPage("asistencia_sepelio");
            await Navigation.PushAsync(nextPage);
        }

        private async Task OnConnectOferMed()
        {
            await btnOferMed.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnOferMed.ScaleTo(1, 50, Easing.Linear);

            //AnimateButtonTouched(bslOferMed, 1500, (Color)Application.Current.Resources["DarkBackgroundColor"], (Color)Application.Current.Resources["LightBackgroundColor"], 1);
            //var nextPage = new FormularioDatosPage();
            //nextPage.BindingContext = "";
            //await Navigation.PushAsync(nextPage);
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