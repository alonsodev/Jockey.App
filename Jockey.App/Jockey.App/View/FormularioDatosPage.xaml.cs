using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jockey.App.View
{
    using Plugin.Messaging;
    using System.Text.RegularExpressions;
    public partial class FormularioDatosPage : ContentPage
	{
        private string _strTipoAsistencia;
        //private FormDataModel _cFormDataModel;
        public FormularioDatosPage(string pStrTipoAsistencia)
        {
            InitializeComponent();
            //txtFecNacimiento.Date = DateTime.Now;
            this._strTipoAsistencia = pStrTipoAsistencia;
            bslSolicitarAsis.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await OnConnectSolicitarAsis()),
            });
        }

        private async Task OnConnectSolicitarAsis()
        {
            await btnSolicitarAsis.ScaleTo(0.9, 50, Easing.Linear);
            await Task.Delay(100);
            await btnSolicitarAsis.ScaleTo(1, 50, Easing.Linear);

            if (String.IsNullOrEmpty(txtNombreCompleto.Text))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar el Nombre Completo.", "OK");
                return;
            }

            if (String.IsNullOrEmpty(txtDocIdentidad.Text))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar el Documento de Identidad.", "OK");
                return;
            }

            if (txtFecNacimiento.Date == null)
            {
                await DisplayAlert("Advertencia", "Por favor ingresar la Fecha de Nacimiento.", "OK");
                return;
            }

            if (String.IsNullOrEmpty(txtNoContacto.Text))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar el No. de Contacto.", "OK");
                return;
            }

            if (String.IsNullOrEmpty(txtDireccion.Text))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar la Dirección.", "OK");
                return;
            }

            if (String.IsNullOrEmpty(txtDistrito.Text))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar el Distrito.", "OK");
                return;
            }

            if (String.IsNullOrEmpty(txtCorreoElectronico.Text))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar el Correo Electrónico.", "OK");
                return;
            }

            if (!(Regex.Match(txtCorreoElectronico.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success))
            {
                await DisplayAlert("Advertencia", "Por favor ingresar un Correo Electrónico válido.", "OK");
                return;
            }

            var emailMessenger = CrossMessaging.Current.EmailMessenger;

            //_cFormDataModel.DocIdentidad = txtDocIdentidad.Text;

            if (emailMessenger.CanSendEmail)
            {
                string vStrTextoTipoAsistencia = this.obtenerTextoTipoAsistencia();
                string vStrCuerpoCorreo = this.obtenerCuerpoCorreo(vStrTextoTipoAsistencia);

                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail("solicitudes.jockey@axa-assistance.com.pa", "Jockey Salud - " + vStrTextoTipoAsistencia, vStrCuerpoCorreo);
            }

            var nextPage = new NosComunicaremosPage();
            await Navigation.PushAsync(nextPage);
        }

        private string obtenerCuerpoCorreo(string pStrTextoTipoAsistencia)
        {
            string vStrCuerpoCorreo = "Jockey Salud - " + pStrTextoTipoAsistencia + "\n\n\n";
            vStrCuerpoCorreo += "Nombre completo: " + txtNombreCompleto.Text + "\n\n";
            vStrCuerpoCorreo += "Documento de identidad: " + txtDocIdentidad.Text + "\n\n";
            vStrCuerpoCorreo += "Fecha de nacimiento: " + txtFecNacimiento.Date.ToString("dd/MM/yyyy") + "\n\n";
            vStrCuerpoCorreo += "No. de contacto: " + txtNoContacto.Text + "\n\n";
            vStrCuerpoCorreo += "Dirección: " + txtDireccion.Text + "\n\n";
            vStrCuerpoCorreo += "Distrito: " + txtDistrito.Text + "\n\n";
            vStrCuerpoCorreo += "Correo electrónico: " + txtCorreoElectronico.Text + "\n\n";

            return vStrCuerpoCorreo;
        }

        private string obtenerTextoTipoAsistencia()
        {
            string vStrTextoTipoAsistencia = "";

            switch (this._strTipoAsistencia)
            {
                case "recordatorio":
                    vStrTextoTipoAsistencia = "Recordatorio de Toma de Medicamentos";
                    break;
                case "asistencia":
                    vStrTextoTipoAsistencia = "Asistencia Médica Telefónica";
                    break;
                case "despistaje_embarazo":
                    vStrTextoTipoAsistencia = "Despistaje de Embarazo";
                    break;
                case "chofer_reemplazo":
                    vStrTextoTipoAsistencia = "Chofer de Reemplazo";
                    break;
                case "enfermera_domicilio":
                    vStrTextoTipoAsistencia = "Enfermera a Domicilio";
                    break;
                case "medico_domicilio":
                    vStrTextoTipoAsistencia = "Médico a Domicilio";
                    break;
                case "ambulancia":
                    vStrTextoTipoAsistencia = "Ambulancia";
                    break;
                default:
                    vStrTextoTipoAsistencia = "";
                    break;
            }

            return vStrTextoTipoAsistencia;
        }
    }
}