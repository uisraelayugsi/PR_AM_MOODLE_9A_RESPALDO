using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PR_AM_MOODLE_9A
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
		}

        private async void btnHuella_Clicked(object sender, EventArgs e)
        {
            bool supported = await CrossFingerprint.Current.IsAvailableAsync(true);
            if (supported)
            {
                AuthenticationRequestConfiguration conf = new AuthenticationRequestConfiguration("Registres su huella ", "Aqui");
                var resultado = await CrossFingerprint.Current.AuthenticateAsync(conf);

                if (resultado.Authenticated)
                {
                    string content = @"{ ""id"":35231,""email"":""ayugsi@point.com.ec"",""username"":""ayusgi"",""firstname"":""Alex"",""lastname"":""yugsi"",""city"":""Quito"",""password"":""$2y$10$rFIuxApQIY20cuYZvArZluJM5pI/qAgqlWWGPhLYrU0qjxDnAURJa"" }";

                    await Navigation.PushAsync(new Contenido(content));

                }
                else if (resultado.Status == FingerprintAuthenticationResultStatus.Failed)
                {
                    await DisplayAlert("Error", "Autenticación fallida", "OK");
                }
                else if (resultado.Status == FingerprintAuthenticationResultStatus.Canceled)
                {
                    await DisplayAlert("Advertencia", "Autenticación cancelada", "OK");
                }
                else if (resultado.Status == FingerprintAuthenticationResultStatus.NotAvailable)
                {
                    await DisplayAlert("Error", "Autenticación de huella digital no disponible", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "La autenticación de huella digital no está disponible", "OK");
            }
        }

        private void btnUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}