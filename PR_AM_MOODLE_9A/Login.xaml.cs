using Newtonsoft.Json;
using PR_AM_MOODLE_9A.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PR_AM_MOODLE_9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //private string nombre;

        /*private const string url = "https://campusvirtual.rfd.org.ec/webservices/ws_usuario.php";
        private readonly HttpClient usuario = new HttpClient();
        private ObservableCollection<PR_AM_MOODLE_9A.WebService.Loggin> _post;*/


        public Login()
        {
            InitializeComponent();
            txtNombreUsuario.Text = "";
            txtEmail.Text = "";
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {



            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://campusvirtual.rfd.org.ec/webservices/ws_usuario.php?username="+txtNombreUsuario.Text+"&email="+txtEmail.Text);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Aceptar", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {

                string content = await response.Content.ReadAsStringAsync();

                //usuario mvele 
                //0401541321 
                //johamoon2005@hotmail.com
               
                 if (content=="false")
                 {

                    await DisplayAlert("Aler", "Error al ingresar usuario o correo electronico", "Cerrar");
                    txtNombreUsuario.Text = "";
                    txtEmail.Text = "";

                 }
                 else
                 {
                    var nombre = txtNombreUsuario.Text;

                    await Navigation.PushAsync(new Contenido(content));

                }

            }
            else {
                await DisplayAlert("Alert", "No ingresa ", "Cerrar");
            }
           
        }
    }
}