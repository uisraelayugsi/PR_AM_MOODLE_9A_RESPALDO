using Newtonsoft.Json;
using Plugin.LocalNotifications;
using PR_AM_MOODLE_9A.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Plugin.LocalNotifications;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;


namespace PR_AM_MOODLE_9A
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Contenido : ContentPage
	{
        
        public Contenido (string usuario)
		{
			InitializeComponent ();
            var datos = JsonConvert.DeserializeObject<PR_AM_MOODLE_9A.WebService.Usuario>(usuario);

            lblNombre.Text = "Estudiante: " + datos.firstname + " " + datos.lastname;

            lblDatos.Text = usuario;

        }

        private  void btnForo_Clicked(object sender, EventArgs e)
        {
            var usuario = lblDatos.Text;
            //var datos = JsonConvert.DeserializeObject<PR_AM_MOODLE_9A.WebService.Usuario>(usuario);

            Navigation.PushAsync(new Foro(usuario));

        }

        private void txtCurso_Clicked(object sender, EventArgs e)
        {
            var usuario = lblDatos.Text;
            Navigation.PushAsync(new Cursos(usuario));
        }

        private void Notas_Clicked(object sender, EventArgs e)
        {
            var usuario = lblDatos.Text;

            Navigation.PushAsync(new Notas(usuario));

        }

        private void txtEscanea_Clicked(object sender, EventArgs e)
        {
            //var title = "Notificación";
            //var message = "¡Hola! Esto es una notificación.";

            //CrossLocalNotifications.Current.Show(title, message);
        }

        private void txtSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Inicio());
        }
    }
}